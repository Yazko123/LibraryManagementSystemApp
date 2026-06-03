namespace LibraryManagementSystem.Interfaces
{
    public interface IReportService
    {
        Task<int> GetMostBorrowedBooksCountAsync();
        Task<List<string>> GetMostBorrowedBooksAsync();

        Task<int> GetTotalActiveLoansAsync();
        Task<int> GetOverdueLoansCountAsync();

        Task<Dictionary<string, int>> GetLoansByGenreReportAsync();
    }
}