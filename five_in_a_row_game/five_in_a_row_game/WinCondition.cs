using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace five_in_a_row_game
{
    class WinCondition
    {
        int[,] array;
        int x;
        int y;

        public bool pounce_in_the_window(int[,] arr, int picked_x, int picked_y)
        {
            array = new int[arr.GetLength(0) + 2, arr.GetLength(1) + 2];
            for (int i = 0; i < arr.GetLength(0) + 2; i++)
            {
                for (int j = 0; j < arr.GetLength(1) + 2; j++)
                {
                    array[i, j] = 4;
                }
            }
            for (int i = 1; i <= arr.GetLength(0); i++)
            {
                for (int j = 1; j <= arr.GetLength(1); j++)
                {
                    array[i, j] = arr[i - 1, j - 1];
                }
            }

            x = picked_x + 1;
            y = picked_y + 1;

            return end_of_the_game();
        }

        private bool end_of_the_game()
        {
            int state;
            int in_a_row = 0;
            int x_now;
            int y_now;
            List<List<int>> squares_w_solutions = new List<List<int>>();

            state = array[x, y];
            for (int x_coord = x - 1; x_coord < x + 2; x_coord++)
            {
                for (int y_coord = y - 1; y_coord < y + 2; y_coord++)
                {
                    if (x_coord == x && y_coord == y)
                    {
                        continue;
                    }
                    else
                    {
                        if (array[x_coord, y_coord] == state)
                        {
                            List<int> for_records = new List<int>();
                            for_records.Add(x_coord);
                            for_records.Add(y_coord);
                            squares_w_solutions.Add(for_records);
                        }
                    }
                }
            }

            if (squares_w_solutions.Count() == 0)
            {
                return false;
            }

            for (int i = 0; i < squares_w_solutions.Count(); i++)
            {
                in_a_row = 0;
                bool direction = false;
                x_now = squares_w_solutions[i][0];
                y_now = squares_w_solutions[i][1];

                if (x == x_now)
                {
                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if(in_a_row == 5)
                        {
                            return true;
                        }

                        if (y < y_now)
                        {
                            y_now++;
                            direction = true;
                        }
                        else
                        {
                            y_now--;
                            direction = false;
                        }
                    }
                    y_now = squares_w_solutions[i][1];
                    if (direction)
                    {
                        y_now--;
                        while (array[x_now, y_now] == state)
                        {
                            in_a_row++;

                            if (in_a_row == 5)
                            {
                                return true;
                            }

                            y_now--;
                        }
                    }
                    else
                    {
                        y_now++;
                        while (array[x_now, y_now] == state)
                        {
                            in_a_row++;

                            if (in_a_row == 5)
                            {
                                return true;
                            }

                            y_now++;
                        }
                    }
                }

                else if (y == y_now)
                {
                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if (in_a_row == 5)
                        {
                            return true;
                        }

                        if (x < x_now)
                        {
                            x_now++;
                            direction = true;
                        }
                        else
                        {
                            x_now--;
                            direction = false;
                        }
                    }
                    x_now = squares_w_solutions[i][0];
                    if (direction)
                    {
                        x_now--;
                        while (array[x_now, y_now] == state)
                        {
                            in_a_row++;

                            if (in_a_row == 5)
                            {
                                return true;
                            }

                            x_now--;
                        }
                    }
                    else
                    {
                        x_now++;
                        while (array[x_now, y_now] == state)
                        {
                            in_a_row++;

                            if (in_a_row == 5)
                            {
                                return true;
                            }

                            x_now++;
                        }
                    }
                }

                else if (y == y_now - 1 && x == x_now - 1)
                {
                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if (in_a_row == 5)
                        {
                            return true;
                        }
                
                        x_now--;
                        y_now--;
                    }

                    x_now = squares_w_solutions[i][0];
                    y_now = squares_w_solutions[i][1];
                    x_now++;
                    y_now++;

                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if (in_a_row == 5)
                        {
                            return true;
                        }

                        x_now++;
                        y_now++;
                    }
                }

                else if (y == y_now + 1 && x == x_now + 1)
                {
                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if (in_a_row == 5)
                        {
                            return true;
                        }

                        x_now++;
                        y_now++;
                    }

                    x_now = squares_w_solutions[i][0];
                    y_now = squares_w_solutions[i][1];
                    x_now--;
                    y_now--;

                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if (in_a_row == 5)
                        {
                            return true;
                        }

                        x_now--;
                        y_now--;
                    }
                }

                else if (y == y_now - 1 && x == x_now + 1)
                {
                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if (in_a_row == 5)
                        {
                            return true;
                        }

                        x_now++;
                        y_now--;
                    }

                    x_now = squares_w_solutions[i][0];
                    y_now = squares_w_solutions[i][1];
                    x_now--;
                    y_now++;

                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if (in_a_row == 5)
                        {
                            return true;
                        }

                        x_now--;
                        y_now++;
                    }
                }

                else if (y == y_now + 1 && x == x_now - 1)
                {
                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if (in_a_row == 5)
                        {
                            return true;
                        }

                        x_now--;
                        y_now++;
                    }

                    x_now = squares_w_solutions[i][0];
                    y_now = squares_w_solutions[i][1];
                    x_now++;
                    y_now--;

                    while (array[x_now, y_now] == state)
                    {
                        in_a_row++;

                        if (in_a_row == 5)
                        {
                            return true;
                        }

                        x_now++;
                        y_now--;
                    }
                }
            }


            return false;
        }
    }
}
