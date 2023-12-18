import styled from 'styled-components';

type InputProps = {
  $isInvalid: boolean;
  $width?: number;
};
export const UploadBookContainer = styled.div`
  padding:0 48px 48px 48px;
  display: grid;
  grid-template-columns: 1fr 2fr 2fr;
  gap: 64px;
`;

export const Input = styled.input<InputProps>`
  padding: 12px 8px;
  border: 2px solid
    ${({ $isInvalid }) => ($isInvalid ? 'red' : 'var(--color-primary-light)')};
  font-weight: 500;
  font-size: 14px;
  width: ${({ $width }) => `${$width}%` || '100%'};

  &::placeholder {
    color: var(--color-primary-gray);
  }

  &:focus {
    outline-color: ${({ $isInvalid }) => ($isInvalid ? 'red' : 'inherit')};
  }
`;