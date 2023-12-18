import styled from 'styled-components';

type MainPageFilterProps = {
  $paddingBottom?: number;
};

export const FilterSection = styled.div<MainPageFilterProps>`
  label {
    color: var(--color-primary-medium);
    margin-left: 8px;
  }

  input {
    border: none;
    background-color: var(--color-primary-extra-light);
    padding: 12px;
  }
`;

export const FilterTitle = styled.div<MainPageFilterProps>`
  color: var(--color-primary-medium);
  padding-bottom: ${({ $paddingBottom }) => `${$paddingBottom}px` || 0};
  font-weight: 600;
`;
