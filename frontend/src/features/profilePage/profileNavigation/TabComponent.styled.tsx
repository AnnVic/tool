import styled from 'styled-components';

export const StyledTabs = styled.div`
  display: flex;
  justify-content: flex-start;
  padding-top: 33px;
  font-size: 25px;
  margin-left: 50px;
  border-bottom: 1px solid var(--color-primary-medium);
  margin-bottom: 48px;
`;

export const StyledTab = styled.div`
  display: flex;
  justify-content: center;
  padding-right: 50px;
  text-decoration: none;

  .nav-link {
    padding: 15px 25px 15px 25px;
    text-decoration: none;
    color: var(--color-primary-dark);
  }

  .active {
    margin-bottom: -1px;
    border-bottom: 1px solid var(--color-primary-extra-light);
    border-top: 1px solid var(--color-primary-medium);
    border-right: 1px solid var(--color-primary-medium);
    border-left: 1px solid var(--color-primary-medium);
  }
`;