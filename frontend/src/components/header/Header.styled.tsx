import styled from 'styled-components';

type MenuItemsProps = {
  $position?: 'relative';
  $paddingRight?: number;
};
type DropdownWrapperProps = {
  $active: boolean;
};
export const NavbarContainer = styled.div`
  background-color: var(--color-primary-dark);
  padding: 24px 48px;
`;
export const MenuItem = styled.div<MenuItemsProps>`
  color: var(--color-primary-gray);
  background-color: transparent;
  border: none;
  font-size: 20px;
  position: ${({ $position }) => $position || ''};
  transition: var(--transition-quickly);
  cursor: pointer;
  width: 200px;
  text-align: start;

  &:hover {
    color: var(--color-white);
  }
`;
export const DropdownWrapper = styled.div<DropdownWrapperProps>`
  opacity: ${({ $active }) => ($active ? '100' : '0')};
  visibility: ${({ $active }) => ($active ? 'visible' : 'hidden')};
  transition: var(--transition-quickly);
`;
