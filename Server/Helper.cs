using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Common;

namespace Server
{
    public class Helper
    {
        public Helper()
        {

        }

        public SolidColorBrush GetPlayerColor(Player item)
        {
            var playerColor = item.PlayerColor;
            var colorName = playerColor.ToString();

            return (SolidColorBrush)new BrushConverter().ConvertFromString(colorName);
        }

        public string GenerateRandomInt(int len)
        {
            int maxSize = len;
            var charArray = new char[30];
            var randomCharacterSet = "1234567890";
            charArray = randomCharacterSet.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(size);
            foreach (byte b in data) { result.Append(charArray[b % (charArray.Length)]); }
            return result.ToString();
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }


    }
}
