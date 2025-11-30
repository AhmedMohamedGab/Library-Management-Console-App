using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal interface IMemberService
    {
        void AddMember(Member member);
        Member? GetMemberById(int id);
        List<Member> GetAllMembers();
    }
}
