import { NavLink, Outlet } from 'react-router-dom';
import { StyledTab, StyledTabs } from './TabComponent.styled.tsx';

function TabComponent() {
  return (
    <div>
      <StyledTabs>
        <StyledTab>
          <NavLink className="nav-link" to="/profilePage/myProfile">
            My profile
          </NavLink>
        </StyledTab>
        <StyledTab>
          <NavLink className="nav-link" to="/profilePage/myBooks">
            My books
          </NavLink>
        </StyledTab>
        <StyledTab>
          <NavLink className="nav-link" to="/profilePage/myAssignments">
            My Assignments
          </NavLink>
        </StyledTab>
        <StyledTab>
          <NavLink className="nav-link" to="/profilePage/uploadBook">
            Upload Book
          </NavLink>
        </StyledTab>
      </StyledTabs>
      <Outlet />
    </div>
  );
}

export default TabComponent;
