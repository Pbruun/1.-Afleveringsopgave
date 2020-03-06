using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Graded_Exercise
{
    class User : INotifyPropertyChanged
    {

        private int id;
        private String name;
        private int age;
        private int score;
        public User(int Id, string Name, int Age, int Score)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.Score = Score;
        }

        public int Id{
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public string Name{
            get { return name; }
            set {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public int Age{
            get {return age; }
            set {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }
        public int Score{
            get {return score; }
            set
            {
                score = value;
                NotifyPropertyChanged("Score");
            }
        }
        public string ListBoxToString
        {
            get{
                return $"ID: {Id} Name: {Name}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged(this, new PropertyChangedEventArgs("ListBoxToString"));
            }

        }
    }

}
