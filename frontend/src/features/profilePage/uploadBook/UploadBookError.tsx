import { Error, ErrorIcon } from 'styles/index.ts';
import alertIcon from 'assets/alert.svg';

function UploadBookError({ error }: { error: string | string[] | undefined }) {
  return (
    <Error>
      <ErrorIcon src={alertIcon} alt="alert icon" />
      {error}
    </Error>
  );
}

export default UploadBookError;
