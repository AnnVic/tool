import { defineConfig } from 'vitest/config';
import react from '@vitejs/plugin-react-swc';

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  test: {
    globals: true,
    environment: 'jsdom',
    setupFiles: './setup.ts',
    reporters: ['default', 'html'],
    coverage: {
      provider: 'v8',
      reporter: ['text', 'json', 'html'],
      enabled: true,
    },
  },
  resolve: {
    alias: {
      components: '/src/components',
      types: '/src/types',
      hooks: '/src/hooks',
      pages: '/src/pages',
      store: '/src/store',
      assets: '/src/assets',
      services: '/src/services',
      features: '/src/features',
      styles: '/src/components/styles',
      utils: '/src/utils',
    },
  },
});
