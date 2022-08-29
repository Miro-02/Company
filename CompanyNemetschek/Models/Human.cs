using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CompanyNemetschek.Models
{

    public class Human
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private bool CheckName(string name)
        {
            if (name[0] < 'A' || name[0] > 'Z')
            {
                return false;
            }
            for (int i = 1; i < name.Length; i++)
            {
                if (name[i] < 'a' || name[i] > 'z')
                {
                    return false;
                }
            }
            return true;
        }
        public enum Position : ushort
        {
            QA = 0,
            BackendDeveloper,
            DataAnalyst,
            SysAdmin,
            UX,
            UI,
            TeamLead,
            Finance,
            Assistant,
        }
        protected int Id;
        protected string? mFirstName;
        protected string? mLastName;
        protected string? mEmail;
        protected Position mPosition;
        protected DateTime mStartingDate;

        protected ushort mSalary;

        protected string? mAdress;

        public Human(string mFirstName, string mLastName, string mEmail, DateTime mStartingDate, Position mPosition, ushort mSalary, string mAdress, int iD)
        {
            MFirstName = mFirstName;
            MLastName = mLastName;
            MEmail = mEmail;
            MStartingDate.AddDays(mStartingDate.Day);
            MStartingDate.AddMonths(mStartingDate.Month);
            MStartingDate.AddYears(mStartingDate.Year);
            MPosition = mPosition;
            MSalary = mSalary;
            MAdress = mAdress;
            ID = iD;
        }

        public string MFirstName
        {
            get
            {
                if (mFirstName == null)
                {
                    throw new ArgumentException("No name");
                }
                return mFirstName;
            }
            protected set
            {
                if (CheckName(value))
                {
                    mFirstName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid name");
                }
            }
        }

        public string MLastName
        {
            get
            {
                if (mLastName == null)
                {
                    throw new ArgumentException("No name");
                }
                return mLastName;
            }
            protected set
            {
                if (!CheckName(value))
                {
                    throw new ArgumentException("Invalid name");

                }
                else
                {
                    mLastName = value;
                }
            }
        }



        public string MEmail
        {
            get
            {
                if (mEmail == null)
                {
                    throw new ArgumentException("Invalid email");
                }
                return mEmail;
            }
            protected set
            {
                if (!IsValidEmail(value))
                {
                    throw new ArgumentException("Invalid email");

                }
                else
                {
                    mEmail = value;
                }
            }
        }


        public DateTime MStartingDate { get => mStartingDate; protected set => mStartingDate = value; }
        public Position MPosition { get => mPosition; protected set => mPosition = value; }
       
        public string MAdress
        {
            get
            {
                if (mAdress == null)
                {
                    throw new ArgumentException("No address");
                }
                return mAdress;
            }
            protected set => mAdress = value;
        }

        public int ID { get => Id; protected set => Id = value; }
        public ushort MSalary { get => mSalary; protected set => mSalary = value; }

        public void PrintHuman()
        {
            Console.WriteLine(MFirstName, MLastName, MEmail, MStartingDate, (Position)MPosition, MSalary, MAdress);
        }
    }
}
