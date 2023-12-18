import { Flex } from 'components/styles';
import { Button } from 'components/mainPage/pagination/Pagination.styled.tsx';
import { FiChevronsLeft, FiChevronsRight } from 'react-icons/fi';
import { scrollToTop } from 'utils/ScrollToTop.ts';

type PaginationProps = {
  totalPages: number;
  currentPage: number;
  setCurrentPage: (page: number) => void;
};

function Pagination({
  totalPages,
  currentPage,
  setCurrentPage,
}: PaginationProps) {
  const pageNumbers = Array.from(
    { length: totalPages },
    (_, index) => index + 1,
  );

  const clickPrevPage = () => {
    setCurrentPage(currentPage - 1);
    scrollToTop();
  };

  const clickPage = (pageNumber: number) => {
    setCurrentPage(pageNumber);
    scrollToTop();
  };

  const clickNextPage = () => {
    setCurrentPage(currentPage + 1);
    scrollToTop();
  };

  return (
    <Flex $gap="8px">
      <Button onClick={clickPrevPage} disabled={currentPage === 1}>
        <FiChevronsLeft />
      </Button>
      {pageNumbers.map((pageNumber) => (
        <Button
          $current={currentPage === pageNumber}
          onClick={() => clickPage(pageNumber)}
          key={pageNumber}
        >
          {pageNumber}
        </Button>
      ))}
      <Button onClick={clickNextPage} disabled={currentPage === totalPages}>
        <FiChevronsRight />
      </Button>
    </Flex>
  );
}

export default Pagination;
