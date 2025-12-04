using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal interface IMemberService
    {
        bool AddMember(Member member);
        List<Member> GetAllMembers();
    }
}
