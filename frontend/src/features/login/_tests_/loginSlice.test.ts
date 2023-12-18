import { setupStore, type RootState } from 'store/store';
import { it, describe, expect } from 'vitest';
import reducer, {
  setCredentials,
  unsetCredentials,
  selectLoginAccessToken,
  initialState,
} from 'features/login/loginSlice.ts';

describe('loginSlice', () => {
  const credentials = {
    token: '123456A',
    username: 'Username',
  };

  it('should return the initial state', () => {
    expect(reducer(undefined, { type: undefined })).toEqual(initialState);
  });

  it('should handle setCredential action', () => {
    expect(reducer(initialState, setCredentials(credentials))).toEqual(
      credentials,
    );
  });

  it('should handle unsetCredentials', () => {
    expect(reducer(credentials, unsetCredentials())).toEqual(initialState);
  });

  it('should selectLoginAccessToken from state', () => {
    const state: RootState = setupStore().getState();
    const result = selectLoginAccessToken(state);

    expect(result).toEqual(null);
  });
});
