import {
  BookAssignmentsWrappper,
  Status,
  Table,
} from 'features/profilePage/assignments/BookAssignments.styled.tsx';
import { Button, Spinner } from 'components/styles';
import { useGetAssignmentsQuery } from 'services/bookApiService.ts';
import { AssignmentResponse } from 'features/profilePage/uploadBook/customSelect/types.ts';

enum STATUS {
  ACTIVE = 'ACTIVE',
  PENDING = 'PENDING',
}

function isAssignmentActive(book: AssignmentResponse) {
  return book.status === 1;
}

function BookAssignmets() {
  const {
    data: assignments,
    isSuccess,
    isError,
    isFetching,
    isLoading,
  } = useGetAssignmentsQuery();

  function convertDate(originalDate: string): string {
    const date = new Date(originalDate);
    const day = date.getDate();
    const month = date.getMonth() + 1;
    const year = date.getFullYear();

    return `${month}/${day}/${year}`;
  }

  return (
    <BookAssignmentsWrappper>
      {isLoading || isFetching ? (
        <Spinner />
      ) : isSuccess ? (
        assignments.length === 0 ? (
          <p>No assignments</p>
        ) : (
          <Table>
            <thead>
              <tr>
                <th>BOOK</th>
                <th>START DATE</th>
                <th>END DATE</th>
                <th>STATUS</th>
                <th>ACTIONS</th>
              </tr>
            </thead>
            <tbody>
              {assignments.map((book, index) => (
                <tr key={index}>
                  <td>{book.title}</td>
                  <td>{convertDate(book.startDate)}</td>
                  <td>{convertDate(book.endDate)}</td>
                  <td>
                    <Status $isActive={isAssignmentActive(book)}>
                      {isAssignmentActive(book)
                        ? STATUS.ACTIVE
                        : STATUS.PENDING}
                    </Status>
                  </td>
                  <td>
                    <Button $borderRadius="none">
                      {isAssignmentActive(book)
                        ? 'EXTEND DEADLINE'
                        : 'CHANGE TIME RANGE'}
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        )
      ) : (
        isError && <p>Failed to get data</p>
      )}
    </BookAssignmentsWrappper>
  );
}

export default BookAssignmets;
