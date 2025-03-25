using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbyteTest_SudokuQuadrantChecker
{
    internal class Program
    {
        static int dimX = 9;
        static int dimY = 9;

        static string[] strArr = { "(1,2,3,4,5,6,7,8,1)", "(x,x,x,x,x,x,x,x,x)", "(x,x,x,x,x,x,x,x,x)", "(1,x,x,x,x,x,x,x,x)", "(x,x,x,x,x,x,x,x,x)", "(x,x,x,x,x,x,x,x,x)", "(x,x,x,x,x,x,x,x,x)", "(x,x,x,x,x,x,x,x,x)", "(x,x,x,x,x,x,x,x,x)" };
        static void Main(string[] args)
        {
            Console.WriteLine(SudokuQuadrantChecker(strArr));
        }

        public static string SudokuQuadrantChecker(string[] strArr)
        {
            string[,] deskArr = new string[dimX, dimY];

            int x = 0;
            foreach (var item in strArr)
            {
               string[] arrLine = item.TrimStart('(').TrimEnd(')').Split(',');

               for (int y = 0; y < dimY; y++)
               {
                        deskArr[x, y] = arrLine[y];                       
               }
                    x++;
            }
         
            // code goes here  
            return null;
        }
    }
}
