using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal interface IMemberService
    {
        bool AddMember(string name, string phone);
        List<Member> GetAllMembers();
        List<Member> SearchMembers(string keyword);
    }
}
