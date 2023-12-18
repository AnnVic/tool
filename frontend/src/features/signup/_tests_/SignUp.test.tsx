import { describe } from 'vitest';
import { fireEvent, screen } from '@testing-library/react';
import { renderWithProviders } from 'utils/test-utils.tsx';
import SignUp from "features/signup/SignUp.tsx";

describe('Login', () => {
  it('should render signup form and handles submission', async () => {
    renderWithProviders(<SignUp />);
    const firstnameInput = screen.getByTestId('firstname-input');
    const lastnameInput = screen.getByTestId('lastname-input');
    const usernameInput = screen.getByTestId('username-input');
    const emailInput = screen.getByTestId('email-input');
    const passwordInput = screen.getByTestId('password-input');
    const repeatPasswordInput = screen.getByTestId('repeat-password-input');
    const submitButton = screen.getByTestId('signup-submit');

    fireEvent.change(firstnameInput, { target: { value: 'firstname' } });
    fireEvent.change(lastnameInput, { target: { value: 'lastname' } });
    fireEvent.change(usernameInput, { target: { value: 'username' } });
    fireEvent.change(emailInput, { target: { value: 'email@email.email' } });
    fireEvent.change(passwordInput, { target: { value: 'password1' } });
    fireEvent.change(repeatPasswordInput, { target: { value: 'password1' } });
    fireEvent.click(submitButton);
  });
});
