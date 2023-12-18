import { InitialValues } from 'features/profilePage/uploadBook/UpdateBook.tsx';

export const transformLanguage = (language: string) => {
  let transformedLanguage = '';
  language === 'English' && (transformedLanguage = '1');
  language === 'Romanian' && (transformedLanguage = '2');
  language === 'Russian' && (transformedLanguage = '3');

  return transformedLanguage;
};

export const transformAuthors = (
  authors: string[],
  newAuthor: string | undefined,
): string[] => {
  newAuthor && !authors && (authors = [newAuthor]);
  newAuthor && authors && (authors = [...authors, newAuthor]);

  return authors;
};

export const uploadNewAuthor = (author: string) => {
  const uploadNewAuthorForm = new FormData();
  uploadNewAuthorForm.append('Name', author);

  return uploadNewAuthorForm;
};

export const uploadBook = (values: InitialValues) => {
  const uploadBookForm = new FormData();
  values.image !== null && uploadBookForm.append('BookImage', values.image);
  uploadBookForm.append('Title', values.title);
  uploadBookForm.append('Language', transformLanguage(values.language));
  uploadBookForm.append('PublicationDate', values.publicationDate);

  const authors = transformAuthors(values.authors, values.newAuthor);
  authors.forEach((author) => uploadBookForm.append('AuthorNames', author));
  values.genres.forEach((genre) => uploadBookForm.append('GenreNames', genre));

  return uploadBookForm;
};
