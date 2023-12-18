import { InitialValues } from 'features/profilePage/editBook/EditBook.tsx';
import { transformAuthors } from 'features/profilePage/uploadBook/uploadBookRequest.ts';

export const transformLanguage = (language: string) => {
  let transformedLanguage = 0;
  language === 'English' && (transformedLanguage = 1);
  language === 'Romanian' && (transformedLanguage = 2);
  language === 'Russian' && (transformedLanguage = 3);

  return transformedLanguage;
};
export const editBook = (values: InitialValues) => {
  const uploadBookForm = { ...values };
  uploadBookForm.language = transformLanguage('' + values.language);
  uploadBookForm.authors = transformAuthors(values.authors, values.newAuthor);

  return uploadBookForm;
};
