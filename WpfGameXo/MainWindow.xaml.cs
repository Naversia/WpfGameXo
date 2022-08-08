using Logic;
using System.Windows;
using System.Windows.Controls;

namespace WpfGameXo
{
    public partial class MainWindow : Window
    {
        bool xTurnBtn;
        XoGame xoGame = new XoGame();

        public MainWindow()
        {
            InitializeComponent();
            BuildGame();
        }

        private void BuildGame()
        {
            xTurnBtn = false;
            xoGame = new XoGame();
            Grid grid = new Grid();
            //grid.Width = 470;
            //grid.Height = 470;
            for (int i = 0; i < 4; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
            }
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var btnStartGame = new Button();
                    if (i == 3)
                    {
                        Grid.SetRow(btnStartGame, 3);
                        Grid.SetColumnSpan(btnStartGame, 3);
                       
                        grid.Children.Add(btnStartGame);
                        btnStartGame.Click += NewGame;
                        btnStartGame.Style = (Style)App.Current.Resources["btnStartGame"];
                    }
                    if(i != 3)
                    {
                        var btn = new Button();
                        btn.Style = (Style)App.Current.Resources["defTurn"];
                       btn.Click += GameXoClick;
                        Grid.SetRow(btn, i);
                        Grid.SetColumn(btn, j);
                        grid.Children.Add(btn);
                    }
                }
            }
            Content = grid;
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            BuildGame();
        }

        private void GameXoClick(object sender, RoutedEventArgs e)
        {
            xTurnBtn = !xTurnBtn;

            if (sender is Button btn)
            {
                var row = Grid.GetRow(btn);
                var col = Grid.GetColumn(btn);
                var res = xoGame.SendTurn(xTurnBtn, row, col);

                btn.Style = (Style)App.Current.Resources[xTurnBtn ? "xTurnBtn" : "oTurnBtn"];
                btn.Click -= GameXoClick;

                if (res != null)
                {
                    MessageBox.Show($"The winner is {res}");
                    BuildGame();
                }

            }
        }
    }
}