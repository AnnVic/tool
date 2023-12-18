import styled from 'styled-components';

type DropdownItemProps = {
  $borderTop?: boolean;
  $noPaddingTop?: boolean;
};

export const DropdownContainer = styled.div`
  background-color: var(--color-white);
  position: absolute;
  top: 70px;
  right: 50px;
  width: 200px;
  border: solid 1px var(--color-primary-gray);

  .link {
    text-decoration: none;
  }
`;

export const DropdownItem = styled.p<DropdownItemProps>`
  color: var(--color-primary-dark);
  text-align: start;
  border-top: ${({ $borderTop }) =>
    $borderTop ? 'solid 1px var(--color-primary-gray)' : ''};
  padding: ${({ $noPaddingTop }) =>
    $noPaddingTop ? '0px 24px 24px 24px' : '24px'};
  transition: var(--transition-quickly);
  cursor: pointer;

  &:hover {
    color: var(--color-primary-gray);
  }
`;
