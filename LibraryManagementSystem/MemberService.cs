using LibraryManagementSystem;
using LibraryManagementSystem.Application;
using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class MemberService : IMemberService
{
    private readonly LibraryDbContext _context;

    public MemberService(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<List<Member>> GetAllAsync()
        => await _context.Members.ToListAsync();

    public async Task<Member> GetByIdAsync(int id)
        => await _context.Members.FindAsync(id);

    public async Task RegisterAsync(Member member)
    {
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Member member)
    {
        _context.Members.Update(member);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CanBorrowAsync(int memberId)
    {
        var member = await _context.Members.FindAsync(memberId);
        return member != null && member.ActiveLoansCount < 3;
    }

    public async Task<int> GetActiveLoansCountAsync(int memberId)
    {
        return await _context.Loans
            .CountAsync(l => l.MemberId == memberId && !l.IsReturned);
    }
}