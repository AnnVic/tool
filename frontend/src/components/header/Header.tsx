import { Link } from 'react-router-dom';
import { useEffect, useRef, useState } from 'react';

import { EndavaLogo, Flex } from 'styles/index.ts';
import HeaderDropdown from 'components/header/HeaderDropdown.tsx';
import {
  DropdownWrapper,
  MenuItem,
  NavbarContainer,
} from 'components/header/Header.styled.tsx';
import { useAppSelector } from 'store/storeHooks.ts';
import { selectUsername } from 'features/login/loginSlice.ts';

function Header() {
  const username = useAppSelector(selectUsername);
  const [showDropDown, setShowDropDown] = useState<boolean>(false);
  const menuRef = useRef<null | HTMLDivElement>(null);

  useEffect(() => {
    const handler = (event: FocusEvent) => {
      if (!menuRef.current?.contains(event.target as Node)) {
        setShowDropDown(false);
      }
    };

    document.addEventListener('mousedown', handler);

    return () => {
      document.removeEventListener('mousedown', handler);
    };
  });

  return (
    <NavbarContainer>
      <Flex $justifyContent="space-between" $alignItems="center">
        <Link to="/">
          <EndavaLogo height={50} />
        </Link>
        <Flex>
          <MenuItem>CATALOG</MenuItem>
          <MenuItem
            $position="relative"
            onClick={() => setShowDropDown(!showDropDown)}
            ref={menuRef}
          >
            {username?.toUpperCase() || 'USERNAME'}
          </MenuItem>
          <DropdownWrapper $active={showDropDown}>
            <HeaderDropdown />
          </DropdownWrapper>
        </Flex>
      </Flex>
    </NavbarContainer>
  );
}

export default Header;
