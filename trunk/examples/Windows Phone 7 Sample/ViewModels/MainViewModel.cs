using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Stacky;


namespace Windows_Phone_7_Sample
{
    public class MainViewModel
    {
        public MainViewModel(IEnumerable<User> users)
        {
            Items = new ObservableCollection<User>();
            foreach (User user in users)
            {
                Items.Add(user);
            }
        }

        public ObservableCollection<User> Items { get; private set; }
    }
}