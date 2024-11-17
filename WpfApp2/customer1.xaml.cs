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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for customer1.xaml
    /// </summary>
    public partial class customer1 : Window
    {
        int use_id=0;
        fruitEntities frut = new fruitEntities();
        public customer1(int user_id)
        {
            InitializeComponent();
            loaddata();
            use_id = user_id;
        }
        private void loaddata()
        {
            dataview.ItemsSource=frut.fruits.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dataview.SelectedItem is fruit Selectedfruit)
            {
                Selectedfruit.fruit_quantity -= int.Parse(data.Text);
                
                order order = new order()
                {
                    users_id = use_id,
                    fruit_id = Selectedfruit.fruit_id,
                    price = Selectedfruit.fruit_price,
                    order_quantity = int.Parse(data.Text),
                    order_date =DateTime.Now
                    
                };
                frut.orders.Add(order);
                frut.SaveChanges();
                loaddata();
            }
            
        }
    }
}
