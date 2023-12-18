import styled from 'styled-components';

export const ModalWindow = styled.div`
  visibility: hidden;
  opacity: 0;
  position: absolute;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  display: flex;
  align-items: center;
  justify-content: center;
  background: rgba(255, 255, 255, 0.7);
  transition: all 0.4s;

  &:target {
    visibility: visible;
    opacity: 1;
  }
`;

export const ModalWindowContent = styled.div`
  border-radius: 4px;
  position: relative;
  width: inherit;
  max-width: 90%;
  background: var(--color-white);
  padding: 1em 2em;
  border: 3px solid var(--color-primary-medium);
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
`;

export const ModalWindowClose = styled.a`
  position: absolute;
  font-size: 32px;
  top: 10px;
  right: 20px;
  color: var(--color-primary-medium);
  text-decoration: none;
`;
