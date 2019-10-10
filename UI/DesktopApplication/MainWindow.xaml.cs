using Common;
using Microsoft.Win32;
using Server;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, System.ComponentModel.INotifyPropertyChanged
    {
        private static System.Timers.Timer aTimer;
        public static int RemaindTime { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool isTimeOver(TimeSpan timeSpan)
        {
            return false;
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
        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                NotifyPropertyChanged(nameof(PageSize));
            }
        }

        private TableMatrix selectedItem;
        public TableMatrix SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyPropertyChanged(nameof(SelectedItem));
            }
        }

        public MainWindow(Model model)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Maximized;
            Model = model;
            if (Model.IsTimerActive)
            {

                RemaindTime = Model.gameTimeSeconds;
                SetTimer();

            }
        }
        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (IsGameContinue && Model.IsTimerActive)
            {
                Dispatcher.Invoke(() =>
                {
                    RemaindTime -= 1;
                    TimerTex.Text = RemaindTime.ToString();
                    if (RemaindTime <= 0)
                    {
                        ChangePlayerFromTimer();
                    }
                });
            }
        }
        async void ChangePlayerFromTimer()
        {
            ChangePlayer(Model.Players.Where(x => x.Round).FirstOrDefault());
            TimerTex.Text = RemaindTime.ToString();
            RemaindTime = Model.gameTimeSeconds;

            if (IsComputerPlaying())
            {
                await WaitForComputerThinking();
            }
        }
        public Grid SubGrid { get; set; }
        private void ApproveClick(object sender, RoutedEventArgs e)
        {
            Model.ColumnCount = Model.RowCount;

            for (int i = 0; i < Model.RowCount; i++)
            {
                GamePannelGrid.RowDefinitions.Add(
                    new RowDefinition { });
            }
            for (int i = 0; i < Model.ColumnCount; i++)
            {
                GamePannelGrid.ColumnDefinitions.Add(
                    new ColumnDefinition { });
            }

            GamePannelGrid.Width = Model.RowCount * Model.ButtonSize;
            GamePannelGrid.Height = Model.RowCount * Model.ButtonSize;
            GamePannelCard.Height = GamePannelGrid.Height + 1;
            GamePannelCard.Width = GamePannelGrid.Width + 1;
            for (int i = 0; i < Model.RowCount; i++)
            {

                for (int j = 0; j < Model.ColumnCount; j++)
                {
                    SubGrid = new Grid
                    {
                        Width = Model.ButtonSize,
                        Height = Model.ButtonSize,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center

                    };
                    SubGrid.RowDefinitions.Add(new RowDefinition { });
                    SubGrid.ColumnDefinitions.Add(new ColumnDefinition { });

                    Button button = new Button
                    {
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Name = "textBox" + i.ToString() + j.ToString(),
                        Width = Model.ButtonSize,
                        Height = Model.ButtonSize,
                        Background = Brushes.GhostWhite,
                        FontStyle = FontStyles.Normal,
                        FontWeight = FontWeights.Normal,
                        FontSize = 25,
                        Foreground = Brushes.Black,
                        ClickMode = ClickMode.Press,
                        BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5)
                    };
                    button.Click += ClickHendler;

                    Grid.SetColumn(SubGrid, j);
                    Grid.SetRow(SubGrid, i);
                    Model.GridMatrix.Add(new TableMatrix
                    {
                        Column = j,
                        Row = i,
                        Name = button.Name,
                        Content = string.Empty,
                        IsFree = true,
                        X1 = i * Model.ButtonSize,
                        Y1 = j * Model.ButtonSize,
                        X2 = i + Model.ButtonSize,
                        Y2 = j + Model.ButtonSize

                    });
                    SubGrid.Children.Add(button);
                    GamePannelGrid.Children.Add(SubGrid);
                }
            }
            root.Visibility = Visibility.Visible;

            DrowScorePannel();
        }
        private void DrowScorePannel()
        {
            FirstPlayerTextBox.Text = Model.Players[0]?.Name;
            SecondPlayerTextBox.Text = Model.Players[1]?.Name;
            FirstPlayerTextBox.Background = new Helper().GetPlayerColor(Model.Players[0]);
            SecondPlayerTextBox.Background = new Helper().GetPlayerColor(Model.Players[1]);
        }
        private string _buttonContent;

        public string ButtonContent
        {
            get { return _buttonContent; }
            set
            {
                _buttonContent = value;
                NotifyPropertyChanged(nameof(ButtonContent));
            }
        }

        public Popup Popup { get; set; }
        public Button Btn { get; set; }
        private void ClickHendler(object sender, EventArgs e)
        {
            var subGrid = new Grid();


            Popup = new Popup
            {
                Placement = PlacementMode.Mouse,
                IsOpen = true,
                HorizontalOffset = +1,
                VerticalOffset = +1,
                PopupAnimation = PopupAnimation.None

            };
            var popopStackPannel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
            };
            var sButton = new Button { Content = Constants.S, Background = Brushes.GreenYellow, Width = Model.ButtonSize, FontWeight = FontWeights.Bold };
            var oButton = new Button { Content = Constants.O, Background = Brushes.Yellow, Width = Model.ButtonSize, FontWeight = FontWeights.Bold };

            sButton.Click += PopupButtonClickHandlerAsync;
            oButton.Click += PopupButtonClickHandlerAsync;
            popopStackPannel.Children.Add(sButton);
            popopStackPannel.Children.Add(oButton);
            Popup.Child = popopStackPannel;
            Btn = sender as Button;
            SelectedItem = Model.GridMatrix.Where(x => x.Name == Btn.Name).ToList().FirstOrDefault();
            subGrid = GamePannelGrid.Children[FindIndex(SelectedItem.Row, SelectedItem.Column)] as Grid;

            SubGrid = subGrid;

        }
        int FindIndex(int row, int column)
        {
            return row * Model.RowCount + column;
        }
        private async void PopupButtonClickHandlerAsync(object sender, RoutedEventArgs e)
        {
            var playerStart = Model.Players.Where(x => x.Round == true).FirstOrDefault() as Player;

            var button = sender as Button;

            if (!SelectedItem.IsFree)
            {
                Popup.IsOpen = false;
                MessageBox.Show(Messages.ReSelectedError);
                return;
            }

            Btn.Content = button.Content.ToString();
            Btn.Foreground = new Helper().GetPlayerColor(playerStart);

            if (!IsComputerPlaying() && Popup != null)
            {
                Popup.IsOpen = false;
            }

            SelectedItem.Content = button.Content?.ToString();
            SelectedItem.IsFree = false;
            RemaindTime = Model.gameTimeSeconds;

            var response = new SosConroller(GamePannelGrid, SubGrid, Model).Check(SelectedItem);
            if (response.Item1)
            {
                playerStart.Score += response.Item2;
                if (response.Item2 > 0)
                {
                    var sosCount = response.Item2;
                    Model.Player.Score = Model.Player.Score + sosCount;
                    PlayerRoundInfo.Text = $" {playerStart.Name}";


                    if (FirstPlayerTextBox.Text.Equals(playerStart.Name))
                    {
                        FirstPlayerScoreTextBox.Text = playerStart.Score.ToString();
                    }
                    else
                    {
                        SecondPlayerScoreTextBox.Text = playerStart.Score.ToString();
                    }
                }
            }
            else
            {
                var player = ChangePlayer(playerStart);
                PlayerRoundInfo.Text = $" {player?.Name}";
            }

            if (GameFinishControl())
            {
                return;
            }

            if (IsComputerPlaying())
            {
                GamePannelCard.IsEnabled = false;
                await WaitForComputerThinking();
            }
            else
            {
                GamePannelCard.IsEnabled = true;

            }
            return;
        }

        private bool IsComputerPlaying()
        {
            return Model.ComputerGame && Model.Players.Where(x => x.Id == 2).FirstOrDefault().Round;
        }

        private bool GameFinishControl()
        {
            if (!IsGameContinue)
            {
                Player playerLost = Model.Players.OrderBy(x => x.Score).FirstOrDefault() as Player;
                if (!(Model.Players.OrderByDescending(x => x.Score).FirstOrDefault() is Player playerWin) || playerWin.Score == playerLost.Score)
                {
                    MessageBox.Show($"Oyun berabere bitti");
                }
                else
                {
                    MessageBox.Show($"Oyun bitti!. \n{playerWin.Name} kazandı. \nSkor {playerWin.Score} : {playerLost.Score}");
                }
                GamePannelCard.IsEnabled = false;
                return true;
            }
            return false;
        }
        private bool IsGameContinue
        {
            get
            {
                return Model.GridMatrix.Any(x => x.IsFree);
            }
        }
        private readonly Random random = new Random();
        private readonly object syncLock = new object();

        async Task WaitForComputerThinking()
        {
            var stackPannel = new StackPanel();
            stackPannel.Children.Add(new Button { Content = "Computer Thinking", Background = Brushes.Brown });
            var popup = new Popup
            {
                Placement = PlacementMode.Mouse,
                IsOpen = true,
                PopupAnimation = PopupAnimation.Scroll,
                StaysOpen = true
            };
            popup.Child = stackPannel;
            GamePannelGrid.IsEnabled = false;
            await Task.Delay(1);

            var logicalItem = new LogicalOperations(Model, GamePannelGrid, SubGrid).GetLogicalTableItem();
            SelectedItem = logicalItem.index;
            var content = logicalItem.Charater;
            Btn = new Button();
            var subGrid = GamePannelGrid.Children[FindIndex(SelectedItem.Row, SelectedItem.Column)] as Grid;
            Btn = subGrid.Children[0] as Button;
            SubGrid = subGrid;
            PopupButtonClickHandlerAsync(new Button { Content = content }, new RoutedEventArgs());
            popup.IsOpen = false;
            GamePannelGrid.IsEnabled = true;

        }

        private void RedClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            if (IsGameContinue)
            {
                var result = MessageBox.Show(Messages.AreYouSureTheExitThisGame, "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            Close();
            Model = new Model();
            EnterGame first = new EnterGame();
            PlayerRegister register = new PlayerRegister();
            first.ShowDialog();
        }

        private void OutGame(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HumanGameClick(object sender, RoutedEventArgs e)
        {
            Model.ComputerGame = false;
        }

        private void ComputerGameClick(object sender, RoutedEventArgs e)
        {
            Model.HumanGame = false;

        }

        void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ApproveClick(sender, e);
            Model.Players.FirstOrDefault().Round = true;
            PlayerRoundInfo.Text = $" {Model.Players.FirstOrDefault().Name}";
            PlayerInfoCard.Background = new Helper().GetPlayerColor(Model.Players.FirstOrDefault());
        }

        private void Root_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Popup != null && Popup.IsOpen)
            {
                Popup.IsOpen = false;
            }

        }

        Player ChangePlayer(Player player)
        {
            Model.Players.All(x => { x.Round = false; return true; });

            var tempId = player.Id < 2 ? player.Id : 0;

            Model.Players.Where(x => x.Id == tempId + 1).FirstOrDefault().Round = true;

            var playingPlayer = Model.Players.Where(x => x.Round == true).FirstOrDefault() as Player;
            PlayerInfoCard.Background = new Helper().GetPlayerColor(playingPlayer);

            return playingPlayer;
        }

        private void Faq_Click(object sender, RoutedEventArgs e)
        {
            new AboutGame().Show();
        }

        private void SoundSetting_Click(object sender, RoutedEventArgs e)
        {
            var chkBox = sender as ToggleButton;
            if (chkBox.IsChecked == true)
            {
                Model.IsSosSoundActive = true;

            }
            else
            {
                Model.IsSosSoundActive = false;
            }
        }

        private void Music_Clik(object sender, RoutedEventArgs e)
        {
            var chkBox = sender as ToggleButton;
            if (chkBox.IsChecked == true)
            {
                Model.IsMusicActive = true;

            }
            else
            {
                Model.IsMusicActive = false;
            }
            new SoundController(Model).PlayGameMusic();
        }

        private void Timer_Click(object sender, RoutedEventArgs e)
        {
            var chkBox = sender as ToggleButton;
            if (chkBox.IsChecked == true)
            {
                Model.IsTimerActive = true;
                TimerStackPannel.Visibility = Visibility.Visible;
            }
            else
            {
                TimerStackPannel.Visibility = Visibility.Hidden;
                Model.IsTimerActive = false;
                chkBox.IsEnabled = false;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }


}
