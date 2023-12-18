import styled from 'styled-components';

type ButtonProps = {
  $backgroundColor?: string;
  $color?: string;
  $onhoverBackgroundColor?: string;
  $onhoverColor?: string;
  $borderRadius?: string;
  $minWidth?: string;
};
export const Button = styled.button<ButtonProps>`
  background-color: ${({ $backgroundColor }) =>
    $backgroundColor || 'var(--color-primary-dark)'};
  color: ${({ $color }) => $color || 'var(--color-white)'};
  padding: 12px 8px;
  border-radius: ${({ $borderRadius }) => $borderRadius || '6px'};
  font-weight: 500;
  min-width: ${({ $minWidth }) => $minWidth || '200px'};
  font-size: inherit;
  cursor: pointer;
  outline: none;
  border: none;
  transition: background-color 0.2s ease-in-out;

  &:not(:disabled):hover {
    background-color: ${({ $onhoverBackgroundColor }) =>
      $onhoverBackgroundColor || 'var(--color-primary-medium)'};
    color: ${({ $onhoverColor }) => $onhoverColor || 'var(--color-white)'};
  }
`;
