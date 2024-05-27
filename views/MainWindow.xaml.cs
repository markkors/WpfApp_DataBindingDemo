using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp_DataBindingDemo.models;


namespace WpfApp_DataBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        List<myitem> _itemsA = new List<myitem>();
        List<myitem> _itemsB = new List<myitem>();
        List<myitem> _itemsC = new List<myitem>();
        private string _SelectedNr5;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();

            cmbDataCodeBehind1.Items.Add("Item 1 (code behind method 1)");
            cmbDataCodeBehind1.Items.Add("Item 2 (code behind method 1)");
            cmbDataCodeBehind1.Items.Add("Item 3 (code behind method 1)");
            cmbDataCodeBehind1.SelectionChanged += CmbDataCodeBehind1_SelectionChanged;

            cmbDataCodeBehind2.Items.Add(new myitem { Name = "Item 1 (code behind method 2)", Value = "a" });
            cmbDataCodeBehind2.Items.Add(new myitem { Name = "Item 2 (code behind method 2)", Value = "b" });
            cmbDataCodeBehind2.Items.Add(new myitem { Name = "Item 3 (code behind method 2)", Value = "c" });
            cmbDataCodeBehind2.DisplayMemberPath = "Name";
            cmbDataCodeBehind2.SelectionChanged += CmbDataCodeBehind2_SelectionChanged; 

            
            _itemsA.Add(new myitem { Name = "Item 1 (code behind binding method 1)", Value = "a" });
            _itemsA.Add(new myitem { Name = "Item 2 (code behind binding method 1)", Value = "b" });
            _itemsA.Add(new myitem { Name = "Item 3 (code behind binding method 1)", Value = "c" });
            cmbDataCodeBehind3.DisplayMemberPath = "Name";
            cmbDataCodeBehind3.ItemsSource = _itemsA;
            cmbDataCodeBehind3.SelectionChanged += CmbDataCodeBehind2_SelectionChanged;

            _itemsB.Add(new myitem { Name = "Item 1 (code behind binding method 2)", Value = "a" });
            _itemsB.Add(new myitem { Name = "Item 2 (code behind binding method 2)", Value = "b" });
            _itemsB.Add(new myitem { Name = "Item 3 (code behind binding method 2)", Value = "c" });


            _itemsC.Add(new myitem { Name = "Item 1 (code behind binding method 3)", Value = "a" });
            _itemsC.Add(new myitem { Name = "Item 2 (code behind binding method 3)", Value = "b" });
            _itemsC.Add(new myitem { Name = "Item 3 (code behind binding method 3)", Value = "c" });

            this.DataContext = this;
                     
        }


        public List<myitem> myItemsB { 
            get { return _itemsB; } 
        }

        public List<myitem> myItemsC
        {
            get { return _itemsC; }
        }

        public string SelectedNr5 { 
            get { return _SelectedNr5; } 
            set { 
                _SelectedNr5 = value;
                NotifyPropertyChanged("SelectedNr5");
            } 
        }

        private void CmbDataCodeBehind2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            myitem mi = ((myitem)cmb.SelectedItem);
            MessageBox.Show($"Selected item: {mi.Value.ToString()}\n{mi.Name.ToString()}");  
        }

        private void CmbDataCodeBehind1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Selected item: " + cmbDataCodeBehind1.SelectedItem.ToString());
        }

       
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            myitem mi = ((myitem)cmb.SelectedItem);
            SelectedNr5 = mi.Value.ToString();
        }


        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

   
}

