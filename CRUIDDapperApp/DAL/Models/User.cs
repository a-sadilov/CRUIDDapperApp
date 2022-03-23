using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Data.SqlTypes;

namespace CRUDReestrApp.DAL.Models
{
    public class User : INotifyPropertyChanged
    {
        private Guid userId;
        private string firstName;
        private string lastName;
        private string fatherName;
        private long inn;
        private string orgName;
        private long orgInn;
        private string orgAdress;
        public User()
        {
            this.userId = Guid.NewGuid();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Guid UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("userId");
            }
        }
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = "Invalid name length")]
        [RegularExpression(@"[a-zA-Z]",
            ErrorMessage = "Use only alphabetic characters")]
        public string FirstName {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("firstName");
            }
        }
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = "Invalid lastname length")]
        [RegularExpression(@"[a-zA-Z]",
            ErrorMessage = "Use only alphabetic characters")]
        public string LastName {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("lastName");
            }
        }
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = "Invalid fathername length")]
        [RegularExpression(@"[a-zA-Z]",
            ErrorMessage = "Use only alphabetic characters")]
        public string FatherName {
            get { return fatherName; }
            set
            {
                fatherName = value;
                OnPropertyChanged("fatherName");
            }
        }
        [Range(0000000000000000, 9999999999999999,
            ErrorMessage = "Invalid INN format")]
        public long Inn {
            get { return inn; }
            set
            {
                inn = value;
                OnPropertyChanged("inn");
            }
        }
        [RegularExpression(@"[^\p{P}\d]",
            ErrorMessage = "Invalid format")]
        [StringLength(60, MinimumLength = 2,
            ErrorMessage = "Invalid lenght")]
        public string OrgName
        {
            get { return orgName; }
            set
            {
                orgName = value;
                OnPropertyChanged("orgName");
            }
        }
        [Range(00000000000000000, 9999999999999999,
            ErrorMessage = "Invalid format INN")]
        public long OrgInn
        {
            get { return orgInn; }
            set
            {
                orgInn = value;
                OnPropertyChanged("orgInn");
            }
        }
        [StringLength(60, MinimumLength = 6,
            ErrorMessage = "Invalid lenght")]
        [RegularExpression(@"[^\p{P}\d]",
            ErrorMessage = "Invalid format")]
        public string OrgAdress
        {
            get { return orgAdress; }
            set
            {
                orgAdress = value;
                OnPropertyChanged("orgAdress");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
