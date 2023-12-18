import styled from 'styled-components';

type FlexProps = {
  direction?: 'row' | 'column';
  $justifyContent?: string;
  $width?: string;
  $gap?: string;
  $alignItems?: 'center';
};

export const Flex = styled.div<FlexProps>`
  display: flex;
  flex-direction: ${({ direction }) => direction || 'row'};
  justify-content: ${({ $justifyContent }) => $justifyContent || 'flex-start'};
  width: ${({ $width }) => $width};
  gap: ${({ $gap }) => $gap};
  align-items: ${({ $alignItems }) => $alignItems};
`;
