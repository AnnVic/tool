import { useEffect, useState } from 'react';
import { SelectOptionProps } from './types.ts';
import { OptionContainer } from './SelectOption.styled.ts';

function SelectOption({
  option,
  toggleOption,
  value,
  isMulti,
    selected
}: SelectOptionProps) {
  const [isSelected, setIsSelected] = useState<boolean>(selected);

  useEffect(() => {
    if (!isMulti) {
      setIsSelected(() => value === option.name);
    }
  }, [isMulti, value, option.name]);

  const toggleMouseDown = () => {
    if (isMulti) {
      setIsSelected((selected) => !selected);
    }
    toggleOption({ name: option.name });
  };

  return (
    <OptionContainer
      $isActive={Boolean(isSelected)}
      key={option.name}
      onMouseDown={toggleMouseDown}
    >
      <span>{option.name}</span>
    </OptionContainer>
  );
}

export default SelectOption;
