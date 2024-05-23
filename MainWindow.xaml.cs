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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_DataBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<myitem> _itemsA = new List<myitem>();
        List<myitem> _itemsB = new List<myitem>();

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
            this.DataContext = this;
                     
        }


        public List<myitem> myItemsB { 
            get { return _itemsB; } 
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

        }
    }

   
}

