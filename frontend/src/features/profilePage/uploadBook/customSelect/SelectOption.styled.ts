import styled from 'styled-components';

type OptionProps = {
  $isActive: boolean;
};
export const OptionContainer = styled.li<OptionProps>`
  width: 100%;
  list-style: none;
  background-color: ${({ $isActive }) =>
    $isActive ? 'var(--color-primary-light)' : 'inherit'};

  &:hover {
    background-color: var(--color-primary-light);
  }

  span {
    padding: 8px 8px;
    display: block;
    cursor: pointer;
    width: 100%;
  }
`;
