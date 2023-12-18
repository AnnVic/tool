import { useEffect, useState } from 'react';

import { useAppDispatch } from 'store/storeHooks.ts';
import {
  BooksListWrapper,
  BooksContainer,
} from 'components/mainPage/MainPage.styled.tsx';
import { useGetMyBooksQuery } from 'services/bookApiService.ts';
import { Flex, Spinner } from 'components/styles';
import BookItem from 'components/mainPage/bookItem/BookItem.tsx';
import Pagination from 'components/mainPage/pagination/Pagination.tsx';
import {
  BookType,
  setBooks,
} from 'features/profilePage/uploadBook/bookSlice.ts';

function MyBooksPage() {
  const dispatch = useAppDispatch();
  const [currentPage, setCurrentPage] = useState<number>(1);

  const {
    data: books,
    isFetching,
    isLoading,
    isSuccess,
    isError,
  } = useGetMyBooksQuery(currentPage);

  useEffect(() => {
    if (isSuccess) {
      dispatch(
        setBooks({
          books,
        }),
      );
    }
  }, [isSuccess, dispatch, books]);

  return (
    <BooksContainer $padding="96px">
      {(isFetching && isLoading) || isFetching ? (
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
    </BooksContainer>
  );
}

export default MyBooksPage;
