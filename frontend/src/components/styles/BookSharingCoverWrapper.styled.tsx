import styled from 'styled-components';

import endavaLogo from 'assets/endava-logo.png';

export const BookSharingCoverWrapper = styled.div`
  grid-area: title;
  place-items: center;
  display: grid;
  background-color: var(--color-primary-dark);
  color: var(--color-white);
  position: relative;
  text-transform: uppercase;

  img {
    height: 50px;
    position: absolute;
    top: 20px;
    left: 20px;
  }

  h1 {
    font-size: 3rem;
    display: grid;

    span {
      margin-left: 35px;
    }
  }
`;

export const EndavaLogo = styled.img.attrs({
  src: endavaLogo,
})``;
