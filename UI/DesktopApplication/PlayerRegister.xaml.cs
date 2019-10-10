using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for PlayerRegister.xaml
    /// </summary>
    public partial class PlayerRegister : Window
    {

        public int PlayerId = 0;
        public PlayerRegister()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Model = new Model();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerRegister"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public PlayerRegister(Model model)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (model.ComputerGame)
            {
                UserNameLabel.Text = Messages.EnterPlayerName;

            }
            else
            {
                UserNameLabel.Text = Messages.EnterFirstPlayerName;
            }
            Model = model;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Model _model;

        public Model Model
        {
            get { return _model; }
            set
            {
                _model = value;
                NotifyPropertyChanged(nameof(Model));
            }
        }



        private void Play_Click(object sender, RoutedEventArgs e)
        {
            var result = SetPlayerNameId(sender as Button);
            if (!result.Item1)
            {
                if (!string.IsNullOrWhiteSpace(result.Item2))
                {
                    MessageBox.Show(result.Item2);
                }
                return;
            }
            SetPlayerColor(Model.Players);
            OpenGameMainPannnel();
        }

        Tuple<bool, string> SetPlayerNameId(Button button)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) && ((Model.ComputerGame && Model.Players.Count == 0)
              || (Model.HumanGame)))
            {
                return new Tuple<bool, string>(false, Messages.EnterFirstPlayerName);
            }
            PlayerId = ++PlayerId;
            Model.Players.Add(new Player
            {
                Id = PlayerId,
                Name = Name.Text.ToString(),
                Score = 0
            });
            Name.Text = string.Empty;
            if (Model.ComputerGame)
            {

                PlayButton.Content = Messages.GamePlay;
                Name.Visibility = Visibility.Hidden;
                UserNameLabel.Visibility = Visibility.Hidden;

            }

            if (Model.HumanGame)
            {
                if (Model.Players.Count == 1)
                {
                    UserNameLabel.Text = Messages.EnterSecondPlayerName;
                    Name.Text = string.Empty;
                    return new Tuple<bool, string>(false, string.Empty);

                }


            }
            if (Model.ComputerGame)
            {
                Model.Players.Add(new Player
                {
                    Id = PlayerId + 1,
                    Name = Messages.Computer,
                    Surname = Messages.Computer,
                    Score = 0
                });
            }

            if (Model.HumanGame && Model.Players.Count() < 2)
            {
                return new Tuple<bool, string>(false, Messages.EnterWholePlayers);

            }
            return new Tuple<bool, string>(true, string.Empty);
        }
        void OpenGameMainPannnel()
        {
            Model.IsPopupOpen = true;
            Model.IsMusicActive = true;
            Model.IsSosSoundActive = true;
            Model.IsTimerActive = false;

            MainWindow main = new MainWindow(Model);
            Close();
            main.ShowDialog();
        }
        void SetPlayerColor(List<Player> players)
        {
            foreach (var item in players)
            {
                if (item.Id == 0)
                {
                    item.PlayerColor = ConsoleColor.Black;

                }
                if (item.Id == 1)
                {
                    item.PlayerColor = ConsoleColor.Magenta;

                }
                if (item.Id == 2)
                {
                    item.PlayerColor = ConsoleColor.Blue;

                }
                if (item.Id == 3)
                {
                    item.PlayerColor = ConsoleColor.Green;

                }
                if (item.Id == 4)
                {
                    item.PlayerColor = ConsoleColor.Red;

                }
            }
        }
    }
}
