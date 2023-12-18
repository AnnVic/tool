import styled from 'styled-components';

type Props = {
  $isActive: boolean;
};

export const BookAssignmentsWrappper = styled.div`
  padding: 0 48px 48px 48px;
`;
export const Table = styled.table`
  width: 100%;
  border-collapse: collapse;

  th {
    padding-bottom: 24px;
    border-bottom: 1px solid var(--color-primary-light);
    text-align: start;
  }

  td {
    padding: 24px 0;
    border-bottom: 1px solid var(--color-primary-light);
    text-align: start;
    width: 15vw;

    &:first-of-type {
      width: 30vw;
    }
  }
`;

export const Status = styled.div<Props>`
  cursor: pointer;
  background-color: ${({ $isActive }) =>
    $isActive ? ' var(--color-success-medium)' : 'var(--color-warning-medium)'};
  padding: 12px 8px;
  text-align: center;
  font-weight: 500;
  color: var(--color-white);
  width: 100px;
`;
