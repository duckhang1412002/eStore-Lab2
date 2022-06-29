using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMemberByID(int memberID);
        void InsertMember(MemberObject member);
        void RemoveMember(int memberID);
        void UpdateMember(MemberObject member);
    }
}