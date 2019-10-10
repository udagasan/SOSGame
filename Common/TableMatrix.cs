using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class TableMatrix : CommonBase
    {

        #region Row

        private int _row;
        public int Row
        {
            get { return _row; }
            set
            {
                if (_row != value)
                {
                    _row = value;
                    AlertWhenPropertyChanged("Row");
                }
            }
        }

        #endregion Row

        #region Column

        private int _column;
        public int Column
        {
            get { return _column; }
            set
            {
                if (_column != value)
                {
                    _column = value;
                    AlertWhenPropertyChanged("Column");
                }
            }
        }

        #endregion Column

        #region Name

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    AlertWhenPropertyChanged("Name");
                }
            }
        }

        #endregion Name

        #region Content

        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    AlertWhenPropertyChanged("Content");
                }
            }
        }

        #endregion Content

        #region IsFree

        private bool _isFree;
        public bool IsFree
        {
            get { return _isFree; }
            set
            {
                if (_isFree != value)
                {
                    _isFree = value;
                    AlertWhenPropertyChanged("IsFree");
                }
            }
        }

        #endregion IsFree

        #region X1

        private double _x1;
        public double X1
        {
            get { return _x1; }
            set
            {
                if (_x1 != value)
                {
                    _x1 = value;
                    AlertWhenPropertyChanged("X1");
                }
            }
        }

        #endregion X1

        #region Y1

        private double _y1;
        public double Y1
        {
            get { return _y1; }
            set
            {
                if (_y1 != value)
                {
                    _y1 = value;
                    AlertWhenPropertyChanged("Y1");
                }
            }
        }

        #endregion Y1

        #region X2

        private double _x2;
        public double X2
        {
            get { return _x2; }
            set
            {
                if (_x2 != value)
                {
                    _x2 = value;
                    AlertWhenPropertyChanged("X2");
                }
            }
        }

        #endregion X2

        #region Y2

        private double _y2;
        public double Y2
        {
            get { return _y2; }
            set
            {
                if (_y2 != value)
                {
                    _y2 = value;
                    AlertWhenPropertyChanged("Y2");
                }
            }
        }

        #endregion Y2


        public int SosPossibilityCountForO { get; set; }
        public int SosPossibilityCountForS { get; set; }
    }
}
