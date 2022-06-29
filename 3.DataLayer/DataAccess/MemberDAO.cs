using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance {
            get {
                lock (instanceLock) {
                    if (instance == null) {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<MemberObject> GetMemberList() {
            var members = new List<MemberObject>();
            try {
                using var context = new eStoreContext();
                members = context.Members.ToList();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public MemberObject GetMemberByID(int memId) {
            MemberObject member = null;
            try {
                using var context = new eStoreContext();
                member = context.Members.SingleOrDefault(m => m.MemberId == memId);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void Insert(MemberObject member) {
            try {
                MemberObject _member = GetMemberByID(member.MemberId);
                //ID not collapse
                if (_member == null) {
                    using var context = new eStoreContext();
                    context.Members.Add(member); 
                    context.SaveChanges();
                } else {
                    throw new Exception("The member is already exist.");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Update(MemberObject member) {
            try {
                MemberObject _member = GetMemberByID(member.MemberId);
                if (_member != null) {
                    using var context = new eStoreContext();
                    context.Members.Update(member);
                    context.SaveChanges();
                } else {
                    throw new Exception("The member does not not exist.");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int memID) {
            try {
                MemberObject _member = GetMemberByID(memID);
                if (_member != null) {
                    using var context = new eStoreContext();
                    context.Members.Remove(_member);
                    context.SaveChanges();
                } else {
                    throw new Exception("The member does not not exist.");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}