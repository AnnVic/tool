import { Field, useField } from 'formik';
import { Input } from 'styles/index.ts';
import { Error } from 'styles/index.ts';

type TextFieldProps = {
  name: string;
  fieldType: string;
  isChanged?: boolean;
};

export const TextField: React.FC<TextFieldProps> = ({
  name,
  fieldType,
  isChanged,
}) => {
  const [, meta] = useField(name);

  return (
    <>
      <Field
        as={Input}
        $backgroundColor={
          (meta.touched && isChanged) || 'var(--color-primary-light)'
        }
        $hasError={meta.touched && Boolean(meta.error)}
        name={name}
        id={name}
        type={fieldType}
      />
      {meta.touched && meta.error && <Error>{meta.error}</Error>}
    </>
  );
};
