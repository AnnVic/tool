import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import { useFormik } from 'formik';
import { Input, UploadBookContainer } from './UploadBook.styled.tsx';
import {
  useGetAuthorsQuery,
  useGetGenresQuery,
  usePostAuthorsMutation,
  usePostBookMutation,
} from 'services/bookApiService.ts';
import { uploadBookSchema } from './uploadBookSchema.ts';
import CustomSelect from 'features/profilePage/uploadBook/customSelect/CustomSelect.tsx';
import PreviewImage from './PreviewImage.tsx';
import { languageOptions } from './options.ts';
import { Button, Flex, Form, Label, Spinner } from 'styles/index.ts';
import ErrorComponent from './ErrorComponent.tsx';
import {
  uploadBook,
  uploadNewAuthor,
} from 'features/profilePage/uploadBook/uploadBookRequest.ts';

export type InitialValues = {
  image: File | null;
  title: string;
  authors: string[];
  genres: string[];
  language: string;
  publicationDate: string;
  newAuthor: string;
};

const initialValues: InitialValues = {
  image: null,
  title: '',
  authors: [],
  genres: [],
  language: '',
  publicationDate: '',
  newAuthor: '',
};

function UpdateBook() {
  const navigate = useNavigate();
  const {
    handleSubmit,
    values,
    handleBlur,
    setFieldValue,
    handleChange,
    errors,
    touched,
  } = useFormik({
    initialValues,
    onSubmit,
    validationSchema: uploadBookSchema,
  });

  const [postBook, { isLoading, isSuccess, isError, data: book }] =
    usePostBookMutation();
  const [postAuthor] = usePostAuthorsMutation();
  const { data: genres } = useGetGenresQuery();
  const { data: authors } = useGetAuthorsQuery();

  useEffect(() => {
    if (book && isSuccess) {
      toast.success('Book added successfully');
      navigate('/profilePage/myBooks');
    } else if (isError) {
      toast.error('Something went wrong');
    }
  }, [values.image, book, isSuccess, isError, navigate]);

  function onSubmit(values: InitialValues) {
    values.newAuthor && postAuthor(uploadNewAuthor(values.newAuthor));
    postBook(uploadBook(values));
  }

  function onCancel() {
    toast.warning('Changes were aborted');
    navigate('/profilePage');
  }

  return (
    <>
      <Form onSubmit={handleSubmit}>
        <UploadBookContainer>
          <Flex direction="column">
            <Label>Cover Image</Label>
            <Input
              $isInvalid={Boolean(
                (!values.image && touched.image) ||
                  (values.image && errors.image),
              )}
              type="file"
              name="image"
              accept="image/png, image/jpeg, image/bmp"
              onChange={(event) =>
                setFieldValue('image', event.target.files?.[0])
              }
              onBlur={handleBlur}
            />
            {values.image && <PreviewImage file={values.image} />}
            {((!values.image && touched.image) ||
              (touched.image && errors.image)) && (
              <ErrorComponent error={errors.image} />
            )}
          </Flex>
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
              value={JSON.stringify(values.language)}
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
                $width={50}
                $isInvalid={Boolean(
                  (!values.publicationDate && touched.publicationDate) ||
                    (touched.publicationDate && errors.publicationDate),
                )}
                name="publicationDate"
                type="date"
                value={values.publicationDate}
                onChange={handleChange}
                onBlur={handleBlur}
              />
              {((!values.publicationDate && touched.publicationDate) ||
                (errors.publicationDate && touched.publicationDate)) && (
                <ErrorComponent error={errors.publicationDate} />
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
              {isLoading ? <Spinner /> : <Button type="submit">Submit</Button>}
              <Button onClick={onCancel}>Cancel</Button>
            </Flex>
          </Flex>
        </UploadBookContainer>
      </Form>
    </>
  );
}

export default UpdateBook;
