using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace color_mixer.ViewModel
{
    public class Colors : INotifyPropertyChanged
    {
        private System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(255,255,255,255);

        public Colors()
        {
            MyColor = System.Windows.Media.Color.FromArgb(255, 0, 255, 255);
        }


        public System.Windows.Media.Color MyColor
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged();
            }
        }

        public byte First
        {
            get { return color.A; }
            set
            {
                color.A = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MyColor));

            }
        }

        public byte Second
        {
            get => color.R;
            set
            {
                color.R = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MyColor));

            }
        }

        public byte Third
        {
            get => color.G;
            set
            {
                color.G = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MyColor));

            }
        }

        public byte Four
        {
            get => color.B;
            set
            {
                color.B = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MyColor));

            }
        }

        public object Clone()
        {
            Colors colors = (Colors)this.MemberwiseClone();
            return colors;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null )
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
