import { createApi } from '@reduxjs/toolkit/query/react';
import { baseQuery } from './baseApiService';

export type SignupResponse = {
  code: string;
  description: string;
};

export type SignupRequest = {
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  password: string;
  passwordConfirmation: string;
};

export type LoginResponse = {
  token: string;
};

export type LoginRequest = {
  username: string;
  password: string;
};

export const authApi = createApi({
  reducerPath: 'authApi',
  baseQuery: baseQuery,
  endpoints: (builder) => ({
    signup: builder.mutation<SignupResponse, SignupRequest>({
      query: (credentials) => ({
        url: '/Authentication/register',
        method: 'POST',
        body: credentials,
      }),
    }),
    login: builder.mutation<LoginResponse, LoginRequest>({
      query: (credentials) => ({
        url: '/Authentication/login',
        method: 'POST',
        body: credentials,
      }),
    }),
  }),
});

export const {
  useSignupMutation,
  useLoginMutation,
  reducer,
  reducerPath,
  middleware,
} = authApi;
