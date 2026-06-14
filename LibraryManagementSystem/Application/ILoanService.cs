namespace LibraryManagementSystem.Application   
{
    public interface ILoanService
    {
        bool CreateLoan(int bookId, int memberId);
    }
}