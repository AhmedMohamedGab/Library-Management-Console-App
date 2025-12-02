using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Data;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal class MemberService : IMemberService
    {
        private readonly IDataStore _store;
        private const string FileName = "members.json";

        public MemberService(IDataStore store)
        {
            _store = store;
        }
        public void AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllMembers()
        {
            throw new NotImplementedException();
        }

        public Member? GetMemberById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
