import { selectLoginAccessToken } from 'features/login/loginSlice';
import { type PropsWithChildren } from 'react';
import { Navigate } from 'react-router-dom';

import { useAppSelector } from 'store/storeHooks.ts';

export default function ProtectedRoute({ children }: PropsWithChildren) {
  const accessToken = useAppSelector(selectLoginAccessToken);

  return accessToken ? children : <Navigate to="/login" />;
}
