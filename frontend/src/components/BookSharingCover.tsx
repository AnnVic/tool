import { BookSharingCoverWrapper, EndavaLogo } from './styles';

export default function BookSharingCover() {
  return (
    <BookSharingCoverWrapper data-testid="book-sharing-cover-wrapper">
      <EndavaLogo />
      <h1>
        book <span>sharing</span>
      </h1>
    </BookSharingCoverWrapper>
  );
}
