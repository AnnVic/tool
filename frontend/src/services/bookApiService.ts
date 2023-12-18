import { createApi } from '@reduxjs/toolkit/query/react';
import {
  AssignmentResponse,
  OptionType,
} from 'features/profilePage/uploadBook/customSelect/types.ts';
import { baseQuery } from 'services/baseApiService.ts';
import {
  AssingBookType,
  BookDetailsType,
} from 'features/profilePage/uploadBook/bookSlice.ts';
import { InitialValues } from 'features/profilePage/editBook/EditBook.tsx';

export const bookApi = createApi({
  reducerPath: 'bookApi',
  baseQuery: baseQuery,
  tagTypes: ['Authors', 'DeleteBook', 'AssignBook', 'UpdateBook', 'UploadBook'],
  endpoints: (builder) => ({
    postBook: builder.mutation({
      query: (book) => ({
        url: '/api/Books',
        method: 'POST',
        body: book,
      }),
      invalidatesTags: ['UploadBook'],
    }),
    putBook: builder.mutation({
      query: (book: InitialValues) => ({
        url: '/api/Books',
        method: 'PUT',
        body: book,
      }),
      invalidatesTags: ['UpdateBook'],
    }),
    postAuthors: builder.mutation({
      query: (author) => ({
        url: '/Authors',
        method: 'POST',
        body: author,
      }),
      invalidatesTags: ['Authors'],
    }),
    getGenres: builder.query<OptionType[], void>({
      query: () => '/Genres',
    }),
    getAuthors: builder.query<OptionType[], void>({
      query: () => '/Authors',
      providesTags: ['Authors'],
    }),
    getBooks: builder.query({
      query: ({ page, search, genres, status }) => {
        const searchParams = new URLSearchParams();
        searchParams.append('page', page);
        search && searchParams.append('search', search);
        status && searchParams.append('availabilityStatus', status);
        genres &&
          genres.forEach((genre: string) => {
            searchParams.append('genreNames', genre);
          });

        return `/api/Books?${searchParams.toString()}`;
      },
      providesTags: ['DeleteBook', 'UploadBook'],
    }),
    getMyBooks: builder.query({
      query: (page) => `/api/Books/user-books?page=${page}`,
    }),
    getBookById: builder.query<BookDetailsType, string>({
      query: (id) => `/api/Books/BookDetails?id=${id}`,
      providesTags: ['UpdateBook', 'AssignBook'],
    }),
    getAssignments: builder.query<AssignmentResponse[], void>({
      query: () => '/api/Assignment/user-assignments',
      providesTags: ['AssignBook'],
    }),
    postAssignBook: builder.mutation<void, AssingBookType>({
      query: (bookId) => ({
        url: '/api/Assignment/assign-to-me',
        method: 'POST',
        body: bookId,
      }),
      invalidatesTags: ['AssignBook'],
    }),
    deleteBook: builder.mutation({
      query: (id) => ({
        url: `/api/Books?id=${id}`,
        method: 'DELETE',
      }),
      invalidatesTags: ['DeleteBook'],
    }),
  }),
});

export const {
  usePostBookMutation,
  usePostAuthorsMutation,
  useGetGenresQuery,
  useGetAuthorsQuery,
  useGetBooksQuery,
  useGetMyBooksQuery,
  useGetBookByIdQuery,
  useGetAssignmentsQuery,
  usePostAssignBookMutation,
  useDeleteBookMutation,
  usePutBookMutation,
  reducer,
  reducerPath,
  middleware: bookMiddleware,
} = bookApi;
