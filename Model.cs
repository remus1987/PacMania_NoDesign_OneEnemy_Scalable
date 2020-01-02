using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMania_OneEnemy_NoGraphics_Scalable
{
    class Model : INotifyPropertyChanged
    {
        public const int FixedDimension = 40;
        public const int RowCount = 19;
        public const int ColCount = 19;

        public Model()
        {
            dimension = FixedDimension;
            width = RowCount;
            height = ColCount;
        }
        private int _dimension;
        public int dimension
        {
            get { return _dimension; }
            set { _dimension = value; OnPropertyChanged("Dimension"); }
        }
        private int _width;
        public int width
        {
            get { return _width; }
            set { _width = value; OnPropertyChanged("Width"); }
        }
        private int _height;
        public int height
        {
            get { return _height; }
            set { _height = value; OnPropertyChanged("Height"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
        }
    }
}
