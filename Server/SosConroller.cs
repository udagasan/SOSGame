using Common;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace Server
{

    public class SosConroller
    {
        public SolidColorBrush Color { get; set; }

        public Grid MainWindowGrid { get; set; }
        public Grid SubGrid { get; set; }
        public SosConroller(Grid MainWindowGrid, Grid subGrid, Model model)
        {
            this.MainWindowGrid = MainWindowGrid;
            SubGrid = subGrid;
            Model = model;
            Color = new Helper().GetPlayerColor(Model.Players.Where(x => x.Round == true).FirstOrDefault());
        }
        public Model Model { get; set; }
        public Tuple<bool, int> Check(TableMatrix selectedItem)
        {
            int counter = 0;
            Tuple<bool, int> returnValue = new Tuple<bool, int>(false, counter);
            if (selectedItem.Content == "O")
            {
                if (ControlHorizantalForO(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlVerticalForO(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlLeftDiagonalForO(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlRightDiagonalForO(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (counter > 0)
                {
                    returnValue = new Tuple<bool, int>(true, counter);

                }
                return returnValue;


            }
            else if (selectedItem.Content == "S")
            {
                if (ControlLeftHorizantalForS(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlRightHorizantalForS(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlBottomVerticalForS(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlTopVerticalForS(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlTopLeftDiagonalForS(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlTopRightDiagonalForS(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlBottomLeftDiagonalForS(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (ControlBottomRightDiagonalForS(selectedItem.Row, selectedItem.Column))
                {
                    counter++;
                }
                if (counter > 0)
                {
                    returnValue = new Tuple<bool, int>(true, counter);

                }
            }
            return returnValue;
        }

        int FindIndex(int row, int column)
        {
            return row * Model.RowCount + column;
        }


        public bool ControlLeftHorizantalForS(int row, int column)
        {
            return Control_S(row, column - 1, row, column - 2, row, column);
        }
        public bool ControlRightHorizantalForS(int row, int column)
        {
            return Control_S(row, column + 1, row, column + 2, row, column);
        }
        public bool ControlBottomVerticalForS(int row, int column)
        {
            return Control_S(row + 1, column, row + 2, column, row, column);
        }
        public bool ControlTopVerticalForS(int row, int column)
        {
            return Control_S(row - 1, column, row - 2, column, row, column);
        }
        public bool ControlTopLeftDiagonalForS(int row, int column)
        {
            return Control_S(row - 1, column - 1, row - 2, column - 2, row, column);
        }
        public bool ControlTopRightDiagonalForS(int row, int column)
        {
            return Control_S(row - 1, column + 1, row - 2, column + 2, row, column);
        }
        public bool ControlBottomLeftDiagonalForS(int row, int column)
        {
            return Control_S(row + 1, column - 1, row + 2, column - 2, row, column);

        }
        public bool ControlBottomRightDiagonalForS(int row, int column)
        {
            return Control_S(row + 1, column + 1, row + 2, column + 2, row, column);
        }

        public bool ControlHorizantalForO(int row, int column)
        {
            return Control_O(row, column - 1, row, column + 1, row, column);
        }
        public bool ControlVerticalForO(int row, int column)
        {
            return Control_O(row - 1, column, row + 1, column, row, column);
        }
        public bool ControlLeftDiagonalForO(int row, int column)
        {
            return Control_O(row - 1, column - 1, row + 1, column + 1, row, column);
        }
        public bool ControlRightDiagonalForO(int row, int column)
        {
            return Control_O(row - 1, column + 1, row + 1, column - 1, row, column);
        }
        public bool ControlRowAndColumnSize(int row, int column)
        {
            return row < Model.RowCount && column < Model.ColumnCount && row >= 0 && column >= 0;
        }

        public bool Control_O(int row1, int column1, int row2, int column2, int selectedRow, int selectedColumn)
        {
            if (!ControlRowAndColumnSize(row1, column1) || !ControlRowAndColumnSize(row2, column2))
            {
                return false;
            }
            var grid1 = MainWindowGrid.Children[FindIndex(row1, column1)] as Grid;
            var grid2 = MainWindowGrid.Children[FindIndex(row2, column2)] as Grid;
            var butn1 = grid1.Children[0] as Button;
            var butn2 = grid2.Children[0] as Button;
            if (butn1.Content?.ToString() == "S" && butn2.Content?.ToString() == "S")
            {
                if (row1 == row2 && row1 == selectedRow)
                {
                    new Drawer(grid1, Color, Model).DrawLineVertical();
                    new Drawer(SubGrid, Color, Model).DrawLineVertical();
                    new Drawer(grid2, Color, Model).DrawLineVertical();
                    new SoundController(Model).PlaySosSound();

                }
                else if (column1 == column2 && column2 == selectedColumn)
                {
                    new Drawer(grid1, Color, Model).DrawLineHorizontal();
                    new Drawer(SubGrid, Color, Model).DrawLineHorizontal();
                    new Drawer(grid2, Color, Model).DrawLineHorizontal();
                    new SoundController(Model).PlaySosSound();

                }
                else if (row2 > row1 && column2 > column1)
                {
                    new Drawer(grid1, Color, Model).DrawLineLeftDiagonal();
                    new Drawer(SubGrid, Color, Model).DrawLineLeftDiagonal();
                    new Drawer(grid2, Color, Model).DrawLineLeftDiagonal();
                    new SoundController(Model).PlaySosSound();

                }
                else if (row1 < row2 && column1 > column2)
                {
                    new Drawer(grid1, Color, Model).DrawLineRightDiagonal();
                    new Drawer(SubGrid, Color, Model).DrawLineRightDiagonal();
                    new Drawer(grid2, Color, Model).DrawLineRightDiagonal();
                    new SoundController(Model).PlaySosSound();

                }
                return true;
            }
            return false;
        }
        public bool Control_S(int row1, int column1, int row2, int column2, int selectedRow, int selectedColumn)
        {
            if (!ControlRowAndColumnSize(row1, column1) || !ControlRowAndColumnSize(row2, column2))
            {
                return false;
            }

            var grid1 = MainWindowGrid.Children[FindIndex(row1, column1)] as Grid;
            var grid2 = MainWindowGrid.Children[FindIndex(row2, column2)] as Grid;
            var btn1 = grid1.Children[0] as Button;
            var btn2 = grid2.Children[0] as Button;
            if (btn1.Content?.ToString() == "O" && btn2.Content?.ToString() == "S")
            {
                if (row1 == row2 && row1 == selectedRow)
                {
                    new Drawer(grid1, Color, Model).DrawLineVertical();
                    new Drawer(SubGrid, Color, Model).DrawLineVertical();
                    new Drawer(grid2, Color, Model).DrawLineVertical();
                    new SoundController(Model).PlaySosSound();

                }
                else if (column1 == column2 && column2 == selectedColumn)
                {
                    new Drawer(grid1, Color, Model).DrawLineHorizontal();
                    new Drawer(SubGrid, Color, Model).DrawLineHorizontal();
                    new Drawer(grid2, Color, Model).DrawLineHorizontal();
                    new SoundController(Model).PlaySosSound();

                }
                else if ((row2 > row1 && column2 < column1) || (row2 < row1 && column2 > column1))
                {
                    new Drawer(grid1, Color, Model).DrawLineRightDiagonal();
                    new Drawer(SubGrid, Color, Model).DrawLineRightDiagonal();
                    new Drawer(grid2, Color, Model).DrawLineRightDiagonal();
                    new SoundController(Model).PlaySosSound();

                }
                else if ((row1 > row2 && column1 > column2) || (row2 > row1 && column2 > column1))
                {
                    new Drawer(grid1, Color, Model).DrawLineLeftDiagonal();
                    new Drawer(SubGrid, Color, Model).DrawLineLeftDiagonal();
                    new Drawer(grid2, Color, Model).DrawLineLeftDiagonal();
                    new SoundController(Model).PlaySosSound();

                }



                return true;
            }
            return false;
        }


    }
}
