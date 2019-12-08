using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace five_in_a_row_game
{
    class playinig_field
    {

        private Grid myGrid(int width, int height)
        {
            Grid playingGrid = new Grid();

            for(int i = 0; i < height; i++)
            {
                playingGrid.RowDefinitions.Add(new RowDefinition());
            }

            for(int i = 0; i < width; i++)
            {
                playingGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            playingGrid.ShowGridLines = true;
            if (height <= 10 || width <= 10)
            {
                playingGrid.Height = height * 100;
                playingGrid.Width = width * 100;
            }
            else if (height <= 20 || width <= 20)
            {
                playingGrid.Height = height * 50;
                playingGrid.Width = width * 50;
            }
            playingGrid.VerticalAlignment = VerticalAlignment.Stretch;
            playingGrid.HorizontalAlignment = HorizontalAlignment.Stretch;

            for(int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Button element = new Button();
                    playingGrid.Children.Add(element);
                    Grid.SetRow(element, i);
                    Grid.SetColumn(element, j);
                }
            }

            return playingGrid;
        }

        public void new_window(int width, int height)
        {
            Grid newGrid = new Grid();
            newGrid = myGrid(width, height);

            letPlay_field newField = new letPlay_field(newGrid, width, height);

            newField.Height = newGrid.Height + 42;
            newField.Width = newGrid.Width + 20;
            newField.GridForLife.Children.Insert(0, newGrid);

            newField.ShowDialog();
        }
    }
}
