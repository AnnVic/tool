import { Link } from 'react-router-dom';
import { Flex } from 'styles/index.ts';
import { Image } from 'components/mainPage/bookItem/BookItem.styled.tsx';
import { BookType } from 'features/profilePage/uploadBook/bookSlice.ts';
import { IMG_URL } from 'services/baseApiService.ts';

type BookItemProps = {
  book: BookType;
};

function BookItem({ book }: BookItemProps) {
  return (
    <Flex
      direction="column"
      $justifyContent="center"
      $alignItems="center"
      $gap="24px"
    >
      <Link to={`/book/${book.id}`}>
        <Image src={`${IMG_URL}${book.coverImage}`} alt={book.title} />
      </Link>
      <p>{book.title}</p>
    </Flex>
  );
}

export default BookItem;
