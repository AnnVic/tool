import { combineReducers } from '@reduxjs/toolkit';

import booksReducer from 'features/profilePage/uploadBook/bookSlice.ts';
import loginReducer from 'features/login/loginSlice';
import { bookApi } from 'services/bookApiService.ts';
import profileSlice from 'features/profilePage/personalProfile/profileSlice';
import { profileApi } from 'services/profileApiService';
import { authApi } from 'services/authApiService.ts';

export const rootReducer = combineReducers({
  [authApi.reducerPath]: authApi.reducer,
  login: loginReducer,
  [bookApi.reducerPath]: bookApi.reducer,
  books: booksReducer,
  [profileApi.reducerPath]: profileApi.reducer,
  profile: profileSlice,
});
