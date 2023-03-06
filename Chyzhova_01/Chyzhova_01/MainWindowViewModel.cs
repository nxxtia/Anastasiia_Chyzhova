using System;
using System.Windows;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;

namespace Chyzhova_01
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DateTime _birthday;
        private int _age;
        private string _westernZodiacSign;
        private string _chineseZodiacSign;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged("Choose your Birthday to see interesting information");
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public string WesternZodiacSign
        {
            get { return _westernZodiacSign; }
            set
            {
                _westernZodiacSign = value;
                OnPropertyChanged("WesternZodiacSign");
            }
        }

        public string ChineseZodiacSign
        {
            get { return _chineseZodiacSign; }
            set
            {
                _chineseZodiacSign = value;
                OnPropertyChanged("ChineseZodiacSign");
            }
        }

        public RelayCommand CalculateCommand { get; set; }

        public MainWindowViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate);
        }

        private void Calculate()
        {
            int age = DateTime.Today.Year - Birthday.Year;
            if (DateTime.Today.Month < Birthday.Month || (DateTime.Today.Month == Birthday.Month && DateTime.Today.Day < Birthday.Day))
            {
                age--;
            }
            if (age < 0)
            {
                MessageBox.Show("Error: You haven't been born yet.");
            }
            else if (age > 135)
            {
                MessageBox.Show("Error: You are too old.");
            }
            else
            {
                Age = age;
                if (DateTime.Today.Month == Birthday.Month && DateTime.Today.Day == Birthday.Day)
                {
                    MessageBox.Show("Happy birthday!\r\nWishing you joy that never ends.\r\nMay your day be filled with love,\r\nAnd blessings from the heavens above.\r\nCheers to another year of life,\r\nAnd memories that will bring delight!");
                }
                WesternZodiacSign = GetWesternZodiacSign(Birthday);
                ChineseZodiacSign = GetChineseZodiacSign(Birthday);
            }
        }

        private string GetWesternZodiacSign(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                    {
                        return "Capricorn";
                    }
                    else
                    {
                        return "Aquarius";
                    }
                case 2:
                    if (day <= 18)
                    {
                        return "Aquarius";
                    }
                    else
                    {
                        return "Pisces";
                    }
                case 3:
                    if (day <= 20)
                    {
                        return "Pisces";
                    }
                    else
                    {
                        return "Aries";
                    }
                case 4:
                    if (day <= 19)
                    {
                        return "Aries";
                    }
                    else
                    {
                        return "Taurus";
                    }
                case 5:
                    if (day <= 20)
                    {
                        return "Taurus";
                    }
                    else
                    {
                        return "Gemini";
                    }
                case 6:
                    if (day <= 20)
                    {
                        return "Gemini";
                    }
                    else
                    {
                        return "Cancer";
                    }
                case 7:
                    if (day <= 22)
                    {
                        return "Cancer";
                    }
                    else
                    {
                        return "Leo";
                    }
                case 8:
                    if (day <= 22)
                    {
                        return "Leo";
                    }
                    else
                    {
                        return "Virgo";
                    }
                case 9:
                    if (day <= 22)
                    {
                        return "Virgo";
                    }
                    else
                    {
                        return "Libra";
                    }
                case 10:
                    if (day <= 22)
                    {
                        return "Libra";
                    }
                    else
                    {
                        return "Scorpio";
                    }
                case 11:
                    if (day <= 21)
                    {
                        return "Scorpio";
                    }
                    else
                    {
                        return "Sagittarius";
                    }
                case 12:
                    if (day <= 21)
                    {
                        return "Sagittarius";
                    }
                    else
                    {
                        return "Capricorn";
                    }
                default:
                    return "";
            }
        }

        private string GetChineseZodiacSign(DateTime birthDate)
        {
            int year = birthDate.Year;
            switch (year % 12)
            {
                case 0:
                    return "Monkey";
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "";
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
           