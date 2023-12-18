import { ProfileContainer } from 'features/profilePage/personalProfile/PersonalProfileCover.styled.tsx';
import MyBooksPage from 'features/profilePage/myBooks/MyBooksPage.tsx';

function MyBooks() {
  return (
    <>
      <ProfileContainer>
        <MyBooksPage />
      </ProfileContainer>
    </>
  );
}

export default MyBooks;
