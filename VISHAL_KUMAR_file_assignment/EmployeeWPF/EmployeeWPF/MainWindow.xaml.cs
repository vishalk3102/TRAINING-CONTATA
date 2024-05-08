using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeWPF
{
    public partial class MainWindow : Window
    {

        private List<string> employees = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            string filePath = "employee.txt";
            if(File.Exists(filePath)) 
             {
                employees=new List<string>(File.ReadAllLines(filePath));
                updateBox();
             }
        }

        private void updateBox()
        {
            employeesListBox.ItemsSource = null;
            employeesListBox.ItemsSource = employees;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string newEmployee= employeeNameTextBox.Text;
            if(!string.IsNullOrEmpty(newEmployee) ) 
            {
                employees.Add(newEmployee);
                updateBox();
                employeeNameTextBox.Clear();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "employee.txt";
            File.WriteAllLines(filePath, employees);
            MessageBox.Show("Employee Added Successfully");
        }
    }
}