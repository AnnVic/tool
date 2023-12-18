import styled from 'styled-components';

type ImageProps = {
  $height?: string;
  $width?: string;
  $objectFit?: string;
  $maxWidth?: string;
};

export const Image = styled.img<ImageProps>`
  height: ${({ $height }) => $height || '150px'};
  width: ${({ $width }) => $width || '100px'};
  object-fit: ${({ $objectFit }) => $objectFit || 'cover'};
  max-width: ${({ $maxWidth }) => $maxWidth};
`;

type BookDetailsContentProps = {
  $color?: string;
  $backGroundColor?: string;
};

export const BookDetailsContent = styled.div<BookDetailsContentProps>`
  display: flex;
  justify-content: center;
  color: ${({ $color }) => $color};
  background-color: ${({ $backGroundColor }) => $backGroundColor};
  border-radius: 5px;
  width: fit-content;
  padding: 7px;
`;
