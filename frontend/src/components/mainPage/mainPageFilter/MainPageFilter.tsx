import React from 'react';

import { Flex } from 'styles/index.ts';
import {
  FilterSection,
  FilterTitle,
} from 'components/mainPage/mainPageFilter/MainPageFilter.styled.tsx';
import { ACTIONS } from 'components/mainPage/mainPageFilter/reducer/ACTIONS.tsx';
import { useGetGenresQuery } from 'services/bookApiService.ts';
import {
  ActionFilter,
  BookFilter,
  STATUS,
} from 'components/mainPage/mainPageFilter/reducer/filterReducer.ts';

type Dispatch<A> = (value: A) => void;

export type FilterContextProps = {
  filter: BookFilter;
  dispatch: Dispatch<ActionFilter>;
};

function MainPageFilter({ filter, dispatch }: FilterContextProps) {
  const { data: genres } = useGetGenresQuery();

  const handleSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    dispatch({
      type: ACTIONS.SEARCH_BOOK,
      payload: event.target.value,
    });
  };

  const handleFilterGenres = (genre: string) => {
    dispatch({
      type: ACTIONS.FILTER_GENRES,
      payload: genre,
    });
  };

  const handleFilterStatus = (status: string) => {
    dispatch({
      type: ACTIONS.FILTER_STATUS,
      payload: status,
    });
  };

  return (
    <FilterSection>
      <Flex direction="column" $gap="24px">
        <div>
          <form onSubmit={(event) => event.preventDefault()}>
            <div className="input_wrapper">
              <input
                type="search"
                placeholder="Search"
                value={filter.search}
                onChange={(event) => handleSearch(event)}
              />
            </div>
          </form>
        </div>
        <div>
          <FilterTitle $paddingBottom={12}>Genres</FilterTitle>
          <Flex $gap="4px" direction="column">
            {genres?.map((genre) => (
              <div key={genre.name}>
                <input
                  type="checkbox"
                  onClick={() => handleFilterGenres(genre.name)}
                />
                <label>{genre.name}</label>
              </div>
            ))}
          </Flex>
        </div>
        <div>
          <FilterTitle $paddingBottom={12}>Status</FilterTitle>
          <Flex $gap="4px" direction="column">
            <div>
              <input
                type="checkbox"
                onClick={() => handleFilterStatus(STATUS.FREE)}
              />
              <label>Free</label>
            </div>
            <div>
              <input
                type="checkbox"
                onClick={() => handleFilterStatus(STATUS.BUSY)}
              />
              <label>Busy</label>
            </div>
          </Flex>
        </div>
      </Flex>
    </FilterSection>
  );
}

export default MainPageFilter;
