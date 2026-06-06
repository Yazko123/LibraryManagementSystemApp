namespace LibraryManagementSystem.Interfaces
{
    public interface ILoanService
    {
        bool CreateLoan(int bookId, int memberId);
    }
}