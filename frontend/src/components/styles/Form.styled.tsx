import styled from 'styled-components';

type FormProps = {
  $isInvalid?: boolean;
  $minWidth?: string;
  $width?: string;
  $backgroundColor?: string;
};



export const Form = styled.form<FormProps>`
  display: flex;
  flex-direction: column;
  gap: 32px;
  font-size: 14px;
  min-width: ${({ $minWidth }) => $minWidth || '30vw'};

  a {
    color: var(--color-primary-gray);
    font-weight: 600;
    text-decoration: none;
  }
`;

export const ProfileForm = styled.div<FormProps>`
  display: flex;
  flex-direction: column;
  gap: 32px;
  font-size: 14px;
  min-width: ${({ $minWidth }) => $minWidth || '30vw'};

  a {
    color: var(--color-primary-gray);
    font-weight: 600;
    text-decoration: none;
  }
`;

export const Label = styled.label`
  font-weight: 600;
  margin-bottom: 8px;
  text-transform: capitalize;
`;

export const Input = styled.input<FormProps>`
  padding: 12px 8px;
  border: 2px solid
    ${({ $isInvalid }) => ($isInvalid ? 'red' : 'var(--color-primary-gray)')};
  border-radius: 6px;
  font-weight: 600;
  width: ${({ $width }) => $width};
  background: ${({ $backgroundColor }) => $backgroundColor};

  &::placeholder {
    color: var(--color-primary-gray);
  }

  &:focus {
    outline-color: ${({ $isInvalid }) => ($isInvalid ? 'red' : 'inherit')};
  }
`;
