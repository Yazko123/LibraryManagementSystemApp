using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application   
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