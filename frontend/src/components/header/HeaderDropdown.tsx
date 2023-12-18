import {
  DropdownContainer,
  DropdownItem,
} from 'components/header/HeaderDropdown.styled.tsx';
import { Flex } from 'styles/index.ts';
import { useAppDispatch } from 'store/storeHooks.ts';
import { unsetCredentials } from 'features/login/loginSlice.ts';
import { toast } from 'react-toastify';
import { Link } from 'react-router-dom';

function HeaderDropdown() {
  const dispatch = useAppDispatch();
  const handleLogout = () => {
    dispatch(unsetCredentials());
    toast.success('Logout successful. Time to rejoin humanity!');
  };
  return (
    <DropdownContainer>
      <Flex direction="column">
        <Link className="link" to="/profilePage/myProfile">
          <DropdownItem>My profile</DropdownItem>
        </Link>
        <DropdownItem $noPaddingTop={true}>Admin</DropdownItem>
        <DropdownItem $borderTop={true} onClick={handleLogout}>
          Log out
        </DropdownItem>
      </Flex>
    </DropdownContainer>
  );
}

export default HeaderDropdown;
