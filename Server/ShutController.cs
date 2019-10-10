using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Server
{
    public class ShutController
    {
        public Grid MainWindowGrid { get; set; }
        public Grid SubGrid { get; set; }
        public ShutController(Grid MainWindowGrid, Model model)
        {
            this.MainWindowGrid = MainWindowGrid;
            Model = model;
        }
        public Model Model { get; set; }

        int FindIndex(int row, int column)
        {
            return row * Model.RowCount + column;
        }

        public bool ControlLeftHorizantalForS_WithoutDraw(int row, int column)
        {
            return Control_S_Without_Draw(row, column - 1, row, column - 2, row, column);
        }
        public bool ControlRightHorizantalForS_WithoutDraw(int row, int column)
        {
            return Control_S_Without_Draw(row, column + 1, row, column + 2, row, column);
        }
        public bool ControlBottomVerticalForS_WithoutDraw(int row, int column)
        {
            return Control_S_Without_Draw(row + 1, column, row + 2, column, row, column);
        }
        public bool ControlTopVerticalForS_WithoutDraw(int row, int column)
        {
            return Control_S_Without_Draw(row - 1, column, row - 2, column, row, column);
        }
        public bool ControlTopLeftDiagonalForS_WithoutDraw(int row, int column)
        {
            return Control_S_Without_Draw(row - 1, column - 1, row - 2, column - 2, row, column);
        }
        public bool ControlTopRightDiagonalForS_WithoutDraw(int row, int column)
        {
            return Control_S_Without_Draw(row - 1, column + 1, row - 2, column + 2, row, column);
        }
        public bool ControlBottomLeftDiagonalForS_WithoutDraw(int row, int column)
        {
            return Control_S_Without_Draw(row + 1, column - 1, row + 2, column - 2, row, column);

        }
        public bool ControlBottomRightDiagonalForS_WithoutDraw(int row, int column)
        {
            return Control_S_Without_Draw(row + 1, column + 1, row + 2, column + 2, row, column);
        }

        public bool ControlHorizantalForO_WithoutDraw(int row, int column)
        {
            return Control_O_Without_Draw(row, column - 1, row, column + 1, row, column);
        }
        public bool ControlVerticalForO_WithoutDraw(int row, int column)
        {
            return Control_O_Without_Draw(row - 1, column, row + 1, column, row, column);
        }
        public bool ControlLeftDiagonalForO_WithoutDraw(int row, int column)
        {
            return Control_O_Without_Draw(row - 1, column - 1, row + 1, column + 1, row, column);
        }
        public bool ControlRightDiagonalForO_WithoutDraw(int row, int column)
        {
            return Control_O_Without_Draw(row - 1, column + 1, row + 1, column - 1, row, column);
        }

        public bool Control_O_Without_Draw(int row1, int column1, int row2, int column2, int selectedRow, int selectedColumn)
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
                return true;
            }
            return false;
        }
        public bool Control_S_Without_Draw(int row1, int column1, int row2, int column2, int selectedRow, int selectedColumn)
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
                return true;
            }
            return false;
        }

        public bool ControlRowAndColumnSize(int row, int column)
        {
            return row < Model.RowCount && column < Model.ColumnCount && row >= 0 && column >= 0;
        }

        internal int ControlIsAroundFreeForCharValue(TableMatrix item, string hand, GameLevel gameLevel)
        {

            int sosPosibilityCount = 0;
            var row = item.Row;
            var rowMinesOne = item.Row - 1;
            var rowPlusOne = item.Row + 1;
            var rowMinesTwo = item.Row - 2;
            var rowPlusTwo = item.Row + 2;
            var column = item.Column;
            var columnMinesOne = item.Column - 1;
            var columnPlusOne = item.Column + 1;
            var columnMinesTwo = item.Column - 2;
            var columnPlusTwo = item.Column + 2;

            var level1LeftTop = Model.GridMatrix.Where(x => x.Row == rowMinesOne && x.Column == columnMinesOne)?.FirstOrDefault();
            var level1LeftNear = Model.GridMatrix.Where(x => x.Row == row && x.Column == columnMinesOne)?.FirstOrDefault();
            var level1LeftBottom = Model.GridMatrix.Where(x => x.Row == rowPlusOne && x.Column == columnMinesOne)?.FirstOrDefault();
            var level1RightTop = Model.GridMatrix.Where(x => x.Row == rowMinesOne && x.Column == columnPlusOne)?.FirstOrDefault();
            var level1RightNear = Model.GridMatrix.Where(x => x.Row == row && x.Column == columnPlusOne)?.FirstOrDefault();
            var level1RightBottom = Model.GridMatrix.Where(x => x.Row == rowPlusOne && x.Column == columnPlusOne)?.FirstOrDefault();
            var level1TopNear = Model.GridMatrix.Where(x => x.Row == rowMinesOne && x.Column == column)?.FirstOrDefault();
            var level1BottomNear = Model.GridMatrix.Where(x => x.Row == rowPlusOne && x.Column == column)?.FirstOrDefault();
            var level2LeftTop = Model.GridMatrix.Where(x => x.Row == rowMinesTwo && x.Column == columnMinesTwo)?.FirstOrDefault();
            var level2LeftNear = Model.GridMatrix.Where(x => x.Row == row && x.Column == columnMinesTwo)?.FirstOrDefault();
            var level2LeftBottom = Model.GridMatrix.Where(x => x.Row == rowPlusTwo && x.Column == columnMinesTwo)?.FirstOrDefault();
            var level2RightTop = Model.GridMatrix.Where(x => x.Row == rowMinesTwo && x.Column == columnPlusTwo)?.FirstOrDefault();
            var level2RightNear = Model.GridMatrix.Where(x => x.Row == row && x.Column == columnPlusTwo)?.FirstOrDefault();
            var level2RightBottom = Model.GridMatrix.Where(x => x.Row == rowPlusTwo && x.Column == columnPlusTwo)?.FirstOrDefault();
            var level2TopNear = Model.GridMatrix.Where(x => x.Row == rowMinesTwo && x.Column == column)?.FirstOrDefault();
            var level2BottomNear = Model.GridMatrix.Where(x => x.Row == rowPlusTwo && x.Column == column)?.FirstOrDefault();

            if (hand == Constants.O)
            {
                #region LeftTop
                if (gameLevel != GameLevel.Hard && gameLevel != GameLevel.Medium && level1LeftTop?.Content == Constants.S && level1RightBottom.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region LeftNear
                if (level1LeftNear?.Content == Constants.S && level1RightNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region LeftBottom
                if (gameLevel != GameLevel.Medium && level1LeftBottom?.Content == Constants.S && level1RightBottom.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region RightTop
                if (gameLevel != GameLevel.Medium && level1RightTop?.Content == Constants.S && level1LeftBottom.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region RightNear
                if (level1RightNear?.Content == Constants.S && level1LeftNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region RightBottom
                if (gameLevel != GameLevel.Medium && level1RightBottom?.Content == Constants.S && level1LeftBottom.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region Top
                if (level1TopNear?.Content == Constants.S && level1BottomNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region Bottom
                if (level1BottomNear?.Content == Constants.S && level1TopNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
            }
            else
            {
                #region FirstLevelControl
                #region LeftTop
                if (gameLevel != GameLevel.Hard && gameLevel != GameLevel.Medium && level1LeftTop?.Content == Constants.O && level2LeftTop.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region LeftNear
                if (level1LeftNear?.Content == Constants.O && level2LeftNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region LeftBottom
                if (gameLevel != GameLevel.Medium && level1LeftBottom?.Content == Constants.O && level2LeftBottom.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region RightTop
                if (gameLevel != GameLevel.Medium && level1RightTop?.Content == Constants.O && level2RightTop.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region RightNear
                if (level1RightNear?.Content == Constants.O && level2RightNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region RightBottom
                if (gameLevel != GameLevel.Medium && gameLevel != GameLevel.Medium && level1RightBottom?.Content == Constants.O && level2RightBottom.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region Top
                if (level1TopNear?.Content == Constants.O && level2TopNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region Bottom
                if (level1BottomNear?.Content == Constants.O && level2BottomNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #endregion

                #region SecondLevelControl
                #region LeftTop 
                if (gameLevel != GameLevel.Hard && gameLevel != GameLevel.Medium && level2LeftTop?.Content == Constants.S && level1LeftTop.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region LeftNear 
                if (level2LeftNear?.Content == Constants.S && level1LeftNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region LeftBottom 
                if (gameLevel != GameLevel.Medium && level2LeftBottom?.Content == Constants.S && level1LeftBottom.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region RightTop 
                if (gameLevel != GameLevel.Medium && level2RightTop?.Content == Constants.S && level1RightTop.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region RightNear 
                if (level2RightNear?.Content == Constants.S && level1RightNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region RightBottom 
                if (gameLevel != GameLevel.Medium && level2RightBottom?.Content == Constants.S && level1RightBottom.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region Top 
                if (level2TopNear?.Content == Constants.S && level1TopNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #region Bottom 
                if (level2BottomNear?.Content == Constants.S && level1BottomNear.IsFreeControl())
                {

                    sosPosibilityCount++;
                }
                #endregion
                #endregion

            }
            return sosPosibilityCount;
        }


    }
}
