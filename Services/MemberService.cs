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

        public bool AddMember(Member member)
        {
            if (member.Name == "" || member.Phone == "") return false;

            var members = _store.Load<Member>(FileName);

            foreach (var searchedMember in members)
            {
                if (searchedMember.Name == member.Name && searchedMember.Phone == member.Phone) return false;
            }

            member.Id = members.Count + 1;
            members.Add(member);
            _store.Save<Member>(FileName, members);

            return true;
        }

        public List<Member> GetAllMembers()
        {
            var members = _store.Load<Member>(FileName);

            return members;
        }
    }
}
