using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class EfMemberRepository : IMemberService
    {
        private readonly LibraryDbContext _db;

        public EfMemberRepository(LibraryDbContext db)
        {
            _db = db;
        }

        public void Save(Member member)
        {
            throw new NotImplementedException("Member persistence is not implemented.");
        }

        public Member GetById(int id)
        {
            throw new NotImplementedException("Fetching member by ID is not implemented.");
        }

        public IReadOnlyList<Member> GetAll()
        {
            throw new NotImplementedException("Fetching all members is not implemented.");
        }

        public void Delete(int id)
        {
            throw new NotImplementedException("Member removal is not implemented.");
        }
    }
} 