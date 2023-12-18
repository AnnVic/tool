import { fetchBaseQuery } from '@reduxjs/toolkit/query';
import { type RootState } from 'store/store.ts';

export const BASE_URL = 'https://booksharing-be.app.mddinternship.com/';
export const IMG_URL =
  'https://booksharing-be.app.mddinternship.com/staticfiles/';

export const baseQuery = fetchBaseQuery({
  baseUrl: BASE_URL,
  prepareHeaders: (headers, { getState }) => {
    const access_token = (getState() as RootState).login.token;
    if (access_token) {
      headers.set('Authorization', `Bearer ${access_token}`);
    }
    return headers;
  },
});
