using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class Model : CommonBase
    {
        public Model()
        {
            GridMatrix = new List<TableMatrix>();
            Players = new List<Player>();
            Player = new Player();
        }

        #region RowCount

        private int _rowCount;
        public int RowCount
        {
            get { return _rowCount; }
            set
            {
                if (_rowCount != value)
                {
                    _rowCount = value;
                    AlertWhenPropertyChanged("RowCount");
                }
            }
        }

        #endregion RowCount

        #region ColumnCount

        private int _columnCount;
        public int ColumnCount
        {
            get { return _columnCount; }
            set
            {
                if (_columnCount != value)
                {
                    _columnCount = value;
                    AlertWhenPropertyChanged("ColumnCount");
                }
            }
        }

        #endregion ColumnCount

        #region IsPopupOpen

        private bool _isPopupOpen;
        public bool IsPopupOpen
        {
            get { return _isPopupOpen; }
            set
            {
                if (_isPopupOpen != value)
                {
                    _isPopupOpen = value;
                    AlertWhenPropertyChanged("IsPopupOpen");
                }
            }
        }

        #endregion IsPopupOpen

        #region HumanGame

        private bool _humanGame;
        public bool HumanGame
        {
            get { return _humanGame; }
            set
            {
                if (_humanGame != value)
                {
                    _humanGame = value;
                    AlertWhenPropertyChanged("HumanGame");
                }
            }
        }

        #endregion HumanGame

        #region ComputerGame

        private bool _computerGame;
        public bool ComputerGame
        {
            get { return _computerGame; }
            set
            {
                if (_computerGame != value)
                {
                    _computerGame = value;
                    AlertWhenPropertyChanged("ComputerGame");
                }
            }
        }

        #endregion ComputerGame

        #region GridMatrix

        private List<TableMatrix> _gridMatrix;
        public List<TableMatrix> GridMatrix
        {
            get { return _gridMatrix; }
            set
            {
                if (_gridMatrix != value)
                {
                    _gridMatrix = value;
                    AlertWhenPropertyChanged("GridMatrix");
                }
            }
        }

        #endregion GridMatrix

        #region Players

        private List<Player> _players;
        public List<Player> Players
        {
            get { return _players; }
            set
            {
                if (_players != value)
                {
                    _players = value;
                    AlertWhenPropertyChanged("Players");
                }
            }
        }

        #endregion Players

        #region Player

        private Player _player;
        public Player Player
        {
            get { return _player; }
            set
            {
                if (_player != value)
                {
                    _player = value;
                    AlertWhenPropertyChanged("Player");
                }
            }
        }

        #endregion Player

        #region GameLevel

        private GameLevel _gameLevel;
        public GameLevel GameLevel
        {
            get { return _gameLevel; }
            set
            {
                if (_gameLevel != value)
                {
                    _gameLevel = value;
                    AlertWhenPropertyChanged("GameLevel");
                }
            }
        }

        #endregion GameLevel

        #region IsSosSoundActive

        private bool _isSosSoundActive;
        public bool IsSosSoundActive
        {
            get { return _isSosSoundActive; }
            set
            {
                if (_isSosSoundActive != value)
                {
                    _isSosSoundActive = value;
                    AlertWhenPropertyChanged("IsSosSoundActive");
                }
            }
        }


        #endregion IsSoundActive

        #region IsMusicActive

        private bool _isMusicActive;
        public bool IsMusicActive
        {
            get { return _isMusicActive; }
            set
            {
                if (_isMusicActive != value)
                {
                    _isMusicActive = value;
                    AlertWhenPropertyChanged("IsMusicActive");
                }
            }
        }

        #endregion IsMusicActive

        #region IsTimerActibe

        private bool _isTimerActive;
        public bool IsTimerActive
        {
            get { return _isTimerActive; }
            set
            {
                if (_isTimerActive != value)
                {
                    _isTimerActive = value;
                    AlertWhenPropertyChanged("IsTimerActive");
                }
            }
        }

        #endregion IsTimerActibe

        public int ButtonSize { get; set; } = 50;

        public int gameTimeSeconds { get; set; } = 0;

    }


}
