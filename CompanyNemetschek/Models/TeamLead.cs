using System.Security.Cryptography.X509Certificates;

namespace CompanyNemetschek.Models
{
    public class TeamLead : Human
    {
        private List<Human> mTeam;

        public TeamLead(string mFirstName, string mLastName, string mEmail, DateTime mStartingDate, Position mPosition, ushort mSalary, string mAdress, int iD) : base(mFirstName, mLastName, mEmail, mStartingDate, mPosition, mSalary, mAdress, iD)
        {
            mTeam = new List<Human>();
        }

        public void AddMember(Human human)
        {
            if(human==null)
            {
                throw new ArgumentException("Null data");
            }
            mTeam.Add(human);
            Console.WriteLine("Successfully added: ");
            human.PrintHuman();
        }
        public void RemoveMember(Human human)
        {
            if (human == null||mTeam==null)
            {
                throw new ArgumentException("Null data");
            }
            mTeam.Remove(human);
            Console.WriteLine("Successfully removed: ");
            human.PrintHuman();
        }
    }
}
