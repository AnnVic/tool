import storage from 'redux-persist/lib/storage';
import { persistReducer } from 'redux-persist';

import { rootReducer } from './rootReducer.ts';
import { profileApi } from 'services/profileApiService.ts';
import { authApi } from 'services/authApiService.ts';

const persistConfig = {
  key: 'root',
  storage,
  whitelist: ['login', 'profile'],
  blacklist: [authApi.reducerPath, profileApi.reducerPath],
};

export const persistedReducer = persistReducer(persistConfig, rootReducer);
