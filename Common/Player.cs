
using System;
using System.Drawing;

namespace Common
{
    public class Player : CommonBase
    {

        #region Id

        private  int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    AlertWhenPropertyChanged("Id");
                }
            }
        }

        #endregion Id

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

        #region Surname

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    AlertWhenPropertyChanged("Surname");
                }
            }
        }

        #endregion Surname

        #region Round

        private bool _roond;
        public bool Round
        {
            get { return _roond; }
            set
            {
                if (_roond != value)
                {
                    _roond = value;
                    AlertWhenPropertyChanged("Round");
                }
            }
        }

        #endregion Round

        #region Score

        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    AlertWhenPropertyChanged("Score");
                }
            }
        }

        #endregion Score

        #region IsWon

        private bool _isWon;
        public bool IsWon
        {
            get { return _isWon; }
            set
            {
                if (_isWon != value)
                {
                    _isWon = value;
                    AlertWhenPropertyChanged("IsWon");
                }
            }
        }

        #endregion IsWon

        public ConsoleColor PlayerColor { get; set; }
    }
}
