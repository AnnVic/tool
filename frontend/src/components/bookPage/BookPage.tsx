import { BooksContainer } from 'components/mainPage/MainPage.styled';
import { Button, Flex } from 'styles/index.ts';
import { Container } from 'components/styles/Container.styled';
import EditBook from 'features/profilePage/editBook/EditBook.tsx';
import { IMG_URL } from 'services/baseApiService';
import {
  BookDetailsContent,
  Image,
} from 'components/mainPage/bookItem/BookItem.styled.tsx';
import { useNavigate, useParams } from 'react-router-dom';
import {
  useDeleteBookMutation,
  useGetBookByIdQuery,
  usePostAssignBookMutation,
} from 'services/bookApiService';
import {
  ModalWindow,
  ModalWindowClose,
  ModalWindowContent,
} from 'components/styles/ModalWindow.styled';
import { useAppSelector } from 'store/storeHooks';
import { selectUsername } from 'features/login/loginSlice';
import { Spinner } from 'components/styles';
import { useEffect } from 'react';
import { toast } from 'react-toastify';
import { HoverMessage, HoverMessageContainer } from 'styles/HoverMessage.tsx';

const transformLanguage = (language: number): string => {
  return language === 1 ? 'English' : language === 2 ? 'Romanian' : 'Russian';
};

function BookPage() {
  const navigate = useNavigate();
  const currentUserName = useAppSelector(selectUsername);
  const { id } = useParams();
  const {
    data: bookDetails,
    isError: isErrorBookDetails,
    isSuccess: isSuccessBookDetails,
    isLoading: isLoadingBookDetails,
    isFetching: isFetchingBookDetails,
  } = useGetBookByIdQuery(id as string);

  const [
    deleteBook,
    { isSuccess: isSuccessDeleteBook, isError: isErrorDeleterBook },
  ] = useDeleteBookMutation();

  const [assignBook] = usePostAssignBookMutation();

  useEffect(() => {
    if (isSuccessDeleteBook) {
      toast.success('Book was deleted successfully');
      setTimeout(() => {
        navigate('/');
      }, 200);
    }
    if (isErrorDeleterBook) {
      toast.error('Error during deleting book');
    }
  }, [isSuccessDeleteBook, isErrorDeleterBook]);

  function onDelete(id: string) {
    deleteBook(id);
    navigate('/');
  }

  function getLanguage(languageValue: number | string): number | string {
    if (typeof languageValue === 'string' && !Number.isNaN(languageValue)) {
      return languageValue;
    }
    return transformLanguage(languageValue as number);
  }

  return (
    <BooksContainer $padding="30px">
      {isLoadingBookDetails || isFetchingBookDetails ? (
        <Spinner />
      ) : isSuccessBookDetails ? (
        <div>
          <Flex $justifyContent="center" $gap="100px">
            <Flex $width="70%" $gap="50px" $justifyContent="center">
              <Flex
                $width="33%"
                $justifyContent="center"
                direction="column"
                $gap="50px"
              >
                <Image
                  $height="350px"
                  $width="100%"
                  $objectFit="contain"
                  src={`${IMG_URL}${bookDetails.imageFile}`}
                  alt={bookDetails.title}
                />
                <Flex $justifyContent="center" $gap="50px">
                  <HoverMessageContainer>
                    <Button
                      $minWidth="1px"
                      disabled={!bookDetails.isAssignButtonActive}
                      type="submit"
                      onClick={() => assignBook({ bookId: Number(id) })}
                    >
                      Assign book
                    </Button>

                    {!bookDetails.isAssignButtonActive &&
                    bookDetails.availabilityStatus === 0 ? (
                      <HoverMessage
                        $visibility={!bookDetails.isAssignButtonActive}
                      >
                        You should have less than 2 active assignments or less
                        than 1 pending assignment
                      </HoverMessage>
                    ) : bookDetails.availabilityStatus === 1 ? (
                      <HoverMessage
                        $visibility={bookDetails.availabilityStatus === 1}
                      >
                        The book is already assigned by a user for the current
                        period of time.
                      </HoverMessage>
                    ) : (
                      <span></span>
                    )}
                  </HoverMessageContainer>
                </Flex>
                <Container>
                  <Flex $justifyContent="center" $gap="50px">
                    <Button
                      $minWidth="120px"
                      hidden={currentUserName !== bookDetails.uploaderUsername}
                      onClick={() => (location.href = '#delete-modal')}
                    >
                      Delete
                    </Button>
                    <Button
                      $minWidth="120px"
                      hidden={currentUserName !== bookDetails.uploaderUsername}
                      onClick={() => (location.href = '#edit-modal')}
                    >
                      Edit
                    </Button>
                  </Flex>
                </Container>
              </Flex>
              <Flex $gap="50px" $width="33%" direction="column">
                <h1>{bookDetails.title}</h1>
                <Flex direction="column" $gap="7px">
                  <h3>Authors:</h3>
                  <ul>
                    {bookDetails.authors.map((auther, index) => {
                      return <ol key={index}>{auther}</ol>;
                    })}
                  </ul>
                </Flex>
                <Flex direction="column" $gap="7px">
                  <h3>Genres:</h3>
                  {bookDetails.genres.map((genre, index) => {
                    return (
                      <BookDetailsContent
                        $color="var(--color-white)"
                        $backGroundColor="var(--color-primary-dark)"
                        key={index}
                      >
                        {genre}
                      </BookDetailsContent>
                    );
                  })}
                </Flex>
              </Flex>
              <Flex
                $width="33%"
                $justifyContent="space-evenly"
                direction="column"
              >
                <Flex direction="column" $gap="7px">
                  <h3>Updated By</h3>
                  <BookDetailsContent>
                    {bookDetails.uploaderUsername}
                  </BookDetailsContent>
                </Flex>
                <Flex direction="column" $gap="7px">
                  <h3>Publication Date</h3>
                  <BookDetailsContent>
                    {new Date(bookDetails.publicationDate).toLocaleDateString(
                      'en-US',
                    )}
                  </BookDetailsContent>
                </Flex>
                <Flex direction="column" $gap="7px">
                  <h3>Language</h3>
                  <BookDetailsContent>
                    {getLanguage(bookDetails.language)}
                  </BookDetailsContent>
                </Flex>
              </Flex>
            </Flex>
          </Flex>
          <ModalWindow id="edit-modal">
            <ModalWindowContent>
              <h1>Edit Book</h1>
              <EditBook
                id={id ? id : ''}
                authors={bookDetails.authors.map((author) => author)}
                genres={bookDetails.genres.map((genre) => genre)}
                title={bookDetails.title}
                language={getLanguage(bookDetails.language)}
                date={bookDetails.publicationDate}
              />
              <ModalWindowClose href="#">&times;</ModalWindowClose>
            </ModalWindowContent>
          </ModalWindow>
          <ModalWindow id="delete-modal" className="modal">
            <ModalWindowContent>
              <Flex direction="column" $justifyContent="center" $gap="15px">
                <h3>Do you want delete this book?</h3>
                <Flex $justifyContent="center" $gap="15px">
                  <Button
                    onClick={() => {
                      onDelete(id as string);
                    }}
                  >
                    Yes
                  </Button>
                  <Button onClick={() => (location.href = '#')}>No</Button>
                </Flex>
                <ModalWindowClose href="#">&times;</ModalWindowClose>
              </Flex>
            </ModalWindowContent>
          </ModalWindow>
        </div>
      ) : (
        isErrorBookDetails && (
          <Flex $justifyContent="center" $gap="100px">
            Failed to get data
          </Flex>
        )
      )}
    </BooksContainer>
  );
}

export default BookPage;
