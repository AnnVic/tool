import styled from 'styled-components';

export const LoginContainer = styled.section`
  display: grid;
  grid-template-areas: 'title login';
  grid-template-columns: 1fr 2fr;
  height: 100vh;
`;

export const LoginFormHeader = styled.header`
  text-align: center;
  font-size: 14px;

  span {
    color: var(--color-primary-medium);
    font-weight: 600;
  }

  a {
    color: inherit;
    margin-left: 12px;
    font-weight: 600;
  }
`;

type Props = {
  gap?: number;
};

export const LoginFormWrapper = styled.div<Props>`
  grid-area: login;
  display: grid;
  gap: 1.5rem;
  place-items: center;
  padding: 10px;
  background-color: var(--color-primary-extra-light);

  & > div {
    display: flex;
    flex-direction: column;
    gap: ${(props) => props.gap || 0}px;

    h2 {
      font-size: 3rem;
      font-weight: 400;
      margin-bottom: 16px;
    }
  }
`;
