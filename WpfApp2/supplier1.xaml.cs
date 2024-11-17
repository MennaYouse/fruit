using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for supplier1.xaml
    /// </summary>
    public partial class supplier1 : Window
    {
        fruitEntities frut = new fruitEntities();
        fruit fruit1 = new fruit();
        public supplier1()
        {
            InitializeComponent();
            loaddata();
        }
        private void loaddata()
        {
            dataview.ItemsSource = frut.fruits.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fruit fruit = new fruit()
            {
                fruit_name=name.Text,
                fruit_quantity=int.Parse(quantity.Text),
                fruit_price= decimal.Parse(price.Text)
            };
            frut.fruits.Add(fruit);
            frut.SaveChanges();
            loaddata();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fruit1.fruit_name = name.Text;
            fruit1.fruit_quantity = int.Parse(quantity.Text);
            fruit1.fruit_price = decimal.Parse(price.Text);
            frut.SaveChanges();
            loaddata();
            clean();
        }

        private void dataview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataview.SelectedItem is fruit selectedfrut)
            {
                fruit1=selectedfrut;
                name.Text=fruit1.fruit_name;
                quantity.Text = fruit1.fruit_quantity.ToString();
                price.Text=fruit1.fruit_price.ToString();
            }
        }
        public void clean()
        {
            name.Clear();
            price.Clear(); 
            quantity.Clear();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frut.fruits.Remove(fruit1);
            frut.SaveChanges();
            loaddata();
            clean();
        }
    }
}
