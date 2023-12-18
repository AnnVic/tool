import styled from 'styled-components';

type BlockProps = {
  direction?: 'row' | 'column';
  $justifyContent?: string;
  $width?: string;
  $gap?: string;
  $alignItems?: 'center';
};

export const Block = styled.div<BlockProps>`
  display: block;
  width: 100%;
  max-width: 200px;
  margin: auto;
  /* flex-direction: ${({ direction }) => direction || 'row'};
  justify-content: ${({ $justifyContent }) => $justifyContent || 'flex-start'};
  width: ${({ $width }) => $width};
  gap: ${({ $gap }) => $gap};
  align-items: ${({ $alignItems }) => $alignItems}; */
`;
