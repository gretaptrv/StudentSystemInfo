using System;
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
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = null;
            string un = username.Text;
            string pw = password.Text;
            void errorFunc(String str)
            {
                Console.WriteLine("EXCEPTION: " + str);
            }
            LoginValidation lv = new LoginValidation(un, pw, errorFunc);

            if (lv.ValidateUserInput(ref user))
            {
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.STUDENT:
                        MainWindow mw = new MainWindow();
                        mw.Show();
                        Close();
                        mw.getStudentData();
                        mw.hideFields();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
