using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Employee
    {
        private string surname;
        private string name;
        private string patronymic;
        private string login;
        private string password;
        private string inn;
        private string phoneNumber;
        private string email;
        private string passportSeries;
        private string passportNumber;
        private string role;

        public int EmployeeId { get; set; }
        public string Surname
        {
            get => surname; set
            {
                surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(surname)));
            }
        }
        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
        public string Patronymic
        {
            get => patronymic; set
            {
                patronymic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(patronymic)));
            }
        }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public string Login
        {
            get => login; set
            {
                login = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(login)));
            }
        }
        public string Password
        {
            get => password; set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(password)));
            }
        }
        public string Inn
        {
            get => inn; set
            {
                inn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(inn)));
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber; set
            {
                phoneNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(phoneNumber)));
            }
        }
        public string Email
        {
            get => email; set
            {
                email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(email)));
            }
        }
        public string PassportSeries
        {
            get => passportSeries; set
            {
                passportSeries = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(passportSeries)));
            }
        }
        public string PassportNumber
        {
            get => passportNumber; set
            {
                passportNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(passportNumber)));
            }
        }
        public string Role
        {
            get => role; set
            {
                role = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(role)));
            }
        }


        public override string ToString()
        {
            return Surname;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
