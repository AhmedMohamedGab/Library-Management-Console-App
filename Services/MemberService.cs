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

        public bool AddMember(string name, string phone)
        {
            if (name == "" || phone == "") return false;

            var members = _store.Load<Member>(FileName);
            var searchedMember = members.Find(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                                                   m.Phone == phone);
            if (searchedMember != null) return false;

            var newMember = new Member { Id = members.Count + 1, Name = name, Phone = phone };
            members.Add(newMember);
            _store.Save<Member>(FileName, members);

            return true;
        }

        public List<Member> GetAllMembers()
        {
            var members = _store.Load<Member>(FileName);

            return members;
        }

        public List<Member> SearchMembers(string keyword)
        {
            var members = _store.Load<Member>(FileName);
            var results = members.FindAll(m => m.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                               m.Phone.Contains(keyword));

            return results;
        }
    }
}
