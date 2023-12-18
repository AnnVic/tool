import styled from 'styled-components';

type Props = {
  $current?: boolean;
};

export const Button = styled.button<Props>`
  background-color: ${({ $current }) =>
    $current ? 'var(--color-primary-gray)' : 'var(--color-primary-light)'};
  border: none;
  cursor: pointer;
  transition: var(--transition-quickly);
  font-size: 16px;
  display: flex;
  justify-content: center;
  align-items: center;
  width: 30px;
  height: 30px;

  &:hover {
    background-color: var(--color-primary-gray);
  }
`;
