using System.Windows;
using System.Windows.Input;

namespace GraphicalUserInterfaceWpf.MVVM.ViewModel
{
    public class ViewModelButton
    {
        
        
        private bool canExecute = true;
        private ICommand buttonClickCommand;
        public bool CanExecute
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                if (this.canExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }


       
        public ICommand ButtonClickCommand
        {
            get
            {
                return buttonClickCommand;
            }
            set
            {
                buttonClickCommand = value;
            }
        }

        public ViewModelButton()
        {
            ButtonClickCommand = new RelayCommand(ShowMessage, param => this.canExecute);
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }

       
    }
}
