using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PacMania_OneEnemy_NoGraphics_Scalable
{
    /// <summary>
    /// Interaction logic for GameArea.xaml
    /// </summary>
    public partial class GameArea : Window
    {
        private Model _model;
        private ObjectType[,] map;
        private Ellipse[,] coins;
        private Rectangle pacMan;
        private Rectangle[] _monsterRectangles;
        private int _pacManXCoordinates;
        private int _pacManYCoordinates;

        private int _score;

        public GameArea()
        {
            _model = new Model();
            InitializeComponent();
            DataContext = _model;
            // build the grid map with 19 rows and 19 columns
            map = new ObjectType[Model.RowCount, Model.ColCount];
            // create a new ellipse object of type array to implement coins in each white space
            coins = new Ellipse[Model.RowCount, Model.ColCount];

            //create 1st AI Monster
            _monsterRectangles = new Rectangle[1];
            //Call Fill Map to create the walls and borders for the game
            FillMap();
            CreateMap();

            InitialiseMonsters();
        }

        private void FillMap()
        {
            // [column, row]
            map[1, 1] = ObjectType.Packman;
            map[9, 1] = ObjectType.Obstacle;

            map[2, 2] = ObjectType.Obstacle;
            map[3, 2] = ObjectType.Obstacle;
            map[5, 2] = ObjectType.Obstacle;
            map[6, 2] = ObjectType.Obstacle;
            map[7, 2] = ObjectType.Obstacle;
            map[9, 2] = ObjectType.Obstacle;
            map[11, 2] = ObjectType.Obstacle;
            map[12, 2] = ObjectType.Obstacle;
            map[13, 2] = ObjectType.Obstacle;
            map[15, 2] = ObjectType.Obstacle;
            map[16, 2] = ObjectType.Obstacle;

            map[2, 3] = ObjectType.Obstacle;
            map[3, 3] = ObjectType.Obstacle;
            map[5, 3] = ObjectType.Obstacle;
            map[6, 3] = ObjectType.Obstacle;
            map[7, 3] = ObjectType.Obstacle;
            map[9, 3] = ObjectType.Obstacle;
            map[11, 3] = ObjectType.Obstacle;
            map[12, 3] = ObjectType.Obstacle;
            map[13, 3] = ObjectType.Obstacle;
            map[15, 3] = ObjectType.Obstacle;
            map[16, 3] = ObjectType.Obstacle;

            map[2, 5] = ObjectType.Obstacle;
            map[3, 5] = ObjectType.Obstacle;
            map[5, 5] = ObjectType.Obstacle;
            map[7, 5] = ObjectType.Obstacle;
            map[8, 5] = ObjectType.Obstacle;
            map[9, 5] = ObjectType.Obstacle;
            map[10, 5] = ObjectType.Obstacle;
            map[11, 5] = ObjectType.Obstacle;
            map[13, 5] = ObjectType.Obstacle;
            map[15, 5] = ObjectType.Obstacle;
            map[16, 5] = ObjectType.Obstacle;

            map[5, 6] = ObjectType.Obstacle;
            map[9, 6] = ObjectType.Obstacle;
            map[13, 6] = ObjectType.Obstacle;

            map[1, 7] = ObjectType.Obstacle;
            map[2, 7] = ObjectType.Obstacle;
            map[3, 7] = ObjectType.Obstacle;
            map[5, 7] = ObjectType.Obstacle;
            map[6, 7] = ObjectType.Obstacle;
            map[7, 7] = ObjectType.Obstacle;
            map[9, 7] = ObjectType.Obstacle;
            map[11, 7] = ObjectType.Obstacle;
            map[12, 7] = ObjectType.Obstacle;
            map[13, 7] = ObjectType.Obstacle;
            map[15, 7] = ObjectType.Obstacle;
            map[16, 7] = ObjectType.Obstacle;
            map[17, 7] = ObjectType.Obstacle;

            map[5, 8] = ObjectType.Obstacle;
            map[13, 8] = ObjectType.Obstacle;

            map[5, 9] = ObjectType.Obstacle;
            map[8, 9] = ObjectType.Obstacle;
            map[10, 9] = ObjectType.Obstacle;
            map[13, 9] = ObjectType.Obstacle;

            map[5, 10] = ObjectType.Obstacle;
            map[13, 10] = ObjectType.Obstacle;

            map[1, 11] = ObjectType.Obstacle;
            map[2, 11] = ObjectType.Obstacle;
            map[3, 11] = ObjectType.Obstacle;
            map[5, 11] = ObjectType.Obstacle;
            map[6, 11] = ObjectType.Obstacle;
            map[7, 11] = ObjectType.Obstacle;
            map[9, 11] = ObjectType.Obstacle;
            map[11, 11] = ObjectType.Obstacle;
            map[12, 11] = ObjectType.Obstacle;
            map[13, 11] = ObjectType.Obstacle;
            map[15, 11] = ObjectType.Obstacle;
            map[16, 11] = ObjectType.Obstacle;
            map[17, 11] = ObjectType.Obstacle;

            map[5, 12] = ObjectType.Obstacle;
            map[9, 12] = ObjectType.Obstacle;
            map[13, 12] = ObjectType.Obstacle;

            map[2, 13] = ObjectType.Obstacle;
            map[3, 13] = ObjectType.Obstacle;
            map[5, 13] = ObjectType.Obstacle;
            map[7, 13] = ObjectType.Obstacle;
            map[8, 13] = ObjectType.Obstacle;
            map[9, 13] = ObjectType.Obstacle;
            map[10, 13] = ObjectType.Obstacle;
            map[11, 13] = ObjectType.Obstacle;
            map[13, 13] = ObjectType.Obstacle;
            map[15, 13] = ObjectType.Obstacle;
            map[16, 13] = ObjectType.Obstacle;

            map[2, 15] = ObjectType.Obstacle;
            map[3, 15] = ObjectType.Obstacle;
            map[5, 15] = ObjectType.Obstacle;
            map[6, 15] = ObjectType.Obstacle;
            map[7, 15] = ObjectType.Obstacle;
            map[9, 15] = ObjectType.Obstacle;
            map[11, 15] = ObjectType.Obstacle;
            map[12, 15] = ObjectType.Obstacle;
            map[13, 15] = ObjectType.Obstacle;
            map[15, 15] = ObjectType.Obstacle;
            map[16, 15] = ObjectType.Obstacle;

            map[2, 16] = ObjectType.Obstacle;
            map[3, 16] = ObjectType.Obstacle;
            map[5, 16] = ObjectType.Obstacle;
            map[6, 16] = ObjectType.Obstacle;
            map[7, 16] = ObjectType.Obstacle;
            map[9, 16] = ObjectType.Obstacle;
            map[11, 16] = ObjectType.Obstacle;
            map[12, 16] = ObjectType.Obstacle;
            map[13, 16] = ObjectType.Obstacle;
            map[15, 16] = ObjectType.Obstacle;
            map[16, 16] = ObjectType.Obstacle;
            map[9, 17] = ObjectType.Obstacle;

            map[4, 4] = ObjectType.Monster;

            //Call the FillBorderLines method to fill the borders of the game
            FillBorderLines(map, "x", 0);
            FillBorderLines(map, "x", Model.RowCount - 1);
            FillBorderLines(map, "y", 0);
            FillBorderLines(map, "y", Model.ColCount - 1);
        }

        private void FillBorderLines(ObjectType[,] mapBord, string direction, int startPoint)
        {
            var count = 0;
            switch (direction)
            {
                case "x":
                    count = Model.RowCount;
                    break;
                case "y":
                    count = Model.ColCount;
                    break;
            }

            for (int i = 0; i < count; i++)
            {
                switch (direction)
                {
                    case "x":
                        mapBord[startPoint, i] = ObjectType.Obstacle;
                        break;
                    case "y":
                        mapBord[i, startPoint] = ObjectType.Obstacle;
                        break;
                }
            }
        }

        //Create global instance of monsters
        List<Monster> monsters = new List<Monster>();


        private void CreateMap()
        {
            //_Monsters = new Monster[2];
            //var monsterIndex = 0;

            for (int x = 0; x < Model.RowCount; x++)
            {
                for (int y = 0; y < Model.ColCount; y++)
                {

                    var obj = map[x, y];

                    if (obj == ObjectType.Coin)
                    {
                        //populate white spaces with coins
                        var coin = GetCoin();
                        Map.Children.Add(coin);

                        var xCor = (Model.FixedDimension - coin.Width) / 2;
                        var yCor = (Model.FixedDimension - coin.Height) / 2;

                        Canvas.SetLeft(coin, (x * _model.dimension) + yCor);
                        Canvas.SetTop(coin, (y * _model.dimension) + xCor);

                        coins[x, y] = coin;
                        continue;
                    }

                    var shape = GetObject(obj);

                    if (obj == ObjectType.Packman)
                    {
                        shape.Name = "pacMan";
                    }

                    if (obj == ObjectType.Monster)
                    {
                        _monsterRectangles[_monsterRectangles.Length - 1] = shape;
                        //Count the monster index

                        //_Monsters[monsterIndex] = new Monster(shape, x, y);
                        //monsterIndex++;
                    }

                    Map.Children.Add(shape);
                    Canvas.SetLeft(shape, (x * _model.dimension));
                    Canvas.SetTop(shape, (y * _model.dimension));

                    if (obj == ObjectType.Packman)
                    {
                        pacMan = shape;
                        Canvas.SetZIndex(pacMan, (int)999);

                        _pacManXCoordinates = x;
                        _pacManYCoordinates = y;
                    }
                }
            }
        }

        private Ellipse GetCoin()
        {
            return new Ellipse()
            {
                Width = 8,
                Height = 8,
                Fill = Brushes.Yellow
            };
        }

        private Rectangle GetObject(ObjectType type)
        {
            var brush = Brushes.AliceBlue;

            switch (type)
            {
                case ObjectType.Packman:
                    brush = Brushes.Green;
                    break;
                case ObjectType.Obstacle:
                    brush = Brushes.Blue;
                    break;
                case ObjectType.Monster:
                    brush = Brushes.Red;
                    break;
                default:
                    break;
            }

            return new Rectangle()
            {
                Width = _model.dimension,
                Height = _model.dimension,
                Fill = brush
            };
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    if (!IsHitObstacle(e.Key))
                    {
                        Canvas.SetLeft(pacMan, Canvas.GetLeft(pacMan) - _model.dimension);
                        UpdateSpaceToPacManTrace();
                        _pacManXCoordinates--;
                        IsHitToCoin();
                        IsHitToMonster();
                    }
                    break;
                case Key.Right:
                    if (!IsHitObstacle(e.Key))
                    {
                        Canvas.SetLeft(pacMan, Canvas.GetLeft(pacMan) + _model.dimension);
                        UpdateSpaceToPacManTrace();
                        _pacManXCoordinates++;
                        IsHitToCoin();
                        IsHitToMonster();
                    }
                    break;
                case Key.Up:
                    if (!IsHitObstacle(e.Key))
                    {
                        Canvas.SetTop(pacMan, Canvas.GetTop(pacMan) - _model.dimension);
                        UpdateSpaceToPacManTrace();
                        _pacManYCoordinates--;
                        IsHitToCoin();
                        IsHitToMonster();
                    }
                    break;
                case Key.Down:
                    if (!IsHitObstacle(e.Key))
                    {
                        Canvas.SetTop(pacMan, Canvas.GetTop(pacMan) + _model.dimension);
                        UpdateSpaceToPacManTrace();
                        _pacManYCoordinates++;
                        IsHitToCoin();
                        IsHitToMonster();
                    }
                    break;
            }
            //map[_pacManYCoordinates, _pacManXCoordinates] = ObjectType.Packman;
        }

        private void UpdateSpaceToPacManTrace()
        {
            map[_pacManXCoordinates, _pacManYCoordinates] = ObjectType.Space;
        }

        private void InitialiseMonsters()
        {

            for (int i = 0; i < _monsterRectangles.Length; i++)
            {
                monsters.Add(new Monster(_monsterRectangles[i], 4, 4));
                //monsters.Add(new Monster(_monsterRectangles[i], 12, 4));
                //monsters.Add(new Monster(_monsterRectangles[i], 8, 4));

            }

            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            timer.Start();

            Console.WriteLine("Show map coordiantes");
            for (int x = 0; x < Model.RowCount; x++)
            {
                for (int y = 0; y < Model.ColCount; y++)
                {
                    Console.WriteLine($"x:{x}, y:{y}, obj:{map[x, y]}");
                }
            }

            timer.Tick += (sender, args) =>
            {
                for (int i = 0; i < monsters.Count; i++)
                {
                    monsters[i].Move(map);
                }
            };
        }

        private bool IsHitObstacle(Key key)
        {
            ObjectType obj = ObjectType.Coin;

            switch (key)
            {
                case Key.Left:
                    obj = map[_pacManXCoordinates - 1, _pacManYCoordinates];
                    break;
                case Key.Right:
                    obj = map[_pacManXCoordinates + 1, _pacManYCoordinates];
                    break;
                case Key.Up:
                    obj = map[_pacManXCoordinates, _pacManYCoordinates - 1];
                    break;
                case Key.Down:
                    obj = map[_pacManXCoordinates, _pacManYCoordinates + 1];
                    break;
            }

            return obj == ObjectType.Obstacle;
        }

        private void IsHitToCoin()
        {
            var obj = map[_pacManXCoordinates, _pacManYCoordinates];

            if (obj == ObjectType.Coin)
            {
                _score++;
                tbScore.Text = _score.ToString("000");
                map[_pacManXCoordinates, _pacManYCoordinates] = ObjectType.Space;

                var coin = coins[_pacManXCoordinates, _pacManYCoordinates];
                Map.Children.Remove(coin);
            }
            //Display WinForm for the new condition
            int counter = _score;
            if (counter >= 179)
            {
                YouWin win = new YouWin();
                App.Current.MainWindow = win;
                this.Close();
                win.Show();

            }
        }

        public void IsHitToMonster()
        {

            var obj = map[_pacManXCoordinates, _pacManYCoordinates];
            foreach (var item in monsters)
            {
                if (item.xpos == _pacManXCoordinates && item.ypos == _pacManYCoordinates)
                {
                    YouLose lose = new YouLose();
                    App.Current.MainWindow = lose;
                    this.Close();
                    lose.Show();
                }
            }
        }

    }
}
