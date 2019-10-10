using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Extensions
    {
        public static bool IsFreeControl(this TableMatrix tableMatrix)
        {
            if (tableMatrix == null)
            {
                return false;

            }
            return tableMatrix.IsFree;
        }
    }
}
