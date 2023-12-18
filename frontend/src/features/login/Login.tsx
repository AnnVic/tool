import { useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import { useFormik } from 'formik';

import { loginSchema } from './loginSchema.ts';
import { useLoginMutation } from 'services/authApiService.ts';
import alertIcon from 'assets/alert.svg';
import { setCredentials } from './loginSlice.ts';
import { useAppDispatch } from 'store/storeHooks.ts';
import {
  Button,
  Error,
  Flex,
  Form,
  LoginContainer,
  LoginFormHeader,
  LoginFormWrapper,
  Spinner,
  Input,
  Label,
  ErrorIcon,
} from 'styles/index.ts';
import { BookSharingCover } from 'components/index.ts';
import { type InitialValues, initialValues } from './constants.ts';

function Login() {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const [login, { isLoading, isError, isSuccess, data: credentials }] =
    useLoginMutation();
  const { handleSubmit, handleChange, handleBlur, values, errors, touched } =
    useFormik({
      initialValues,
      onSubmit,
      validationSchema: loginSchema,
    });

  useEffect(() => {
    if (credentials && isSuccess) {
      toast.success('Login successful');
      dispatch(
        setCredentials({ token: credentials.token, username: values.username }),
      );
      navigate('/');
    }

    if (isError) {
      toast.error(
        'Invalid email or password provided. Please double-check and try again.',
      );
    }
  }, [credentials, isSuccess, isError, dispatch, navigate, values.username]);

  function onSubmit(values: InitialValues) {
    login({
      username: values.username,
      password: values.password,
    });
  }

  return (
    <LoginContainer>
      <BookSharingCover />
      <LoginFormWrapper>
        <div>
          <LoginFormHeader>
            <h2>Login</h2>
            <span>Don't have an account yet?</span>
            <Link to="/signup">Sign Up</Link>
          </LoginFormHeader>
          <Form onSubmit={handleSubmit}>
            <Flex direction="column">
              <Label htmlFor="username">Username</Label>
              <Input
                $isInvalid={Boolean(!values.username && touched.username)}
                name="username"
                type="username"
                value={values.username}
                placeholder="Enter username"
                onChange={handleChange}
                onBlur={handleBlur}
                data-testid="username-input"
              />
              {!values.username && touched.username && (
                <Error>
                  <ErrorIcon src={alertIcon} alt="alert icon" />
                  {errors.username}
                </Error>
              )}
            </Flex>
            <Flex direction="column">
              <Label htmlFor="password">Password</Label>
              <Input
                $isInvalid={Boolean(!values.password && touched.password)}
                name="password"
                type="password"
                value={values.password}
                placeholder="Enter password"
                onChange={handleChange}
                onBlur={handleBlur}
                data-testid="password-input"
              />
              {!values.password && touched.password && (
                <Error>
                  <ErrorIcon src={alertIcon} alt="alert icon" />
                  {errors.password}
                </Error>
              )}
            </Flex>
            <Link to="/forgot-password">Forgot password?</Link>
            {isLoading ? (
              <Spinner />
            ) : (
              <Button type="submit" data-testid="submit-button">
                Login
              </Button>
            )}
          </Form>
        </div>
      </LoginFormWrapper>
    </LoginContainer>
  );
}

export default Login;
