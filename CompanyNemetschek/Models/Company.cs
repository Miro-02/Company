using System.IO;

namespace CompanyNemetschek.Models
{
    public class Company
    {
        private int Id;
        private string? mName;
        private ushort mEarnings;
        private ushort mExpenses;
        private List<TeamLead> mTeamLeads;

        public Company(int iD, string mName, ushort mEarnings, ushort mExpenses)
        {
            ID = iD;
            MName = mName;
            MEarnings = mEarnings;
            MExpenses = mExpenses;
            mTeamLeads = new List<TeamLead>();
        }

        public int ID { get => Id; set => Id = value; }
        public string MName
        {
            get
            {
                if (mName == null)
                {
                    throw new ArgumentException("No name");
                }
                return mName;
            }
            private set => mName = value;
        }
        public ushort MEarnings { get => mEarnings; private set => mEarnings = value; }
        public ushort MExpenses { get => mExpenses; private set => mExpenses = value; }

        public void AddTeamLead(TeamLead human)
        {
            if (human == null)
            {
                throw new ArgumentException("Null data");
            }
            mTeamLeads.Add(human);
            Console.WriteLine("Successfully added: ");
            human.PrintHuman();
        }
        public void RemoveMember(TeamLead human)
        {
            if (human == null||mTeamLeads==null)
            {
                throw new ArgumentException("Null data");
            }
            mTeamLeads.Remove(human);
            Console.WriteLine("Successfully removed: ");
            human.PrintHuman();
        }
    }
}
