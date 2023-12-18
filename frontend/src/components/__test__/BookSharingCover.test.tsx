import { render } from '@testing-library/react';
import { describe, expect, it } from 'vitest';

import { BookSharingCover } from '..';

describe('BookSharingCover', () => {
  it('should render', () => {
    const { asFragment } = render(<BookSharingCover />);

    expect(asFragment()).toMatchSnapshot();
  });
});
