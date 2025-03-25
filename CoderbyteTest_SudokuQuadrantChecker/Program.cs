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

            //finding double in the lines

            Dictionary<string, int> dicLine = new Dictionary<string, int>();            

            for (int i = 0; i < dimX; i++)
            {
                for (int j = 0; j < dimY; j++)
                {
                    string dig = deskArr[i, j];

                    if (dig != "x")
                    {
                        if(dicLine.ContainsKey(deskArr[i, j]))                            
                        {
                            dicLine[deskArr[i, j]] += 1;
                        }
                        else 
                        {
                            dicLine.Add(deskArr[i, j], 1);
                        }

                        foreach (var item in dicLine.Keys)
                        {
                            if (dicLine[item] >1)
                            {
                                for (int z = 0; z < dimX; z++)
                                {
                                    if(deskArr[i, z] == item)
                                    {
                                        GetSubGrid(i, z);
                                    }
                                }
                            }

                        }


                    }
                }
            }

                // code goes here  
                return null;
        }

        static int GetSubGridInd(int x, int y)        
        {
            int ind = 0;

            if(x <= 3 && y <= 3)
            {
                ind = 1;
            }
            else if (x <= 6 && y <= 3)
            {
                ind = 2;
            }
            else if (x <= 9 && y <= 3)
            {
                ind = 3;
            }

            else if (x <= 3 && y <= 6)
            {
                ind = 4;
            }
            else if (x <= 6 && y <= 6)
            {
                ind = 5;
            }
            else if (x <= 9 && y <= 6)
            {
                ind = 6;
            }

            else if (x <= 3 && y <= 9)
            {
                ind = 7;
            }
            else if (x <= 6 && y <= 9)
            {
                ind = 8;
            }
            else if (x <= 9 && y <= 9)
            {
                ind = 9;
            }

            return ind;
        }
    }
}
