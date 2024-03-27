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
using _1Task.ViewModel;


namespace _1Task
{

    public partial class MainWindow : Window
    {
        ApplicationViewModel applicationViewModel = new ApplicationViewModel();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            string newItem = tbNewItem.Text;

            if (!string.IsNullOrWhiteSpace(newItem))
            {
                applicationViewModel.addElement(newItem);
                tbNewItem.Clear();
                lbMain.Items.Add(applicationViewModel.getLastElementList());
            }
            
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            string newItem = tbNewItem1.Text;

            if (!string.IsNullOrWhiteSpace(newItem))
            {
                applicationViewModel.deleteElement(newItem);
                tbNewItem1.Clear();
                lbMain.Items.Clear();
                for (int i = 0; i < applicationViewModel.getCount(); i++)
                {
                    lbMain.Items.Add(applicationViewModel.getElementList(i));
                }
            }

        }

        
        private void IncreaseIndex_Click(object sender, RoutedEventArgs e)
        {
            if (tbGetItem.Text != ""){
                int currentIndex = int.Parse(tbGetItem.Text);
                currentIndex = currentIndex + 1;
                tbGetItem.Text = currentIndex.ToString();
            }
            else
            {
                int currentIndex = 1;
                tbGetItem.Text = currentIndex.ToString();
            }
            
        }

        private void DecreaseIndex_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = int.Parse(tbGetItem.Text);
            currentIndex = currentIndex - 1;
            tbGetItem.Text = currentIndex.ToString();
        }
        private void GetItem_Click(object sender, RoutedEventArgs e)
        {
            int index;
            if (int.TryParse(tbGetItem.Text, out index) && index >= 0 && index < applicationViewModel.getCount())
            {
                string element = applicationViewModel.getElementList(index);
                MessageBox.Show("Элемент под индексом " + index + " : " + element, "Элемент списка");
            }
            else
            {
                MessageBox.Show("Некорректный индекс", "Ошибка");
            }
        }
        private void ClearItem_Click(object sender, RoutedEventArgs e)
        {
            applicationViewModel.clearList();
            lbMain.Items.Clear();
        }

    }
}