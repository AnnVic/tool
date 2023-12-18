import styled from 'styled-components';

export const Error = styled.p`
  color: var(--color-danger-medium);
  font-size: 14px;
  margin-top: 4px;
  display: flex;
  align-items: center;
`;

export const ErrorIcon = styled.img`
  margin-right: 5px;
  height: 15px;
  width: 15px;
  font-size: 14px;

  svg {
    height: 15px;
  }
`;
