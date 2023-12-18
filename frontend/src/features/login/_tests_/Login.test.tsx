import { beforeEach, describe, expect } from 'vitest';
import { fireEvent, screen, waitFor } from '@testing-library/react';
import { renderWithProviders } from 'utils/test-utils.tsx';
import Login from 'features/login/Login.tsx';
import { toast } from 'react-toastify';

type RenderResult = {
  asFragment: () => unknown;
};

const mocks = vi.hoisted(() => {
  return {
    isError: false,
    isSuccess: false,
    data: true,
  };
});

const mockLogin = vi.hoisted(() => {
  return {
    login: vi.fn(),
  };
});

vi.mock('services/authApiService.ts', async (importOriginal) => {
  const mod = await importOriginal();
  return {
    ...(mod as { isError: boolean; isSuccess: boolean }),
    useLoginMutation: () => [
      mockLogin.login,
      {
        isLoading: false,
        ...mocks,
      },
    ],
  };
});

vi.mock('react-toastify');

describe('Login', () => {
  let login: RenderResult;

  beforeEach(() => {
    vi.resetAllMocks();
    login = renderWithProviders(<Login />);
  });

  it('Should render Login page', () => {
    const { asFragment } = login;
    expect(asFragment()).toMatchSnapshot();
  });

  it('Should invalidate when no inputs provided ', async () => {
    const submitButton = screen.getByTestId('submit-button');
    fireEvent.click(submitButton);

    await waitFor(() => {
      const emailError = screen.getByText('Please enter your username', {
        selector: 'p',
      });
      const passError = screen.getByText('Please enter your password', {
        selector: 'p',
      });

      expect(emailError).toBeInTheDocument();
      expect(passError).toBeInTheDocument();
    });
  });

  it('Should invalidate if wrong credentials', async () => {
    const usernameInput = screen.getByTestId('username-input');
    const passwordInput = screen.getByTestId('password-input');
    const submitButton = screen.getByTestId('submit-button');

    fireEvent.change(usernameInput, { target: { value: 'username' } });
    fireEvent.change(passwordInput, { target: { value: 'password123' } });
    fireEvent.click(submitButton);

    await waitFor(() => {
      mocks.isError = true;
      expect(toast.error).toBeCalledTimes(1);
      expect(toast.error).toBeCalledWith(
        'Invalid email or password provided. Please double-check and try again.',
      );
    });
  });

  it('Should be valid credentials', async () => {
    const usernameInput = screen.getByTestId('username-input');
    const passwordInput = screen.getByTestId('password-input');
    const submitButton = screen.getByTestId('submit-button');

    fireEvent.change(usernameInput, { target: { value: 'username' } });
    fireEvent.change(passwordInput, { target: { value: 'top-secret' } });
    fireEvent.click(submitButton);

    await waitFor(() => {
      mocks.isSuccess = true;
      mocks.isError = false;

      expect(mockLogin.login).toBeCalledTimes(1);
      expect(toast.success).toBeCalledTimes(1);
      expect(toast.success).toBeCalledWith('Login successful');
    });
  });
});
