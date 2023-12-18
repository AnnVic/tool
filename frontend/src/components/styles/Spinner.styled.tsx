import styled from 'styled-components';
import spinner from 'assets/spinner.svg';

export const Spinner = styled.img.attrs({
  src: spinner,
})`
  height: 50px;
  justify-self: center;
  align-self: center;
`;
