using color_mixer.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace color_mixer.ViewModel
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private readonly ICollection<Colors> colors = new ObservableCollection<Colors>();

        private Colors selectedColor;

        // Controls

        private Command copyColorCommand;
        private Command removeColorCommand;
        
        public MainWindowModel()
        {
            colors.Add(new Colors() { First = 234, Second = 215, Third = 252 });
            copyColorCommand = new DelegateCommand(DublicateSelectedColors, IsCanCreate);
            removeColorCommand = new DelegateCommand(RemoveSelectedColors, IsCanCreate);

            PropertyChanged += (s, a) =>
            {
                if (a.PropertyName == nameof(SelectedColors))
                {
                    copyColorCommand.RaiseCanExecuteChanged();
                    removeColorCommand.RaiseCanExecuteChanged();
                }
            };
        }

        // for binding elements on windows
        public IEnumerable<Colors> Colors => colors;

        public Colors SelectedColors
        {
            get => selectedColor;
            set
            {
                selectedColor = value;
                OnPropertyChanged();
            }
        }

        public ICommand CopyColorCommand => copyColorCommand;
        public ICommand RemoveColorCommand => removeColorCommand;

        // create

        bool IsCanCreate()
        {
            return SelectedColors != null;
        }
        public void DublicateSelectedColors()
        {
            if (SelectedColors != null)
            {
                colors.Add((Colors)SelectedColors.Clone()); 
            }
        }

        // REMOVE
        bool IsCanSetRemove()
        {
            return SelectedColors != null;
        }
        public void RemoveSelectedColors()
        {
            if (SelectedColors != null)
                colors.Remove(SelectedColors);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
