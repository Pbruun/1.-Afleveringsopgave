using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WPF_Graded_Exercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<User> users;
        public MainWindow()
        {
            InitializeComponent();
            users = new ObservableCollection<User>();
            listBox.DataContext = users;
            gridOuter.DataContext = users;
        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                string line;

                StreamReader file = new StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                {
                    string[] singleStrUser = line.Split(';');
                    users.Add(
                        new User(
                            int.Parse(singleStrUser[0]),
                            singleStrUser[1],
                            int.Parse(singleStrUser[2]),
                            int.Parse(singleStrUser[3])
                            )
                        );
                    Console.WriteLine(users);

                }
                listBox.ItemsSource = users;
                status.Content = $"Date last changed: {DateTime.Now}\nNumber of lines: {users.Count}";
                file.Close();
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string id = nameTB.Text;
            string name = nameTB.Text;
            string age = ageTB.Text;
            string score = scoreTB.Text;



            if (users != null)
            {
                User user = listBox.SelectedItem as User;
                if (id.Length != 0 && int.TryParse(id, out int idResult))
                {
                    user.Id = idResult;

                }
                if (name.Length != 0)
                {
                    user.Name = name;
                }
                if (age.Length != 0 && int.TryParse(age, out int ageResult))
                {
                    user.Age = ageResult;
                }
                if (score.Length != 0 && int.TryParse(score, out int scoreResult))
                {
                    user.Score = scoreResult;
                }

            }
            listBox.Items.Refresh();
        }
        
    }
}
