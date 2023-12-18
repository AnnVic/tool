import { useFormik } from 'formik';
import { Input } from '../uploadBook/UploadBook.styled.tsx';
import {
  useGetAuthorsQuery,
  useGetGenresQuery,
  usePostAuthorsMutation,
  usePutBookMutation,
} from 'services/bookApiService.ts';
import CustomSelect from 'features/profilePage/uploadBook/customSelect/CustomSelect.tsx';
import { languageOptions } from '../uploadBook/options.ts';
import { Button, Flex, Form, Label, Spinner } from 'styles/index.ts';
import ErrorComponent from '../uploadBook/ErrorComponent.tsx';
import { uploadNewAuthor } from 'features/profilePage/uploadBook/uploadBookRequest.ts';
import { EditBookContainer } from 'features/profilePage/editBook/EditBook.styled.tsx';
import { editBook } from 'features/profilePage/editBook/EditBookRequest.ts';
import { editBookSchema } from 'features/profilePage/editBook/editBookSchema.ts';

export type InitialValues = {
  id: string;
  title: string;
  authors: string[];
  genres: string[];
  language: string | number;
  date: string;
  newAuthor?: string;
};

function EditBook(bookContent: InitialValues) {
  const { handleSubmit, values, handleBlur, handleChange, errors, touched } =
    useFormik({
      initialValues: bookContent,
      onSubmit,
      validationSchema: editBookSchema,
    });

  const [putBook, { isLoading }] = usePutBookMutation();
  const [postAuthor] = usePostAuthorsMutation();
  const { data: genres } = useGetGenresQuery();
  const { data: authors } = useGetAuthorsQuery();

  function onSubmit(values: InitialValues) {
    values.newAuthor && postAuthor(uploadNewAuthor(values.newAuthor));
    putBook(editBook(values));
  }

  function onCancel() {
    location.href = '#';
  }

  return (
    <>
      <Form onSubmit={handleSubmit}>
        <EditBookContainer>
          <Flex direction="column" $gap="24px">
            <Flex direction="column">
              <Label>Title</Label>
              <Input
                $isInvalid={Boolean(
                  (!values.title && touched.title) ||
                    (touched.title && errors.title),
                )}
                name="title"
                type="text"
                value={values.title}
                placeholder="Select title"
                onChange={handleChange}
                onBlur={handleBlur}
              />
              {((!values.title && touched.title) ||
                (values.title && errors.title)) && (
                <ErrorComponent error={errors.title} />
              )}
            </Flex>

            <CustomSelect
              placeholder="Select authors"
              optionName="authors"
              options={authors}
              value={values.authors}
              onChange={handleChange}
              onBlur={handleBlur}
              touched={touched.authors}
              errors={errors.authors}
              isMulti={true}
              isRequired={false}
            />
            <CustomSelect
              placeholder="Select genres"
              optionName="genres"
              options={genres}
              value={values.genres}
              onChange={handleChange}
              onBlur={handleBlur}
              touched={touched.genres}
              errors={errors.genres}
              isMulti={true}
              isRequired={true}
            />
            <CustomSelect
              placeholder="Select language"
              optionName="language"
              options={languageOptions}
              value={'' + values.language}
              onChange={handleChange}
              onBlur={handleBlur}
              touched={touched.language}
              errors={errors.language}
              isMulti={false}
              isRequired={true}
            />
            <Flex direction="column">
              <Label>Publication Date</Label>
              <Input
                $isInvalid={Boolean(
                  (!values.date && touched.date) ||
                    (touched.date && errors.date),
                )}
                name="date"
                type="date"
                value={values.date.split('T')[0]}
                onChange={handleChange}
                onBlur={handleBlur}
              />
              {((!values.date && touched.date) ||
                (errors.date && touched.date)) && (
                <ErrorComponent error={errors.date} />
              )}
            </Flex>
          </Flex>
          <Flex direction="column" $gap="48px" $justifyContent="space-between">
            <Flex direction="column">
              <Label>New Author</Label>
              <Input
                $isInvalid={Boolean(errors.newAuthor)}
                name="newAuthor"
                type="text"
                value={values.newAuthor}
                placeholder="Select new author"
                onChange={handleChange}
              />
              {values.newAuthor && errors.newAuthor && (
                <ErrorComponent error={errors.newAuthor} />
              )}
            </Flex>
            <Flex $gap="48px">
              {isLoading ? (
                <Spinner />
              ) : (
                <Button
                  type="submit"
                  disabled={
                    JSON.stringify(values) === JSON.stringify(bookContent)
                  }
                >
                  Submit
                </Button>
              )}
              <Button type="button" onClick={onCancel}>
                Cancel
              </Button>
            </Flex>
          </Flex>
        </EditBookContainer>
      </Form>
    </>
  );
}

export default EditBook;
