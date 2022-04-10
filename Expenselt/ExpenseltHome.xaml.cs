﻿using System;
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
using System.Windows.Shapes;

namespace Expenselt
{
    /// <summary>
    /// Interaction logic for ExpenseltHome.xaml
    /// </summary>
    public partial class ExpenseltHome : Window
    {
        public ExpenseltHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;

            ExpenseDataSource = new List<Person>()
           {
                new Person()
            {
                Name="Mike",
                Department="Legal",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Lunch", ExpenseAmount=50},
                    new Expense() { ExpenseType="Transportation", ExpenseAmount=50}
                }
            },
                 new Person()
            {
                Name="Lisa",
                Department="Marketing",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Document printing", ExpenseAmount=50},
                    new Expense() { ExpenseType="Gift", ExpenseAmount=125}
                }
            },
                  new Person()
            {
                Name="John",
                Department="Engineering",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50},
                    new Expense() { ExpenseType="New machine", ExpenseAmount=600},
                    new Expense() { ExpenseType="Software", ExpenseAmount=500}
                }
            },
                      new Person()
            {
                Name="Mary",
                Department="Finance",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=100},
                }
            },
                      new Person()
            {
                Name="Theo",
                Department="Markenting",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=100},
                }
            },
                      new Person()
            {
                Name="James",
                Department="Markenting",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=200},
                }
            },
                      new Person()
            {
                Name="David",
                Department="Markenting",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=50},
                }
            }
           };
            MainCaptionText = "View Expense Report :";
        }

        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSource { get; set; }
        public DateTime LastChecked { get; set; }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport report = new ExpenseReport(peopleListBox.SelectedItem);
            report.Height = Height;
            report.Width = Width;
            report.ShowDialog();
        }
    }
}
