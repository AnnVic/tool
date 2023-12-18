import styled from 'styled-components';

type Props = {
  $visibility: boolean;
};

export const HoverMessageContainer = styled.div`
  position: relative;
`;

export const HoverMessage = styled.p<Props>`
  position: absolute;
  bottom: 60px;
  left: -40px;
  width: 200px;
  text-align: center;
  background-color: var(--color-white);
  border-radius: 4px;
  box-shadow: rgba(0, 0, 0, 0.1) 0 4px 12px;
  padding: 8px;
  visibility: hidden;
  transition: var(--transition-quickly);
  opacity: 0;

  &:hover {
    visibility: ${({ $visibility }) => ($visibility ? 'visible' : 'hidden')};
    opacity: ${({ $visibility }) => ($visibility ? '1' : '0')};
  }

  ${HoverMessageContainer}:hover & {
    visibility: ${({ $visibility }) => ($visibility ? 'visible' : 'hidden')};
    opacity: ${({ $visibility }) => ($visibility ? '1' : '0')};
  }
`;