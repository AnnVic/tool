import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useFormik } from 'formik';
import { toast } from 'react-toastify';

import alertIcon from 'assets/alert.svg';
import { signupSchema } from 'features/signup/signupSchema.ts';
import BookSharingCover from 'components/BookSharingCover.tsx';
import { useSignupMutation } from 'services/authApiService';

import {
  Button,
  Error,
  ErrorIcon,
  Flex,
  Form,
  Input,
  LoginContainer,
  LoginFormHeader,
  LoginFormWrapper,
  Message,
  Spinner,
} from 'styles/index.ts';

type InitialValues = {
  firstname: string;
  lastname: string;
  username: string;
  password: string;
  repeatPassword: string;
  email: string;
};

const initialValues: InitialValues = {
  firstname: '',
  lastname: '',
  username: '',
  password: '',
  repeatPassword: '',
  email: '',
};

type ErrorType = {
  data: {
    Message: string;
  };
};

const SignUp = () => {
  const navigate = useNavigate();
  const [signup, { isError, isLoading, isSuccess, data: response, error }] =
    useSignupMutation();
  const { handleSubmit, handleChange, handleBlur, values, errors, touched } =
    useFormik({
      initialValues,
      onSubmit,
      validationSchema: signupSchema,
    });

  useEffect(() => {
    if (isSuccess) {
      toast.success('New account has been successfully created.');
      navigate('/login');
    }

    if (error) {
      if ('status' in error) {
        toast.error((error as ErrorType).data.Message);
      } else {
        toast.error(
          'Your registration failed due to an internal server error. Please try again later.',
        );
      }
    }
  }, [isSuccess, isError, navigate, error, response]);

  function onSubmit(values: InitialValues) {
    signup({
      email: values.email,
      password: values.password,
      firstName: values.firstname,
      lastName: values.lastname,
      userName: values.username,
      passwordConfirmation: values.repeatPassword,
    });
  }

  return (
    <div>
      <LoginContainer>
        <BookSharingCover />
        <LoginFormWrapper>
          <div>
            <LoginFormHeader>
              <h2>Sign up</h2>
            </LoginFormHeader>
            <Form onSubmit={handleSubmit} autoComplete="off">
              <Flex direction="column">
                <Input
                  $isInvalid={Boolean(
                    (!values.firstname && touched.firstname) ||
                      (values.firstname && errors.firstname),
                  )}
                  name="firstname"
                  type="text"
                  value={values.firstname}
                  placeholder="First name"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  data-testid="firstname-input"
                />
                {((!values.firstname && touched.firstname) ||
                  (values.firstname && errors.firstname)) && (
                  <Error>
                    <ErrorIcon src={alertIcon} alt="alert icon" />
                    {errors.firstname}
                  </Error>
                )}
              </Flex>
              <Flex direction="column">
                <Input
                  $isInvalid={Boolean(
                    (!values.lastname && touched.lastname) ||
                      (values.lastname && errors.lastname),
                  )}
                  name="lastname"
                  type="text"
                  value={values.lastname}
                  placeholder="Last name"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  data-testid="lastname-input"
                />
                {((!values.lastname && touched.lastname) ||
                  (values.lastname && errors.lastname)) && (
                  <Error>
                    <ErrorIcon src={alertIcon} alt="alert icon" />
                    {errors.lastname}
                  </Error>
                )}
              </Flex>
              <Flex direction="column">
                <Input
                  $isInvalid={Boolean(
                    (!values.username && touched.username) ||
                      (values.username && errors.username),
                  )}
                  name="username"
                  type="text"
                  value={values.username}
                  placeholder="Enter username"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  data-testid="username-input"
                />
                {((!values.username && touched.username) ||
                  (values.username && errors.username)) && (
                  <Error>
                    <ErrorIcon src={alertIcon} alt="alert icon" />
                    {errors.username}
                  </Error>
                )}
              </Flex>
              <Flex direction="column">
                <Input
                  $isInvalid={Boolean(
                    (!values.email && touched.email) ||
                      (values.email && errors.email),
                  )}
                  name="email"
                  type="email"
                  value={values.email}
                  placeholder="Enter email"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  data-testid="email-input"
                />
                {(((!values.email && touched.email) ||
                  (values.email && errors.email)) && (
                  <Error>
                    <ErrorIcon src={alertIcon} alt="alert icon" />
                    {errors.email}
                  </Error>
                )) || (
                  <Message>
                    We`ll never share your email with anyone else.
                  </Message>
                )}
              </Flex>
              <Flex direction="column">
                <Input
                  $isInvalid={Boolean(
                    (!values.password && touched.password) ||
                      (values.password && errors.password),
                  )}
                  name="password"
                  type="password"
                  value={values.password}
                  placeholder="Enter password"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  data-testid="password-input"
                />
                {((!values.password && touched.password) ||
                  (values.password && errors.password)) && (
                  <Error>
                    <ErrorIcon src={alertIcon} alt="alert icon" />
                    {errors.password}
                  </Error>
                )}
              </Flex>
              <Flex direction="column">
                <Input
                  $isInvalid={Boolean(
                    (!values.repeatPassword && touched.repeatPassword) ||
                      (values.repeatPassword &&
                        values.repeatPassword !== values.password),
                  )}
                  name="repeatPassword"
                  type="password"
                  value={values.repeatPassword}
                  placeholder="Repeat password"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  data-testid="repeat-password-input"
                />
                {((!values.repeatPassword && touched.repeatPassword) ||
                  (values.repeatPassword &&
                    values.repeatPassword !== values.password)) && (
                  <Error>
                    <ErrorIcon src={alertIcon} alt="alert icon" />
                    Should match the password
                  </Error>
                )}
              </Flex>
              <Flex
                direction="row"
                style={{ justifyContent: 'space-between', gap: '20px' }}
              >
                {isLoading ? (
                  <Spinner style={{ flex: '1' }} />
                ) : (
                  <Button
                    type="submit"
                    style={{ flex: '1', borderRadius: '5px' }}
                    data-testid="signup-submit"
                  >
                    Sign up
                  </Button>
                )}
                <Button
                  onClick={() => {
                    navigate('/login');
                  }}
                  style={{ flex: '1', borderRadius: '5px' }}
                >
                  Log in
                </Button>
              </Flex>
            </Form>
          </div>
        </LoginFormWrapper>
      </LoginContainer>
    </div>
  );
};

export default SignUp;
