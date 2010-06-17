using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using Stacky;

namespace Stackanimate.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }

    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(StackyClient client)
        {
            Client = client;
        }

        private StackyClient Client { get; set; }

        private string inputString;
        public string InputString
        {
            get { return inputString; }
            set { inputString = value; OnPropertyChanged("InputString"); }
        }

        private string outputString;
        public string OutputString
        {
            get { return outputString; }
            set { outputString = value; OnPropertyChanged("OutputString"); }
        }

        private ICommand parseQuestionIdCommand;
        public ICommand ParseQuestionIdCommand
        {
            get
            {
                if (parseQuestionIdCommand == null)
                {
                    parseQuestionIdCommand = new RelayCommand(() =>
                    {
                        if(!String.IsNullOrEmpty(InputString))
                            OutputString = InputString.Substring(0, 10);
                    });
                }
                return parseQuestionIdCommand;
            }
        }
    }
}
