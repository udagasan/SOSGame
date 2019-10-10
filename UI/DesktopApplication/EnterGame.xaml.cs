using Common;
using MaterialDesignThemes.Wpf;
using Server;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace UI
{
    /// <summary>
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class EnterGame : Window
    {

        public Model Model { get; set; }


        public EnterGame()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Model = new Model
            {
                ComputerGame = true,
                HumanGame = false,
            };

        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Model = new Model();
        }

        private void OutGame(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void ComputerGameClick(object sender, RoutedEventArgs e)
        {
            var chkBox = sender as ToggleButton;
            if (chkBox.IsChecked == true)
            {
                Model.HumanGame = false;
                Model.ComputerGame = true;
                HumanClickCheckBox.IsChecked = false;

            }
            else
            {
                HumanClickCheckBox.IsChecked = true;

            }


        }
        private void HumanGameClick(object sender, RoutedEventArgs e)
        {
            var chkBox = sender as ToggleButton;

            if (chkBox.IsChecked == true)
            {
                CompuerClickCheckBox.IsChecked = false;

                Model.ComputerGame = false;
                Model.HumanGame = true;
            }
            else
            {
                CompuerClickCheckBox.IsChecked = true;

            }


        }

        void FirstWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Model.HumanGame = false;
            Model.ComputerGame = true;
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            if (Model.RowCount < 6)
            {
                MessageBox.Show(Messages.PleaseSelectGameSize);
                return;
            }
            firstWindow.Visibility = Visibility.Hidden;
            SpecifyGameLevel();
            PlayerRegister player = new PlayerRegister(Model);
            player.ShowDialog();
        }

        private void CalcelClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(Messages.AreYouSureExitGame, "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            Model = new Model();
            Close();
        }

        void SpecifyGameLevel()
        {
            //TODO buranın text ten alınması düzenlenecek
            if (GameLevelComboBox.Text.Equals("Easy"))
            {
                Model.GameLevel = GameLevel.Easy;
            }
            if (GameLevelComboBox.Text.Equals("Hard"))
            {
                Model.GameLevel = GameLevel.Hard;

            }
            if (GameLevelComboBox.Text.Equals("Medium"))
            {
                Model.GameLevel = GameLevel.Medium;

            }
            if (GameLevelComboBox.Text.Equals("Very Hard"))
            {
                Model.GameLevel = GameLevel.VeryHard;

            }
        }

        private void GameSizeClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            var size = int.Parse(button.Content.ToString());
            var sizeChildren = GameSizeStackPannel.Children;

            foreach (ToggleButton item in sizeChildren)
            {
                if (!item.Equals(button))
                {
                    item.IsChecked = false;
                }
            }
            Model.RowCount = size;
            Model.ColumnCount = size;
        }

        private void Soud_Click(object sender, RoutedEventArgs e)
        {
            var chkBox = sender as ToggleButton;
            if (chkBox.IsChecked == true)
            {
                Model.IsMusicActive = true;
                Model.IsSosSoundActive = true;

            }
            else
            {
                Model.IsMusicActive = false;
                Model.IsSosSoundActive = false;
            }
            new SoundController(Model).PlayGameMusic();
        }

        private void Timer_Click(object sender, RoutedEventArgs e)
        {
            var chkBox = sender as ToggleButton;
            if (chkBox.IsChecked == true)
            {
                Model.IsTimerActive = true;
                PresetTimePicker.Visibility = Visibility.Visible;


            }
            else
            {
                Model.IsTimerActive = false;
                PresetTimePicker.Visibility = Visibility.Hidden;

            }
        }

        private void PresetTimePicker_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<System.DateTime?> e)
        {
            var timer = sender as TimePicker;
        }
    }
}
