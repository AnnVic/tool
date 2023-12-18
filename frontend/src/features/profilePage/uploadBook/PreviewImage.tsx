import { useEffect, useState } from 'react';
import { Image } from './PreviewImage.styled.ts';
import { Flex } from 'styles/index.ts';

function PreviewImage({ file }: { file: File }) {
  const [preview, setPreview] = useState<string | undefined>();

  useEffect(() => {
    if (Object.entries(file).length === 0) {
      setPreview(URL.createObjectURL(file));
    }
  }, [file]);

  return (
    <Flex $justifyContent="center">
      <Image src={preview} alt="cover-image" />
    </Flex>
  );
}

export default PreviewImage;
