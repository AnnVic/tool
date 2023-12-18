import PersonalProfileCover from 'features/profilePage/personalProfile/PesonalProfileCover.tsx';
import { ProfileContainer } from 'features/profilePage/personalProfile/PersonalProfileCover.styled.tsx';

function PersonalProfile() {
  return (
    <>
      <ProfileContainer>
        <PersonalProfileCover />
      </ProfileContainer>
    </>
  );
}

export default PersonalProfile;
