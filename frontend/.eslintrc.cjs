module.exports = {
  root: true,
  env: {
    browser: true,
    es2020: true,
  },
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/recommended',
    'plugin:react-hooks/recommended',
    'plugin:prettier/recommended',
    'plugin:import/typescript',
  ],
  ignorePatterns: ['dist', '.eslintrc.json'],
  parser: '@typescript-eslint/parser',
  parserOptions: {
    ecmaFeatures: { jsx: true },
    ecmaVersion: 'latest',
    sourceType: 'module',
  },
  plugins: ['react', 'react-hooks', 'react-refresh', 'prettier', '@typescript-eslint', 'import'],
  rules: {
    'react/jsx-props-no-spreading': ['warn'],
    indent: ['warn', 2],
    quotes: ['error', 'single'],
    semi: ['warn', 'always'],
    'jsx-quotes': ['error', 'prefer-double'],
    'react-refresh/only-export-components': ['warn', { allowConstantExport: true }],
    'prettier/prettier': ['warn', { endOfLine: 'auto' }],
    'no-console': ['error', { allow: ['warn', 'error'] }],
    'prefer-const': 'warn',
    'react/jsx-curly-brace-presence': [
      'error',
      {
        props: 'never',
        children: 'never',
        propElementValues: 'always',
      },
    ],
  },
};
