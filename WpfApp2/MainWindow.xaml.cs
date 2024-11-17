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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        fruitEntities frut=new fruitEntities();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username= usersname.Text;
            string password =pasword .Password;
            var names = frut.users.FirstOrDefault(a => a.users_name == username && a.users_password == password);

            if (names != null)
            {
                if (names.types_user == "supplier")
                {
                    supplier1 supplier1 = new supplier1();
                    supplier1.Show();
                    this.Close();
                }
                else
                {


                    customer1 nextpage = new customer1(names.users_id);
                    nextpage.Show();
                    this.Close();
                }

            }
        }
    }
}
