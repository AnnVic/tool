import { describe, expect, it } from 'vitest';
import { store } from 'store/store.ts';

describe('Store', () => {
  it('should configure the store with middleware', () => {
    expect(store).toBeDefined();
    expect(store.getState().login).toEqual({
      token: null,
      username: null,
    });
  });
});
