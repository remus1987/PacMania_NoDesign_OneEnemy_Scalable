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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PacMania_OneEnemy_NoGraphics_Scalable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void HighScoreBtnClick(object sender, EventArgs e)
        {
            HighScores form = new HighScores();
            form.Show();
        }

        private void PlayBtnClick(object sender, EventArgs e)
        {
            GameArea form = new GameArea();
            form.Show();
        }
    }
}
