import { createApi } from '@reduxjs/toolkit/query/react';
import { baseQuery } from './baseApiService';

export type User = {
  userName: string;
  firstName: string;
  lastName: string;
  email: string;
};

export const profileApi = createApi({
  reducerPath: 'profileApi',
  baseQuery: baseQuery,
  tagTypes: ['User'],
  endpoints: (builder) => ({
    getUser: builder.query<User, void>({
      query: () => ({
        url: '/api/profile',
        method: 'GET',
      }),
      providesTags: ['User'],
    }),
    updateUser: builder.mutation<void, User>({
      query: (body) => ({
        url: 'api/profile',
        method: 'PATCH',
        body,
      }),
      invalidatesTags: ['User'],
    }),
  }),
});

export const { useGetUserQuery, useUpdateUserMutation } = profileApi;
