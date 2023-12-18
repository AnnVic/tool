import { useReducer, useState } from 'react';

import {
  BooksListWrapper,
  BooksContainer,
} from 'components/mainPage/MainPage.styled.tsx';
import { useGetBooksQuery } from 'services/bookApiService.ts';
import { Flex, Spinner } from 'components/styles';
import BookItem from 'components/mainPage/bookItem/BookItem.tsx';
import Pagination from 'components/mainPage/pagination/Pagination.tsx';
import { BookType } from 'features/profilePage/uploadBook/bookSlice.ts';
import MainPageFilter from 'components/mainPage/mainPageFilter/MainPageFilter.tsx';
import { filterReducer } from 'components/mainPage/mainPageFilter/reducer/filterReducer.ts';
import { filterInitialState } from 'components/mainPage/mainPageFilter/filterInitialState.ts';

function MainPage() {
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [filter, dispatch] = useReducer(filterReducer, filterInitialState);
  const search = filter.search.charAt(0).toUpperCase() + filter.search.slice(1);

  const {
    data: books,
    isFetching,
    isLoading,
    isSuccess,
    isError,
  } = useGetBooksQuery({
    page: currentPage,
    search,
    genres: filter.genres,
    status: Number(filter.status),
  });

  return (
    <BooksContainer $padding="96px" $gridTemplateColumns="3fr 1fr">
      {isLoading || isFetching ? (
        <Spinner />
      ) : isSuccess ? (
        <Flex
          direction="column"
          $gap="64px"
          $justifyContent="center"
          $alignItems="center"
        >
          {books.items.length === 0 ? (
            <p>No book found</p>
          ) : (
            <>
              <BooksListWrapper>
                {books.items.map((book: BookType, index: number) => (
                  <BookItem book={book} key={index} />
                ))}
              </BooksListWrapper>
              <Pagination
                totalPages={books.totalPages}
                currentPage={currentPage}
                setCurrentPage={setCurrentPage}
              />
            </>
          )}
        </Flex>
      ) : (
        isError && <p>Failed to get data</p>
      )}
      <MainPageFilter filter={filter} dispatch={dispatch} />
    </BooksContainer>
  );
}

export default MainPage;
