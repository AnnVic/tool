import * as yup from 'yup';

const nameConstrained =
  "Should be from 3 to 30 letters or symbols(space, -, ')";
const userNameConstrained =
  "Should be unique and from 3 to 30 alphanumeric character's or symbols(space, -, ')";
const emailConstained = "Should be unique, alphanumeric cahracters, dots, '@'";

export const profileSchema = yup.object().shape({
  firstName: yup
    .string()
    .min(3, nameConstrained)
    .max(30, nameConstrained)
    .matches(/^[a-zA-Z\s'-]+$/, nameConstrained)
    .required(nameConstrained),
  lastName: yup
    .string()
    .min(3, nameConstrained)
    .max(30, nameConstrained)
    .matches(/^[0-9a-zA-Z\s'-]+$/, nameConstrained)
    .required(nameConstrained),
  userName: yup
    .string()
    .min(3, userNameConstrained)
    .max(30, userNameConstrained)
    .matches(/^[0-9a-zA-Z\s'-]+$/, userNameConstrained)
    .required(userNameConstrained),
  email: yup.string().email(emailConstained).required(emailConstained),
});
