import { ReactNode } from 'react';
import { Link } from 'react-router-dom';
import { describe, expect, it } from 'vitest';

import { ProtectedRoute } from '..';
import { renderWithProviders } from 'utils/test-utils';

describe('ProtectedRoute', () => {
  const children: ReactNode = (
    <h1>
      Welcome dear user
      <Link to="/login">Back to login</Link>
    </h1>
  );

  it('should render', () => {
    const { asFragment } = renderWithProviders(
      <ProtectedRoute>{children}</ProtectedRoute>,
    );

    expect(asFragment()).toMatchSnapshot();
  });
});
