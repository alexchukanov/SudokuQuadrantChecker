using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbyteTest_SudokuQuadrantChecker
{
    public class Program
    {
        static int dimX = 9;
        static int dimY = 9;
        /*
        static string[] strArr = 
        {   
            "(1,2,3,4,5,6,7,8,1)", 
            "(x,x,x,x,x,x,x,x,x)", 
            "(x,x,x,x,x,x,x,x,x)", 
            "(1,x,x,x,x,x,x,x,x)", 
            "(x,x,x,x,x,x,x,x,x)", 
            "(x,x,x,x,x,x,x,x,x)", 
            "(x,x,x,x,x,x,x,x,x)", 
            "(x,x,x,x,x,x,x,x,x)", 
            "(x,x,x,x,x,x,x,x,x)" 
        };
        */

        /*
        static string[] strArr =
        {
            "(1,2,3,4,5,6,7,8,9)",
            "(x,x,x,x,x,x,x,x,x)",
            "(6,x,5,x,3,x,x,4,x)",
            "(2,x,1,1,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,9)"
        };
        */

       static string[] strArr =
       {
            "(1,2,3,4,5,6,7,8,1)",
            "(x,x,x,x,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,x)",
            "(1,x,x,x,x,x,x,x,x))",
            "(x,x,x,x,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,x)",
            "(x,x,x,x,x,x,x,x,x)"
        };

        static void Main(string[] args)
        {
            Console.WriteLine(SudokuQuadrantChecker(strArr));
        }

        public static string SudokuQuadrantChecker(string[] strArr)
        {
            List<int> subGridIndList = new List<int>(); 

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

            for (int i = 0; i < dimX; i++)
            {
                Dictionary<string, int> dicLine = new Dictionary<string, int>();

                for (int j = 0; j < dimY; j++)
                {
                    string dig = deskArr[i, j];

                    if (dig != "x")
                    {
                        if (dicLine.ContainsKey(dig))
                        {
                            dicLine[deskArr[i, j]] += 1;
                        }
                        else
                        {
                            dicLine.Add(dig, 1);
                        }
                    }
                }

                foreach (var item in dicLine.Keys)
                {
                    if (dicLine[item] > 1)
                    {
                        for (int z = 0; z < dimX; z++)
                        {
                            if (deskArr[i, z] == item)
                            {
                                int subGridInd = GetSubGridInd(i, z);
                                subGridIndList.Add(subGridInd);
                            }
                        }
                    }
                }
            }

            //finding double in the columns

            for (int i = 0; i < dimY; i++)
            {
                Dictionary<string, int> dicLine = new Dictionary<string, int>();

                for (int j = 0; j < dimX; j++)
                {
                    string dig = deskArr[j, i];

                    if (dig != "x")
                    {
                        if (dicLine.ContainsKey(dig))
                        {
                            dicLine[deskArr[j, i]] += 1;
                        }
                        else
                        {
                            dicLine.Add(dig, 1);
                        }
                    }
                }

                foreach (var item in dicLine.Keys)
                {
                    if (dicLine[item] > 1)
                    {
                        for (int z = 0; z < dimY; z++)
                        {
                            if (deskArr[z, i] == item)
                            {
                                int subGridInd = GetSubGridInd(z, i);
                                subGridIndList.Add(subGridInd);
                            }
                        }
                    }
                }
            }

            List<int> subGridIndexes = subGridIndList.Distinct<int>().ToList();
            
            subGridIndexes.Sort();

            string subGridIndStr = String.Join(", ", subGridIndexes);

            return subGridIndStr;
        }
   
        static int GetSubGridInd(int x, int y)        
        {
            int ind = 0;

            if(x <= 2 && y <= 2)
            {
                ind = 1;
            }
            else if (x <= 2 && y <= 5)
            {
                ind = 2;
            }
            else if (x <= 2 && y <= 8)
            {
                ind = 3;
            }

            else if (x <= 5 && y <= 2)
            {
                ind = 4;
            }
            else if (x <= 5 && y <= 5)
            {
                ind = 5;
            }
            else if (x <= 5 && y <= 8)
            {
                ind = 6;
            }

            else if (x <= 8 && y <= 2)
            {
                ind = 7;
            }
            else if (x <= 8 && y <= 5)
            {
                ind = 8;
            }
            else if (x <= 8 && y <= 8)
            {
                ind = 9;
            }

            return ind;
        }
    }
}
