import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { type RootState } from 'store/store.ts';

type ProfileInitialState = {
  userName: string | null;
  firstName: string | null;
  lastName: string | null;
  email: string | null;
};

const initialState: ProfileInitialState = {
  userName: null,
  firstName: null,
  lastName: null,
  email: null,
};

export const profileSlice = createSlice({
  name: 'profile',
  initialState,
  reducers: {
    setUser: (
      state: ProfileInitialState,
      action: PayloadAction<ProfileInitialState>,
    ) => {
      state.userName = action.payload.userName;
      state.firstName = action.payload.firstName;
      state.lastName = action.payload.lastName;
      state.email = action.payload.email;
    },
    unsetUser: (state: ProfileInitialState) => {
      state.userName = null;
      state.firstName = null;
      state.lastName = null;
      state.email = null;
    },
  },
});

export const { setUser } = profileSlice.actions;
export const { unsetUser } = profileSlice.actions;
export default profileSlice.reducer;

export const selectProfileUserName = (state: RootState) =>
  state.profile.userName;
export const selectProfileFirstName = (state: RootState) =>
  state.profile.firstName;
export const selectProfileLastName = (state: RootState) =>
  state.profile.lastName;
export const selectProfileEmail = (state: RootState) => state.profile.email;
