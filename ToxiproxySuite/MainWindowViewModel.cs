using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxiproxySuite
{
    class MainWindowViewModel : ObservableObject
    {
        public ICommand SwitchViewsCommand { get; private set; }

        private UserControl currentView;
        public UserControl CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                if (value != currentView)
                {
                    currentView = value;
                    RaisePropertyChangedEvent("CurrentView");
                }
            }
        }

        public MainWindowViewModel()
        {
            SwitchViewsCommand = new RelayCommand(SwitchView);
            CurrentView = new NoServerSelectedControl();
        }

        public void SwitchView(object obj)
        {
            CurrentView = (UserControl)Activator.CreateInstance((Type)obj, this);
        }
    }
}
