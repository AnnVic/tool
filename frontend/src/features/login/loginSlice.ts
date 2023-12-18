import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { type RootState } from 'store/store.ts';

type LoginInitialState = {
  token: string | null;
  username: string | null;
};

export const initialState: LoginInitialState = {
  token: null,
  username: null,
};

const loginSlice = createSlice({
  name: 'login',
  initialState,
  reducers: {
    setCredentials: (
      state: LoginInitialState,
      action: PayloadAction<LoginInitialState>,
    ) => {
      state.token = action.payload.token;
      state.username = action.payload.username;
    },
    unsetCredentials: (state: LoginInitialState) => {
      state.token = null;
      state.username = null;
    },
  },
});

export const { setCredentials, unsetCredentials } = loginSlice.actions;
export default loginSlice.reducer;

export const selectLoginAccessToken = (state: RootState) => state.login.token;
export const selectUsername = (state: RootState) => state.login.username;
