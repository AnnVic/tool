import * as yup from 'yup';

export const editBookSchema = yup.object().shape({
  title: yup
    .string()
    .min(1, 'Title must be at least 1 character')
    .max(70, 'Title must not exceed 70 characters')
    .matches(
      /^[a-zA-Z0-9\s.,?!:;-{}[\]()'"…]+$/,
      'Only alphanumeric characters and allowed punctuation marks are allowed.',
    )
    .required('Title is required'),
  authors: yup.array().notRequired(),
  genres: yup
    .array()
    .min(1, 'Genres are required')
    .required('Genres are required'),
  language: yup.string().required('Language is required'),
  date: yup.string().required('Publication Date is required'),
  newAuthor: yup
    .string()
    .min(7, 'Author must be at least 7 characters')
    .max(61, 'Author must not exceed 61 characters')
    .notRequired(),
});
