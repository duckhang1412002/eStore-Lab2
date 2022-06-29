using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<MemberObject> GetMembers() {
            return MemberDAO.Instance.GetMemberList();
        }
        public MemberObject GetMemberByID(int memberID) {
            return MemberDAO.Instance.GetMemberByID(memberID);
        }
        public void InsertMember(MemberObject member) {
            MemberDAO.Instance.Insert(member);
        }
        public void RemoveMember(int memberID) {
            MemberDAO.Instance.Remove(memberID);
        }
        public void UpdateMember(MemberObject member) {
            MemberDAO.Instance.Update(member);
        }
    }
}