using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Server
{
    public class LogicalOperations
    {
        public Grid MainWindoeGrid { get; set; }
        public Grid SubGrid { get; set; }
        public Model Model { get; set; }
        internal TableMatrix Index { get; set; }
        internal string CharValue { get; set; }
        internal List<TableMatrix> FreeIndexList { get; set; }
        public LogicalOperations(Model Model, Grid MainWindowGrid, Grid SubGrid)
        {
            this.Model = Model;
            this.MainWindoeGrid = MainWindowGrid;
            this.SubGrid = SubGrid;
            FreeIndexList = Model.GridMatrix.Where(s => s.IsFree).ToList();
        }

        public LogicalOperationsResult GetLogicalTableItem()
        {

            if (Model.GameLevel == GameLevel.VeryHard)
            {
                return VeryHardProcess();
            }
            if (Model.GameLevel == GameLevel.Hard)
            {
                return HardProcess();
            }
            else if (Model.GameLevel == GameLevel.Medium)
            {
                return MediumProcess();

            }
            else if (Model.GameLevel == GameLevel.Easy)
            {
                var randomValue = GetRandomIndexCharValue();
                CharValue = randomValue.Item1;
                Index = randomValue.Item2;
            }
            return new LogicalOperationsResult { index = Index, Charater = CharValue };

        }

        private LogicalOperationsResult VeryHardProcess()
        {

            bool isSosExist = false;
            foreach (var item in FreeIndexList)
            {
                var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlHorizantalForO_WithoutDraw(item.Row, item.Column);
                if (isExistHorizontal)
                {
                    Index = item;
                    CharValue = Constants.O;
                    isSosExist = true;


                    break;
                }
            }

            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlVerticalForO_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.O;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlTopVerticalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlBottomVerticalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlBottomLeftDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlBottomRightDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlTopLeftDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlTopRightDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlLeftDiagonalForO_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.O;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlRightDiagonalForO_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.O;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlLeftHorizantalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlRightHorizantalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }

            if (!isSosExist)
            {

                return GetNotPossibilitySosItemForVeryHard(Model.GameLevel);
            }

            return new LogicalOperationsResult { index = Index, Charater = CharValue };
        }

        private LogicalOperationsResult HardProcess()
        {


            bool isSosExist = false;
            foreach (var item in FreeIndexList)
            {
                var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlHorizantalForO_WithoutDraw(item.Row, item.Column);
                if (isExistHorizontal)
                {
                    Index = item;
                    CharValue = Constants.O;
                    isSosExist = true;


                    break;
                }
            }

            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlVerticalForO_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.O;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlTopVerticalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlBottomVerticalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlBottomLeftDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlBottomRightDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlTopLeftDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlTopRightDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlLeftDiagonalForO_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.O;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlRightDiagonalForO_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.O;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlLeftHorizantalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlRightHorizantalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }

            if (!isSosExist)
            {

                return GetNotPossibilitySosItemForVeryHard(Model.GameLevel);
            }

            return new LogicalOperationsResult { index = Index, Charater = CharValue };
        }

        private LogicalOperationsResult MediumProcess()
        {


            bool isSosExist = false;
            foreach (var item in FreeIndexList)
            {
                var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlHorizantalForO_WithoutDraw(item.Row, item.Column);
                if (isExistHorizontal)
                {
                    Index = item;
                    CharValue = Constants.O;
                    isSosExist = true;


                    break;
                }
            }

            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlVerticalForO_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.O;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlTopVerticalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlBottomVerticalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlBottomLeftDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlBottomRightDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlTopLeftDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlTopRightDiagonalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlLeftDiagonalForO_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.O;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlRightDiagonalForO_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.O;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlLeftHorizantalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }
            if (!isSosExist)
            {
                foreach (var item in FreeIndexList)
                {
                    var isExistHorizontal = new ShutController(MainWindoeGrid, Model).ControlRightHorizantalForS_WithoutDraw(item.Row, item.Column);
                    if (isExistHorizontal)
                    {
                        Index = item;
                        CharValue = Constants.S;
                        isSosExist = true;


                        break;

                    }
                }
            }

            if (!isSosExist)
            {

                return GetNotPossibilitySosItemForVeryHard(Model.GameLevel);
            }

            return new LogicalOperationsResult { index = Index, Charater = CharValue };
        }

        private LogicalOperationsResult GetNotPossibilitySosItemForVeryHard(GameLevel gameLevel)
        {
            var myHandCouldBe = Constants.S;

            foreach (var item in FreeIndexList)
            {
                var sosCountForS = new ShutController(MainWindoeGrid, Model).ControlIsAroundFreeForCharValue(item, myHandCouldBe, gameLevel);

                item.SosPossibilityCountForS = sosCountForS;
            }
            myHandCouldBe = Constants.O;

            foreach (var item in FreeIndexList)
            {
                var sosCountForO = new ShutController(MainWindoeGrid, Model).ControlIsAroundFreeForCharValue(item, myHandCouldBe, gameLevel);
                item.SosPossibilityCountForO = sosCountForO;

            }
            var minPossValue = 0;
            var minPossibilityForS = FreeIndexList.Min(z => z.SosPossibilityCountForS);
            var minPossibilityForO = FreeIndexList.Min(z => z.SosPossibilityCountForO);

            if (minPossibilityForO < minPossibilityForS)
            {
                minPossValue = minPossibilityForO;
                CharValue = Constants.O;
                Index = FreeIndexList.Where(x => x.SosPossibilityCountForO == minPossibilityForO).First();
            }
            else if (minPossibilityForO > minPossibilityForS)
            {
                minPossValue = minPossibilityForS;

                CharValue = Constants.S;
                Index = FreeIndexList.Where(x => x.SosPossibilityCountForS == minPossibilityForS).First();
            }
            else if (minPossibilityForO > 0)
            {
                CharValue = Constants.S;
                Index = FreeIndexList.Where(x => x.SosPossibilityCountForS == minPossibilityForS).First();

            }
            else
            {
                var gameString = "OSOSOSOSOSOSOSOSOSOSOSOSOSOSOS";
                int charIndex = new Random().Next(gameString.Length);
                CharValue = gameString[charIndex].ToString();
                if (CharValue == Constants.S)
                {
                    var randomItem = FreeIndexList.Where(t => t.SosPossibilityCountForS == minPossValue).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    CharValue = Constants.S;
                    Index = Model.GridMatrix.Where(x => (x.Row == randomItem.Row) && (x.Column == randomItem.Column)).FirstOrDefault();
                }
                else
                {
                    var randomItem = FreeIndexList.Where(t => t.SosPossibilityCountForO == minPossValue).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    CharValue = Constants.O;
                    Index = Model.GridMatrix.Where(x => (x.Row == randomItem.Row) && (x.Column == randomItem.Column)).FirstOrDefault();
                }
            }

            return new LogicalOperationsResult { index = Index, Charater = CharValue };
        }


        Tuple<string, TableMatrix> GetRandomIndexCharValue()
        {
            var Index = new TableMatrix();
            var gameString = "OSOSOSOSOSOSOSOSOSOSOSOSOSOSOS";
            int charIndex = new Random().Next(gameString.Length);
            var CharValue = gameString[charIndex].ToString();
            do
            {

                var row = new Helper().RandomNumber(0, Model.RowCount);
                var column = new Helper().RandomNumber(0, Model.ColumnCount);
                Index = Model.GridMatrix.Where(x => (x.Row == row) && (x.Column == column)).FirstOrDefault();
            }
            while (!Index.IsFree);
            return new Tuple<string, TableMatrix>(CharValue, Index);

        }

    }
}
