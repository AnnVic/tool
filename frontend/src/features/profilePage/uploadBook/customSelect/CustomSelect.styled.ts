import styled from 'styled-components';

type SelectProps = {
  $isInvalid?: boolean;
};
type OptionsProps = {
  $isActive: boolean;
  $isInvalid?: boolean;
};

export const CustomSelectContainer = styled.div`
  position: relative;
  cursor: pointer;

  .icon {
    position: absolute;
    right: 8px;
  }
`;
export const SelectOptions = styled.input<SelectProps>`
  width: 100%;
  padding: 12px 8px;
  border: 2px solid
    ${({ $isInvalid }) => ($isInvalid ? 'red' : 'var(--color-primary-light)')};
  font-weight: 400;
  font-size: 14px;
  outline: none;
  cursor: pointer;

  &::placeholder {
    color: var(--color-primary-gray);
    text-transform: capitalize;
  }

  span {
    color: var(--color-primary-extra-light);
  }

  &:focus {
    outline-color: ${({ $isInvalid }) => ($isInvalid ? 'red' : 'inherit')};
  }

  &:hover {
    background-color: var(--color-primary-light);
  }
`;
export const OptionsContainer = styled.ul<OptionsProps>`
  z-index: 1;
  width: 100%;
  position: absolute;
  background-color: white;
  border: 2px solid
    ${({ $isInvalid }) => ($isInvalid ? 'red' : 'var(--color-primary-light)')};
  border-top: none;
  display: ${({ $isActive }) => ($isActive ? 'block' : 'none')};
  max-height: 132px;
  overflow: scroll;
  overflow-x: hidden;

  &::-webkit-scrollbar {
    display: none;
  }
`;
