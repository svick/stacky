using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Windows_Phone_7_Sample
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set 
            {
                displayName = value;
                NotifyPropertyChanged("DisplayName");
            }
        }

        private int reputation;
        public int Reputation
        {
            get { return reputation; }
            set
            {
                reputation = value;
                NotifyPropertyChanged("Reputation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}