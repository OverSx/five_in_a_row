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

namespace five_in_a_row_game
{
    /// <summary>
    /// Логика взаимодействия для letPlay_field.xaml
    /// </summary>
    public partial class letPlay_field : Window
    {
        // 0 - можно ходить
        // 1 - человек сходил
        // 2 - бот сходил

        Grid workingGrid = new Grid();
        int width_of_field;
        int height_of_field;
        Button[,] field_for_play;
        int[,] array;
        List<int> bot_coord = new List<int>(); //x(строка) координата для бота - 0 индекс, y(столбец) координата - 1 индекс

        public letPlay_field(Grid mainGrid, int width, int height)
        {
            workingGrid = mainGrid;
            width_of_field = width;
            height_of_field = height;
            InitializeComponent();
            ini_of_game();
            array = new int[height_of_field, width_of_field];

            for (int i = 0; i < height_of_field; i++)
            {
                for(int j = 0; j < width_of_field; j++)
                {
                    array[i, j] = 0;
                }
            }
        }

        private void ini_of_game()
        {
            int k = 0;
            field_for_play = new Button[height_of_field, width_of_field];

            for (int i = 0; i < height_of_field; i++)
            {
                for (int j = 0; j < width_of_field; j++)
                {
                    field_for_play[i, j] = workingGrid.Children[k] as Button;
                    k++;
                }
            }

            foreach(var b in field_for_play)
            {
                b.Click += btn_player_Click;
            }
        }

        private void btn_player_Click(object sender, RoutedEventArgs e)
        {
            Button thisButton = (Button)e.OriginalSource;
            if (array[(int)thisButton.GetValue(Grid.RowProperty), (int)thisButton.GetValue(Grid.ColumnProperty)] == 0)
            {
                if (height_of_field <= 10 || width_of_field <= 10)
                {
                    thisButton.FontSize = 60;
                }
                else if (height_of_field <= 20 || width_of_field <= 20)
                {
                    thisButton.FontSize = 35;
                }
                thisButton.Content = "X";

                array[(int)thisButton.GetValue(Grid.RowProperty), (int)thisButton.GetValue(Grid.ColumnProperty)] = 1;

                //bot_coord = ; //Тут ходит бот

                if (height_of_field <= 10 || width_of_field <= 10)
                {
                    field_for_play[bot_coord[0], bot_coord[1]].FontSize = 60;
                }
                else if (height_of_field <= 20 || width_of_field <= 20)
                {
                    field_for_play[bot_coord[0], bot_coord[1]].FontSize = 35;
                }
                field_for_play[bot_coord[0], bot_coord[1]].Content = "O";

                array[bot_coord[0], bot_coord[1]] = 2;
            }
            else
            {
                MessageBox.Show("Занято нахой!!!");
            }
            
        }
    }
}
