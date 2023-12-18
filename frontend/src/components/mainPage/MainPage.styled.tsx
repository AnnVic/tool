import styled from 'styled-components';

type MainPageContainerProps = {
  $gridTemplateColumns?: string;
  $padding?: string;
};

export const BooksContainer = styled.div<MainPageContainerProps>`
  padding: ${({ $padding }) => $padding};
  display: grid;
  width: 100%;
  grid-template-columns: ${({ $gridTemplateColumns }) => $gridTemplateColumns};
  gap: 96px;
`;

export const BooksListWrapper = styled.div`
  display: grid;
  grid-template-columns: repeat(4, 100px);
  gap: 64px;
  align-items: start;
`;
