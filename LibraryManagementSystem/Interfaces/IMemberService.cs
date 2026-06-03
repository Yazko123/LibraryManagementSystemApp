using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface IMemberService
    {
        Task<List<Member>> GetAllAsync();
        Task<Member> GetByIdAsync(int id);

        Task RegisterAsync(Member member);
        Task UpdateAsync(Member member);

        Task<bool> CanBorrowAsync(int memberId);
        Task<int> GetActiveLoansCountAsync(int memberId);
    }
}