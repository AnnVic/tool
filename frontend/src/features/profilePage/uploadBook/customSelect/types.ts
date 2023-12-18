import React from 'react';

export type OptionType = {
  name: string;
};

export type CustomSelectProps = {
  placeholder: string;
  optionName: string;
  options: OptionType[] | undefined;
  value: string[] | string;
  onChange: (event: {
    target: { name: string; value: string | string[] };
  }) => void;
  onBlur: (event: React.ChangeEvent<EventTarget>) => void;
  touched: boolean | undefined;
  errors: string | string[] | undefined;
  isMulti: boolean;
  isRequired: boolean;
};
export type SelectOptionProps = {
  option: OptionType;
  toggleOption: (option: OptionType) => void;
  value: string | string[];
  isMulti: boolean;
  selected: boolean;
};
export type MultiValues = {
  value: string | string[];
};
export type SingleValue = {
  value: string;
};

export type AssignmentResponse = {
  title: string;
  startDate: string;
  endDate: string;
  status: number;
};
