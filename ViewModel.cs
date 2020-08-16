using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICloseViewModel
{
    public interface IClose
    {
        Action Close { get; set; }
    }

    public class RelayCommand<T> : ICommand
    {
        public Action<T> Action { get; }

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> act)
        {
            this.Action = act;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action.Invoke((T)parameter);
        }
    }

    public class ViewModel : IClose
    {

        public ViewModel()
        {
            CloseCommand = new RelayCommand<object>(action);
        }

        private void action(object obj)
        {
            CloseWindow();
        }

        public RelayCommand<object> CloseCommand { get; } 


        public Action Close { get; set; }


        public void CloseWindow()
        {
            Close?.Invoke();
        }

    }
}
