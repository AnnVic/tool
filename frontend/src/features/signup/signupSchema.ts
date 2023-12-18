import * as yup from 'yup';

const NAME_VALIDATION_ERROR_MESSAGE = 'Should be from 3 to 30 letters or symbols(space, -, \')';
const USERNAME_ERROR_MESSAGE = 'Should be unique and from 3 to 30 alphanumeric characters or symbols(space, -, \')';
const PASSWORD_ERROR_MESSAGE = 'Should be from 4 to 30 aplhanumeric characters and symbols';
const FULL_NAME_REGEX = /^[a-zA-Z\s'-]+$/;

export const signupSchema = yup.object().shape({
  firstname: yup
    .string()
    .min(3, NAME_VALIDATION_ERROR_MESSAGE)
    .max(30, NAME_VALIDATION_ERROR_MESSAGE)
    .matches(
      FULL_NAME_REGEX,
      NAME_VALIDATION_ERROR_MESSAGE,
    )
    .required('First name is required'),
  lastname: yup
    .string()
    .min(3, NAME_VALIDATION_ERROR_MESSAGE)
    .max(30, NAME_VALIDATION_ERROR_MESSAGE)
    .matches(
      FULL_NAME_REGEX,
      NAME_VALIDATION_ERROR_MESSAGE,
    )
    .required('Last name is required'),
  username: yup
    .string()
    .min(
      3,
      USERNAME_ERROR_MESSAGE,
    )
    .max(
      30,
      USERNAME_ERROR_MESSAGE,
    )
    .matches(
      /^[0-9a-zA-Z\s'-]+$/,
      USERNAME_ERROR_MESSAGE,
    )
    .required('Username is required'),
  email: yup
    .string()
    .matches(/^[\w-.]+@([\w-]+\.)*[\w-]+$/, 'Should be unique, alphanumeric characters, dots, "@"')
    .required('Email is required'),
  password: yup
    .string()
    .min(4, PASSWORD_ERROR_MESSAGE)
    .max(30, PASSWORD_ERROR_MESSAGE)
    .matches(/[0-9]/, 'Password requires a number')
    .matches(/[a-z]/, 'Password requires a lowercase letter')
    .matches(/[A-Z]/, 'Password requires an uppercase letter')
    .matches(/\W/, 'Password requires a symbol')
    .required('Password is required'),
});
