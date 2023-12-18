import { Link, Navigate, Route, Routes } from 'react-router-dom';

import { ProtectedRoute } from 'components/index';
import Login from 'features/login/Login';
import BookPage from 'components/bookPage/BookPage.tsx';
import MainPage from 'components/mainPage/MainPage.tsx';
import Header from 'components/header/Header.tsx';
import UpdateBook from 'features/profilePage/uploadBook/UpdateBook.tsx';
import TabComponent from 'features/profilePage/profileNavigation/TabComponent.tsx';
import SignUp from 'features/signup/SignUp.tsx';
import PersonalProfile from 'features/profilePage/personalProfile/PersonalProfile';
import MyBooks from 'features/profilePage/myBooks/MyBooks.tsx';
import BookAssignmets from 'features/profilePage/assignments/BookAssignmets.tsx';

function App() {
  return (
    <Routes>
      <Route
        path="*"
        element={
          <ProtectedRoute>
            <Header />
            <Routes>
              <Route path="/" element={<MainPage />} />
              <Route path="/book/:id" element={<BookPage />} />
              <Route path="/profilePage" element={<TabComponent />}>
                <Route
                  path="/profilePage"
                  element={<Navigate to="/profilePage/myProfile" />}
                ></Route>
                <Route
                  path="/profilePage/*"
                  element={<Navigate to="/profilePage/myProfile" />}
                ></Route>
                <Route
                  path="/profilePage/myProfile"
                  index
                  element={<PersonalProfile />}
                />
                <Route
                  path="/profilePage/myBooks"
                  index
                  element={<MyBooks />}
                />
                <Route
                  path="/profilePage/myAssignments"
                  index
                  element={<BookAssignmets />}
                />
                <Route
                  path="/profilePage/uploadBook"
                  element={<UpdateBook />}
                />
              </Route>
            </Routes>
          </ProtectedRoute>
        }
      />
      <Route path="/login" element={<Login />} />
      <Route path="/signup" element={<SignUp />} />
      <Route
        path="/forgot-password"
        element={
          <h1>
            Forgot password page
            <Link to="/login">Back to login</Link>
          </h1>
        }
      />
    </Routes>
  );
}

export default App;
