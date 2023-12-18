import { styled } from 'styled-components';

type ContainerProps = {
  $width?: number;
};

export const Container = styled.div<ContainerProps>`
  max-width: ${({ $width }) => `${$width || 1000}px`};
  width: 100%;
  margin: 0 auto;
  padding: 0 32px;
`;

export const InputContainer = styled.div`
  display: flex;
  justify-content: space-between;
  gap: 50px;
  padding-top: 50px;
`;
