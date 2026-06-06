using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class MemberService
{
    private readonly LibraryDb _context;

    public MemberService(LibraryDb context)
    {
        _context = context;
    }

    public async Task<List<Member>> GetAll()
        => await _context.Members.ToListAsync();

    public async Task<Member> GetById(int id)
        => await _context.Members.FindAsync(id);

    public async Task Add(Member member)
    {
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Member member)
    {
        _context.Members.Update(member);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member == null) return;

        _context.Members.Remove(member);
        await _context.SaveChangesAsync();
    }
}