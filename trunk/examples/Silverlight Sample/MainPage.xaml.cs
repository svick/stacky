using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using Stacky;

namespace Silverlight_Sample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            StackyClient client = new StackyClient("0.9", "", Sites.StackOverflow, new UrlClient(), new JsonProtocol());
            client.GetUsers(users =>
            {
                DataContext = new MainPageViewModel(users);
                //MessageBox.Show(String.Format("There are {0} total users", users.TotalItems));
            }, error =>
            {
                MessageBox.Show(error.Message);
            });
        }
    }

    public class MainPageViewModel
    {
        public IEnumerable<User> Users { get; set; }

        public MainPageViewModel(IEnumerable<User> users)
        {
            Users = users;
        }
    }
}
