import { ACTIONS } from 'components/mainPage/mainPageFilter/reducer/ACTIONS.tsx';

export enum STATUS {
  FREE = '0',
  BUSY = '1',
}

export type ActionFilter = {
  type: string;
  payload: string;
};

export type BookFilter = {
  search: string;
  genres: string[];
  status: string;
};

export const filterReducer = (filter: BookFilter, action: ActionFilter) => {
  switch (action.type) {
    case ACTIONS.SEARCH_BOOK:
      return { ...filter, search: action.payload };

    case ACTIONS.FILTER_GENRES: {
      const updatedGenres = toggleGenres(filter.genres, action.payload);
      return { ...filter, genres: updatedGenres };
    }

    case ACTIONS.FILTER_STATUS:
      return { ...filter, status: filter.status ? '' : action.payload };

    default:
      return filter;
  }
};

export const toggleGenres = (
  currentGenres: string[],
  selectedGenre: string,
): string[] => {
  const genres = [...currentGenres];

  if (genres.includes(selectedGenre)) {
    return genres.filter((genre) => genre !== selectedGenre);
  }
  return [...genres, selectedGenre];
};
