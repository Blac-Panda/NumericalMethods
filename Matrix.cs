using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tunmise
{
    class Matrix
    {
        /*
         * TYPE 1 IS FOR NORMAL 2 X 2 MATRIX
         * TYPE 2 IS FOR GAUSS-SIEDEL
         * TYPE 3 IS FOR GAUSS-JORDAN
         */
        
        int type;
        public Matrix()
        {
            
        }
        public void start()
        {
            int order = 5;
            while (order < 2 || order > 4)
            {
                try
                {
                    Console.WriteLine("ENTER THE MATRIX ORDER : ");
                    order = Int16.Parse(Console.ReadLine());
                    if (order < 2 || order > 4)
                    {
                        Console.WriteLine("MATRIX ORDER MUST BE BETWEEN 2 TO 4\n\n");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("ONLY NUMBERS ARE ALLOWED AS VALID INPUT\n\n");
                }
            }
            type = order;
            switch (type)
            {
                case 2:
                    matrixOrderTwo();
                    break;
                case 3:
                    int option = 0;
                    Console.WriteLine("\nPICK OPTION:\n1. GAUSS-JORDAN\n2. GAUSS-SIEDEL\n3. NEWTON-RAPHSON\n");
                    option = Int32.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        matrixOrderThreeGaussJordan();
                    }
                    else if (option == 2)
                    {
                        matrixOrderThreeGaussSiedel();
                    }
                    break;
                case 4:
                    int option2 = 0;
                    Console.WriteLine("\nPICK OPTION:\n1. GAUSS-JORDAN\n2. GAUSS-SIEDEL\n");
                    option2 = Int32.Parse(Console.ReadLine());
                    if (option2 == 1)
                    {
                        matrixOrderFourGaussJordan();
                    }
                    else if (option2 == 2)
                    {
                        matrixOrderFourGaussSiedel();
                    }
                    break;
            }
        }
        public void matrixOrderTwo()
        {
            double a1, a2, b1, b2;
            Console.WriteLine("GIVEN A 2 X 2 MATRIX BELOW:\n");
            Console.WriteLine("(a1   a2)\n(b1   b2)\n");
            Console.WriteLine("ENTER VALUE FOR a1");
            a1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR a2");
            a2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR b1");
            b1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR b2");
            b2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("DETERMINANT IS : " + determinantTwoByTwo(a1,a2,b1,b2).ToString());
        }
        public void matrixOrderThreeGaussJordan()
        {
            double a1, a2, a3, b1, b2, b3, c1, c2, c3, d1, d2, d3;
            double A1, A2, A3;
            Console.WriteLine("GIVEN A 3 X 3 MATRIX BELOW:\n");
            Console.WriteLine("(a1   a2   a3  =  d1)\n\n(b1   b2   b3  =  d2)\n\n(c1   c2   c3  =  d3)\n");
            Console.WriteLine("ENTER VALUE FOR a1");
            a1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR a2");
            a2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR a3");
            a3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR b1");
            b1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR b2");
            b2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR b3");
            b3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR c1");
            c1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR c2");
            c2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR c3");
            c3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR d1");
            d1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR d2");
            d2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR d3");
            d3 = Double.Parse(Console.ReadLine());

            double [,] matrixArray = new double[3,4];
            matrixArray[0,0] = a1; matrixArray[0,1] = a2; matrixArray[0,2] = a3; matrixArray[0,3] = d1;
            matrixArray[1,0] = b1; matrixArray[1,1] = b2; matrixArray[1,2] = b3; matrixArray[1,3] = d2;
            matrixArray[2,0] = c1; matrixArray[2,1] = c2; matrixArray[2,2] = c3; matrixArray[2,3] = d3;

            matrixArray[0, 3] = d1; matrixArray[1, 3] = d2; matrixArray[2, 3] = d3;

            printThreeByThreeMatrix(a1,a2,a3,b1,b2,b3,c1,c2,c3,d1,d2,d3);

            //PARTIAL PIVOTING
            double max1 = maximumOfThreeNumbers(matrixArray[0, 0], matrixArray[1, 0], matrixArray[2, 0]);
            if (max1 == matrixArray[1, 0])
            {
                //SWAP SECOND ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                matrixArray[0, 0] = matrixArray[1, 0]; matrixArray[0, 1] = matrixArray[1, 1]; matrixArray[0, 2] = matrixArray[1, 2];
                matrixArray[0, 3] = matrixArray[1, 3];
                matrixArray[1, 0] = aTemp; matrixArray[1, 1] = bTemp; matrixArray[1, 2] = cTemp; matrixArray[1, 3] = dTemp;
                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);
            }
            else if (max1 == matrixArray[2, 0])
            {
                //SWAP THIRD ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                matrixArray[0, 0] = matrixArray[2, 0]; matrixArray[0, 1] = matrixArray[2, 1]; matrixArray[0, 2] = matrixArray[2, 2];
                matrixArray[0, 3] = matrixArray[2, 3];

                matrixArray[2, 0] = aTemp; matrixArray[2, 1] = bTemp; matrixArray[2, 2] = cTemp; matrixArray[2, 3] = dTemp;
                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);
            }

            //CHANGING R2 
            double a21 = matrixArray[1,0]; double a11 = matrixArray[0,0];
            double constant = a21/a11;
            matrixArray[1, 0] = matrixArray[1, 0] - (constant * matrixArray[0, 0]);
            matrixArray[1, 1] = matrixArray[1, 1] - (constant * matrixArray[0, 1]);
            matrixArray[1, 2] = matrixArray[1, 2] - (constant * matrixArray[0, 2]);
            matrixArray[1, 3] = matrixArray[1, 3] - (constant * matrixArray[0, 3]);

            printThreeByThreeMatrix(matrixArray[0,0], matrixArray[0,1], matrixArray[0,2], matrixArray[1,0], matrixArray[1,1],
                matrixArray[1,2], matrixArray[2,0], matrixArray[2,1], matrixArray[2,2], matrixArray[0,3], matrixArray[1,3],
                matrixArray[2,3]);

            //CHANGING R3
            double a31 = matrixArray[2, 0];
            constant = a31 / a11;
            matrixArray[2, 0] = matrixArray[2, 0] - (constant * matrixArray[0, 0]);
            matrixArray[2, 1] = matrixArray[2, 1] - (constant * matrixArray[0, 1]);
            matrixArray[2, 2] = matrixArray[2, 2] - (constant * matrixArray[0, 2]);
            matrixArray[2, 3] = matrixArray[2, 3] - (constant * matrixArray[0, 3]);

            printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);

            //PARTIAL PIVOTING AGAIN
            if (matrixArray[2, 1] > matrixArray[1, 1])
            {
                //SWAP THIRD ROW TO SECOND
                double aTemp, bTemp, cTemp, dTemp;
                aTemp = matrixArray[1, 0]; bTemp = matrixArray[1, 1]; cTemp = matrixArray[1, 2]; dTemp = matrixArray[1, 3];
                matrixArray[1, 0] = matrixArray[2, 0]; matrixArray[1, 1] = matrixArray[2, 1]; matrixArray[1, 2] = matrixArray[2, 2];
                matrixArray[1, 3] = matrixArray[2, 3];

                matrixArray[2, 0] = aTemp; matrixArray[2, 1] = bTemp; matrixArray[2, 2] = cTemp; matrixArray[2, 3] = dTemp;
                Console.WriteLine("===========PARTIAL PIVOTING SECOND TIME==============");
                printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);
            }

            //CHANGING R3 AGAIN 
            double a32 = matrixArray[2, 1];
            double a22 = matrixArray[1, 1];
            constant = a32 / a22;
            matrixArray[2, 0] = matrixArray[2, 0] - (constant * matrixArray[1, 0]);
            matrixArray[2, 1] = matrixArray[2, 1] - (constant * matrixArray[1, 1]);
            matrixArray[2, 2] = matrixArray[2, 2] - (constant * matrixArray[1, 2]);
            matrixArray[2, 3] = matrixArray[2, 3] - (constant * matrixArray[1, 3]);

            printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);
            
            //SOLVING FOR FINAL ANSWERS
            A3 = matrixArray[2, 3] / matrixArray[2, 2];
            A2 = (matrixArray[1, 3] - (A3 * matrixArray[1, 2]))/matrixArray[1, 1];
            A1 = (matrixArray[0, 3] - ((A2 * matrixArray[0, 1]) + (A3 * matrixArray[0, 2])))/matrixArray[0, 0];

            Console.WriteLine("THE VALUES FOR a1, a2 and a3 = {0:0.0000}, {1:0.0000}, {2:0.0000}",A1,A2,A3);
        }
        public double[] matrixOrderThreeGaussJordan(double a1, double a2, double a3, double b1, double b2, double b3, double c1,
            double c2, double c3, double d1, double d2, double d3)
        {
            //double a1, a2, a3, b1, b2, b3, c1, c2, c3, d1, d2, d3;
            double A1, A2, A3;
            double[,] matrixArray = new double[3, 4];
            matrixArray[0, 0] = a1; matrixArray[0, 1] = a2; matrixArray[0, 2] = a3; matrixArray[0, 3] = d1;
            matrixArray[1, 0] = b1; matrixArray[1, 1] = b2; matrixArray[1, 2] = b3; matrixArray[1, 3] = d2;
            matrixArray[2, 0] = c1; matrixArray[2, 1] = c2; matrixArray[2, 2] = c3; matrixArray[2, 3] = d3;

            matrixArray[0, 3] = d1; matrixArray[1, 3] = d2; matrixArray[2, 3] = d3;

            printThreeByThreeMatrix(a1, a2, a3, b1, b2, b3, c1, c2, c3, d1, d2, d3);

            //PARTIAL PIVOTING
            double max1 = maximumOfThreeNumbers(matrixArray[0, 0], matrixArray[1, 0], matrixArray[2, 0]);
            if (max1 == matrixArray[1, 0])
            {
                //SWAP SECOND ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                matrixArray[0, 0] = matrixArray[1, 0]; matrixArray[0, 1] = matrixArray[1, 1]; matrixArray[0, 2] = matrixArray[1, 2];
                matrixArray[0, 3] = matrixArray[1, 3];

                matrixArray[1, 0] = aTemp; matrixArray[1, 1] = bTemp; matrixArray[1, 2] = cTemp; matrixArray[1, 3] = dTemp;
                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);
            }
            else if (max1 == matrixArray[2, 0])
            {
                //SWAP THIRD ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                matrixArray[0, 0] = matrixArray[2, 0]; matrixArray[0, 1] = matrixArray[2, 1]; matrixArray[0, 2] = matrixArray[2, 2];
                matrixArray[0, 3] = matrixArray[2, 3];

                matrixArray[2, 0] = aTemp; matrixArray[2, 1] = bTemp; matrixArray[2, 2] = cTemp; matrixArray[2, 3] = dTemp;
                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);
            }

            //CHANGING R2 
            double a21 = matrixArray[1, 0]; double a11 = matrixArray[0, 0];
            double constant = a21 / a11;
            matrixArray[1, 0] = matrixArray[1, 0] - (constant * matrixArray[0, 0]);
            matrixArray[1, 1] = matrixArray[1, 1] - (constant * matrixArray[0, 1]);
            matrixArray[1, 2] = matrixArray[1, 2] - (constant * matrixArray[0, 2]);
            matrixArray[1, 3] = matrixArray[1, 3] - (constant * matrixArray[0, 3]);

            printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);

            //CHANGING R3
            double a31 = matrixArray[2, 0];
            constant = a31 / a11;
            matrixArray[2, 0] = matrixArray[2, 0] - (constant * matrixArray[0, 0]);
            matrixArray[2, 1] = matrixArray[2, 1] - (constant * matrixArray[0, 1]);
            matrixArray[2, 2] = matrixArray[2, 2] - (constant * matrixArray[0, 2]);
            matrixArray[2, 3] = matrixArray[2, 3] - (constant * matrixArray[0, 3]);

            printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);

            //PARTIAL PIVOTING AGAIN
            if (matrixArray[2, 1] > matrixArray[1, 1])
            {
                //SWAP THIRD ROW TO SECOND
                double aTemp, bTemp, cTemp, dTemp;
                aTemp = matrixArray[1, 0]; bTemp = matrixArray[1, 1]; cTemp = matrixArray[1, 2]; dTemp = matrixArray[1, 3];
                matrixArray[1, 0] = matrixArray[2, 0]; matrixArray[1, 1] = matrixArray[2, 1]; matrixArray[1, 2] = matrixArray[2, 2];
                matrixArray[1, 3] = matrixArray[2, 3];

                matrixArray[2, 0] = aTemp; matrixArray[2, 1] = bTemp; matrixArray[2, 2] = cTemp; matrixArray[2, 3] = dTemp;
                Console.WriteLine("===========PARTIAL PIVOTING SECOND TIME==============");
                printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);
            }

            //CHANGING R3 AGAIN 
            double a32 = matrixArray[2, 1];
            double a22 = matrixArray[1, 1];
            constant = a32 / a22;
            matrixArray[2, 0] = matrixArray[2, 0] - (constant * matrixArray[1, 0]);
            matrixArray[2, 1] = matrixArray[2, 1] - (constant * matrixArray[1, 1]);
            matrixArray[2, 2] = matrixArray[2, 2] - (constant * matrixArray[1, 2]);
            matrixArray[2, 3] = matrixArray[2, 3] - (constant * matrixArray[1, 3]);

            printThreeByThreeMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[1, 0], matrixArray[1, 1],
                matrixArray[1, 2], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2], matrixArray[0, 3], matrixArray[1, 3],
                matrixArray[2, 3]);

            //SOLVING FOR FINAL ANSWERS
            A3 = matrixArray[2, 3] / matrixArray[2, 2];
            A2 = (matrixArray[1, 3] - (A3 * matrixArray[1, 2])) / matrixArray[1, 1];
            A1 = (matrixArray[0, 3] - ((A2 * matrixArray[0, 1]) + (A3 * matrixArray[0, 2]))) / matrixArray[0, 0];
            return new Double []{ A1,A2,A3};
            //Console.WriteLine("THE VALUES FOR a1, a2 and a3 = {0:0.0000}, {1:0.0000}, {2:0.0000}", A1, A2, A3);
        }
        public void matrixOrderFourGaussJordan()
        {
            double a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4, e1, e2, e3, e4;
            double A1, A2, A3, A4;
            Console.WriteLine("GIVEN A 4 X 4 MATRIX BELOW:\n");
            Console.WriteLine("(a1   a2   a3   a4  =  e1)\n\n(b1   b2   b3   b4  =  e2)\n\n(c1   c2   c3   c4  =  e3)"+
                "\n\n(d1   d2   d3   d4  =  e4)\n");
            Console.WriteLine("ENTER VALUE FOR a1");
            a1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR a2");
            a2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR a3");
            a3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR a4");
            a4 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR b1");
            b1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR b2");
            b2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR b3");
            b3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR b4");
            b4 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR c1");
            c1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR c2");
            c2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR c3");
            c3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR c4");
            c4 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR d1");
            d1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR d2");
            d2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR d3");
            d3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR d4");
            d4 = Double.Parse(Console.ReadLine());

            Console.WriteLine("ENTER VALUE FOR e1");
            e1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR e2");
            e2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR e3");
            e3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR e4");
            e4 = Double.Parse(Console.ReadLine());

            double[,] matrixArray = new double[4, 5];
            matrixArray[0, 0] = a1; matrixArray[0, 1] = a2; matrixArray[0, 2] = a3; matrixArray[0, 3] = a4; matrixArray[0, 4] = e1;
            matrixArray[1, 0] = b1; matrixArray[1, 1] = b2; matrixArray[1, 2] = b3; matrixArray[1, 3] = b4; matrixArray[1, 4] = e2;
            matrixArray[2, 0] = c1; matrixArray[2, 1] = c2; matrixArray[2, 2] = c3; matrixArray[2, 3] = c4; matrixArray[2, 4] = e3;
            matrixArray[3, 0] = d1; matrixArray[3, 1] = d2; matrixArray[3, 2] = d3; matrixArray[3, 3] = d4; matrixArray[3, 4] = e4;


            printFourByFourMatrix(a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4, e1, e2, e3, e4);

            
            //PARTIAL PIVOTING
            double max1 = maximumOfFourNumbers(matrixArray[0, 0], matrixArray[1, 0], matrixArray[2, 0], matrixArray[3, 0]);
            if (max1 == matrixArray[1, 0])
            {
                //SWAP SECOND ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                eTemp = matrixArray[0, 4];
                
                matrixArray[0, 0] = matrixArray[1, 0]; matrixArray[0, 1] = matrixArray[1, 1]; matrixArray[0, 2] = matrixArray[1, 2];
                matrixArray[0, 3] = matrixArray[1, 3]; matrixArray[0, 4] = matrixArray[1, 4];

                matrixArray[1, 0] = aTemp; matrixArray[1, 1] = bTemp; matrixArray[1, 2] = cTemp; matrixArray[1, 3] = dTemp;
                matrixArray[1, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4], 
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }
            else if (max1 == matrixArray[2, 0])
            {
                //SWAP THIRD ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                eTemp = matrixArray[0, 4];

                matrixArray[0, 0] = matrixArray[2, 0]; matrixArray[0, 1] = matrixArray[2, 1]; matrixArray[0, 2] = matrixArray[2, 2];
                matrixArray[0, 3] = matrixArray[2, 3]; matrixArray[0, 4] = matrixArray[2, 4];

                matrixArray[2, 0] = aTemp; matrixArray[2, 1] = bTemp; matrixArray[2, 2] = cTemp; matrixArray[2, 3] = dTemp;
                matrixArray[2, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }
            else if (max1 == matrixArray[3, 0])
            {
                //SWAP FOURTH ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                eTemp = matrixArray[0, 4];

                matrixArray[0, 0] = matrixArray[3, 0]; matrixArray[0, 1] = matrixArray[3, 1]; matrixArray[0, 2] = matrixArray[3, 2];
                matrixArray[0, 3] = matrixArray[3, 3]; matrixArray[0, 4] = matrixArray[3, 4];

                matrixArray[3, 0] = aTemp; matrixArray[3, 1] = bTemp; matrixArray[3, 2] = cTemp; matrixArray[3, 3] = dTemp;
                matrixArray[3, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }
            
            //CHANGING R2 - (RULE 1)
            double a21 = matrixArray[1, 0]; double a11 = matrixArray[0, 0];
            double constant = a21 / a11;
            matrixArray[1, 0] = matrixArray[1, 0] - (constant * matrixArray[0, 0]);
            matrixArray[1, 1] = matrixArray[1, 1] - (constant * matrixArray[0, 1]);
            matrixArray[1, 2] = matrixArray[1, 2] - (constant * matrixArray[0, 2]);
            matrixArray[1, 3] = matrixArray[1, 3] - (constant * matrixArray[0, 3]);
            matrixArray[1, 4] = matrixArray[1, 4] - (constant * matrixArray[0, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            

            //CHANGING R3 - (RULE 2)
            double a31 = matrixArray[2, 0];
            constant = a31 / a11;
            matrixArray[2, 0] = matrixArray[2, 0] - (constant * matrixArray[0, 0]);
            matrixArray[2, 1] = matrixArray[2, 1] - (constant * matrixArray[0, 1]);
            matrixArray[2, 2] = matrixArray[2, 2] - (constant * matrixArray[0, 2]);
            matrixArray[2, 3] = matrixArray[2, 3] - (constant * matrixArray[0, 3]);
            matrixArray[2, 4] = matrixArray[2, 4] - (constant * matrixArray[0, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //CHANGING R4 - (RULE 3)
            double a41 = matrixArray[3, 0];
            constant = a41 / a11;
            matrixArray[3, 0] = matrixArray[3, 0] - (constant * matrixArray[0, 0]);
            matrixArray[3, 1] = matrixArray[3, 1] - (constant * matrixArray[0, 1]);
            matrixArray[3, 2] = matrixArray[3, 2] - (constant * matrixArray[0, 2]);
            matrixArray[3, 3] = matrixArray[3, 3] - (constant * matrixArray[0, 3]);
            matrixArray[3, 4] = matrixArray[3, 4] - (constant * matrixArray[0, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //PARTIAL PIVOTING AGAIN
            double max2 = maximumOfThreeNumbers(matrixArray[1, 1], matrixArray[2, 1], matrixArray[3, 1]);
            if (max2 == matrixArray[2, 1])
            {
                //SWAP THIRD ROW TO SECOND
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[1, 0]; bTemp = matrixArray[1, 1]; cTemp = matrixArray[1, 2]; dTemp = matrixArray[1, 3];
                eTemp = matrixArray[1, 4];

                matrixArray[1, 0] = matrixArray[2, 0]; matrixArray[1, 1] = matrixArray[2, 1]; matrixArray[1, 2] = matrixArray[2, 2];
                matrixArray[1, 3] = matrixArray[2, 3]; matrixArray[1, 4] = matrixArray[2, 4];

                matrixArray[2, 0] = aTemp; matrixArray[2, 1] = bTemp; matrixArray[2, 2] = cTemp; matrixArray[2, 3] = dTemp;
                matrixArray[2, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING SECOND TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }
            else if (max1 == matrixArray[3, 1])
            {
                //SWAP FOURTH ROW TO SECOND
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[1, 0]; bTemp = matrixArray[1, 1]; cTemp = matrixArray[1, 2]; dTemp = matrixArray[1, 3];
                eTemp = matrixArray[1, 4];

                matrixArray[1, 0] = matrixArray[3, 0]; matrixArray[1, 1] = matrixArray[3, 1]; matrixArray[1, 2] = matrixArray[3, 2];
                matrixArray[1, 3] = matrixArray[3, 3]; matrixArray[1, 4] = matrixArray[3, 4];

                matrixArray[3, 0] = aTemp; matrixArray[3, 1] = bTemp; matrixArray[3, 2] = cTemp; matrixArray[3, 3] = dTemp;
                matrixArray[3, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING SECOND TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }

            //CHANGING R3 AGAIN - (RULE 4)
            double a32 = matrixArray[2, 1]; double a22 = matrixArray[1, 1];
            constant = a32 / a22;
            matrixArray[2, 0] = matrixArray[2, 0] - (constant * matrixArray[1, 0]);
            matrixArray[2, 1] = matrixArray[2, 1] - (constant * matrixArray[1, 1]);
            matrixArray[2, 2] = matrixArray[2, 2] - (constant * matrixArray[1, 2]);
            matrixArray[2, 3] = matrixArray[2, 3] - (constant * matrixArray[1, 3]);
            matrixArray[2, 4] = matrixArray[2, 4] - (constant * matrixArray[1, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //CHANGING R4 AGAIN - (RULE 5)
            double a42 = matrixArray[3, 1];
            constant = a42 / a22;
            matrixArray[3, 0] = matrixArray[3, 0] - (constant * matrixArray[1, 0]);
            matrixArray[3, 1] = matrixArray[3, 1] - (constant * matrixArray[1, 1]);
            matrixArray[3, 2] = matrixArray[3, 2] - (constant * matrixArray[1, 2]);
            matrixArray[3, 3] = matrixArray[3, 3] - (constant * matrixArray[1, 3]);
            matrixArray[3, 4] = matrixArray[3, 4] - (constant * matrixArray[1, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //CHANGING R4 AGAIN - (RULE 6)
            double a43 = matrixArray[3, 2]; double a33 = matrixArray[2, 2];
            constant = a43 / a33;
            matrixArray[3, 0] = matrixArray[3, 0] - (constant * matrixArray[2, 0]);
            matrixArray[3, 1] = matrixArray[3, 1] - (constant * matrixArray[2, 1]);
            matrixArray[3, 2] = matrixArray[3, 2] - (constant * matrixArray[2, 2]);
            matrixArray[3, 3] = matrixArray[3, 3] - (constant * matrixArray[2, 3]);
            matrixArray[3, 4] = matrixArray[3, 4] - (constant * matrixArray[2, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //SOLVING FOR FINAL ANSWERS
            A4 = matrixArray[3, 4] / matrixArray[3, 3];
            A3 = (matrixArray[2, 4] - (A4 * matrixArray[2, 3])) / matrixArray[2, 2];
            A2 = (matrixArray[1, 4] - ((A4 * matrixArray[1, 3]) + (A3 * matrixArray[1, 2]))) / matrixArray[1, 1];
            A1 = (matrixArray[0, 4] - ((A4 * matrixArray[0, 3]) + (A3 * matrixArray[0, 2]) + (A2 * matrixArray[0, 1]))) 
                / matrixArray[0, 0];

            Console.WriteLine("THE VALUES FOR a1, a2, a3 and a4 = {0:0.0000}, {1:0.0000}, {2:0.0000}, {3:0.0000}", A1, A2, A3, A4);
            
        }
        public Double[] matrixOrderFourGaussJordan(double a1, double a2, double a3, double a4, double b1, double b2, double b3, double b4,
            double c1, double c2, double c3, double c4, double d1, double d2, double d3, double d4, double e1, double e2,
            double e3, double e4)
        {
            double A1, A2, A3, A4;
            double[,] matrixArray = new double[4, 5];
            matrixArray[0, 0] = a1; matrixArray[0, 1] = a2; matrixArray[0, 2] = a3; matrixArray[0, 3] = a4; matrixArray[0, 4] = e1;
            matrixArray[1, 0] = b1; matrixArray[1, 1] = b2; matrixArray[1, 2] = b3; matrixArray[1, 3] = b4; matrixArray[1, 4] = e2;
            matrixArray[2, 0] = c1; matrixArray[2, 1] = c2; matrixArray[2, 2] = c3; matrixArray[2, 3] = c4; matrixArray[2, 4] = e3;
            matrixArray[3, 0] = d1; matrixArray[3, 1] = d2; matrixArray[3, 2] = d3; matrixArray[3, 3] = d4; matrixArray[3, 4] = e4;


            printFourByFourMatrix(a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4, e1, e2, e3, e4);


            //PARTIAL PIVOTING
            double max1 = maximumOfFourNumbers(matrixArray[0, 0], matrixArray[1, 0], matrixArray[2, 0], matrixArray[3, 0]);
            if (max1 == matrixArray[1, 0])
            {
                //SWAP SECOND ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                eTemp = matrixArray[0, 4];

                matrixArray[0, 0] = matrixArray[1, 0]; matrixArray[0, 1] = matrixArray[1, 1]; matrixArray[0, 2] = matrixArray[1, 2];
                matrixArray[0, 3] = matrixArray[1, 3]; matrixArray[0, 4] = matrixArray[1, 4];

                matrixArray[1, 0] = aTemp; matrixArray[1, 1] = bTemp; matrixArray[1, 2] = cTemp; matrixArray[1, 3] = dTemp;
                matrixArray[1, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }
            else if (max1 == matrixArray[2, 0])
            {
                //SWAP THIRD ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                eTemp = matrixArray[0, 4];

                matrixArray[0, 0] = matrixArray[2, 0]; matrixArray[0, 1] = matrixArray[2, 1]; matrixArray[0, 2] = matrixArray[2, 2];
                matrixArray[0, 3] = matrixArray[2, 3]; matrixArray[0, 4] = matrixArray[2, 4];

                matrixArray[2, 0] = aTemp; matrixArray[2, 1] = bTemp; matrixArray[2, 2] = cTemp; matrixArray[2, 3] = dTemp;
                matrixArray[2, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }
            else if (max1 == matrixArray[3, 0])
            {
                //SWAP FOURTH ROW TO FIRST
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[0, 0]; bTemp = matrixArray[0, 1]; cTemp = matrixArray[0, 2]; dTemp = matrixArray[0, 3];
                eTemp = matrixArray[0, 4];

                matrixArray[0, 0] = matrixArray[3, 0]; matrixArray[0, 1] = matrixArray[3, 1]; matrixArray[0, 2] = matrixArray[3, 2];
                matrixArray[0, 3] = matrixArray[3, 3]; matrixArray[0, 4] = matrixArray[3, 4];

                matrixArray[3, 0] = aTemp; matrixArray[3, 1] = bTemp; matrixArray[3, 2] = cTemp; matrixArray[3, 3] = dTemp;
                matrixArray[3, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING FIRST TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }

            //CHANGING R2 - (RULE 1)
            double a21 = matrixArray[1, 0]; double a11 = matrixArray[0, 0];
            double constant = a21 / a11;
            matrixArray[1, 0] = matrixArray[1, 0] - (constant * matrixArray[0, 0]);
            matrixArray[1, 1] = matrixArray[1, 1] - (constant * matrixArray[0, 1]);
            matrixArray[1, 2] = matrixArray[1, 2] - (constant * matrixArray[0, 2]);
            matrixArray[1, 3] = matrixArray[1, 3] - (constant * matrixArray[0, 3]);
            matrixArray[1, 4] = matrixArray[1, 4] - (constant * matrixArray[0, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);


            //CHANGING R3 - (RULE 2)
            double a31 = matrixArray[2, 0];
            constant = a31 / a11;
            matrixArray[2, 0] = matrixArray[2, 0] - (constant * matrixArray[0, 0]);
            matrixArray[2, 1] = matrixArray[2, 1] - (constant * matrixArray[0, 1]);
            matrixArray[2, 2] = matrixArray[2, 2] - (constant * matrixArray[0, 2]);
            matrixArray[2, 3] = matrixArray[2, 3] - (constant * matrixArray[0, 3]);
            matrixArray[2, 4] = matrixArray[2, 4] - (constant * matrixArray[0, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //CHANGING R4 - (RULE 3)
            double a41 = matrixArray[3, 0];
            constant = a41 / a11;
            matrixArray[3, 0] = matrixArray[3, 0] - (constant * matrixArray[0, 0]);
            matrixArray[3, 1] = matrixArray[3, 1] - (constant * matrixArray[0, 1]);
            matrixArray[3, 2] = matrixArray[3, 2] - (constant * matrixArray[0, 2]);
            matrixArray[3, 3] = matrixArray[3, 3] - (constant * matrixArray[0, 3]);
            matrixArray[3, 4] = matrixArray[3, 4] - (constant * matrixArray[0, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //PARTIAL PIVOTING AGAIN
            double max2 = maximumOfThreeNumbers(matrixArray[1, 1], matrixArray[2, 1], matrixArray[3, 1]);
            if (max2 == matrixArray[2, 1])
            {
                //SWAP THIRD ROW TO SECOND
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[1, 0]; bTemp = matrixArray[1, 1]; cTemp = matrixArray[1, 2]; dTemp = matrixArray[1, 3];
                eTemp = matrixArray[1, 4];

                matrixArray[1, 0] = matrixArray[2, 0]; matrixArray[1, 1] = matrixArray[2, 1]; matrixArray[1, 2] = matrixArray[2, 2];
                matrixArray[1, 3] = matrixArray[2, 3]; matrixArray[1, 4] = matrixArray[2, 4];

                matrixArray[2, 0] = aTemp; matrixArray[2, 1] = bTemp; matrixArray[2, 2] = cTemp; matrixArray[2, 3] = dTemp;
                matrixArray[2, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING SECOND TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }
            else if (max1 == matrixArray[3, 1])
            {
                //SWAP FOURTH ROW TO SECOND
                double aTemp, bTemp, cTemp, dTemp, eTemp;
                aTemp = matrixArray[1, 0]; bTemp = matrixArray[1, 1]; cTemp = matrixArray[1, 2]; dTemp = matrixArray[1, 3];
                eTemp = matrixArray[1, 4];

                matrixArray[1, 0] = matrixArray[3, 0]; matrixArray[1, 1] = matrixArray[3, 1]; matrixArray[1, 2] = matrixArray[3, 2];
                matrixArray[1, 3] = matrixArray[3, 3]; matrixArray[1, 4] = matrixArray[3, 4];

                matrixArray[3, 0] = aTemp; matrixArray[3, 1] = bTemp; matrixArray[3, 2] = cTemp; matrixArray[3, 3] = dTemp;
                matrixArray[3, 4] = eTemp;

                Console.WriteLine("===========PARTIAL PIVOTING SECOND TIME==============");
                printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);
            }

            //CHANGING R3 AGAIN - (RULE 4)
            double a32 = matrixArray[2, 1]; double a22 = matrixArray[1, 1];
            constant = a32 / a22;
            matrixArray[2, 0] = matrixArray[2, 0] - (constant * matrixArray[1, 0]);
            matrixArray[2, 1] = matrixArray[2, 1] - (constant * matrixArray[1, 1]);
            matrixArray[2, 2] = matrixArray[2, 2] - (constant * matrixArray[1, 2]);
            matrixArray[2, 3] = matrixArray[2, 3] - (constant * matrixArray[1, 3]);
            matrixArray[2, 4] = matrixArray[2, 4] - (constant * matrixArray[1, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //CHANGING R4 AGAIN - (RULE 5)
            double a42 = matrixArray[3, 1];
            constant = a42 / a22;
            matrixArray[3, 0] = matrixArray[3, 0] - (constant * matrixArray[1, 0]);
            matrixArray[3, 1] = matrixArray[3, 1] - (constant * matrixArray[1, 1]);
            matrixArray[3, 2] = matrixArray[3, 2] - (constant * matrixArray[1, 2]);
            matrixArray[3, 3] = matrixArray[3, 3] - (constant * matrixArray[1, 3]);
            matrixArray[3, 4] = matrixArray[3, 4] - (constant * matrixArray[1, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //CHANGING R4 AGAIN - (RULE 6)
            double a43 = matrixArray[3, 2]; double a33 = matrixArray[2, 2];
            constant = a43 / a33;
            matrixArray[3, 0] = matrixArray[3, 0] - (constant * matrixArray[2, 0]);
            matrixArray[3, 1] = matrixArray[3, 1] - (constant * matrixArray[2, 1]);
            matrixArray[3, 2] = matrixArray[3, 2] - (constant * matrixArray[2, 2]);
            matrixArray[3, 3] = matrixArray[3, 3] - (constant * matrixArray[2, 3]);
            matrixArray[3, 4] = matrixArray[3, 4] - (constant * matrixArray[2, 4]);

            printFourByFourMatrix(matrixArray[0, 0], matrixArray[0, 1], matrixArray[0, 2], matrixArray[0, 3], matrixArray[1, 0],
                    matrixArray[1, 1], matrixArray[1, 2], matrixArray[1, 3], matrixArray[2, 0], matrixArray[2, 1], matrixArray[2, 2],
                    matrixArray[2, 3], matrixArray[3, 0], matrixArray[3, 1], matrixArray[3, 2], matrixArray[3, 3], matrixArray[0, 4],
                    matrixArray[1, 4], matrixArray[2, 4], matrixArray[3, 4]);

            //SOLVING FOR FINAL ANSWERS
            A4 = matrixArray[3, 4] / matrixArray[3, 3];
            A3 = (matrixArray[2, 4] - (A4 * matrixArray[2, 3])) / matrixArray[2, 2];
            A2 = (matrixArray[1, 4] - ((A4 * matrixArray[1, 3]) + (A3 * matrixArray[1, 2]))) / matrixArray[1, 1];
            A1 = (matrixArray[0, 4] - ((A4 * matrixArray[0, 3]) + (A3 * matrixArray[0, 2]) + (A2 * matrixArray[0, 1])))
                / matrixArray[0, 0];
            return new Double[] { A1,A2,A3,A4};
            //Console.WriteLine("THE VALUES FOR a1, a2, a3 and a4 = {0:0.0000}, {1:0.0000}, {2:0.0000}, {3:0.0000}", A1, A2, A3, A4);

        }
        public void matrixOrderThreeGaussSiedel()
        {
            double k1, k2, k3, k4, k5, k6, k7, k8, k9, v1, v2, v3;
            Console.WriteLine("GIVEN A 3 X 3 MATRIX BELOW WHERE THE VALUES OF k and v ARE NUMBERS:\n");
            Console.WriteLine("(k1   k2   k3) (x) | (v1)\n\n(k4   k5   k6) (y) | (v2)\n\n(k7   k8   k9) (z) | (v3)\n");

            Console.WriteLine("ENTER VALUE FOR k1");
            k1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k2");
            k2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k3");
            k3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k4");
            k4 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k5");
            k5 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k6");
            k6 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k7");
            k7 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k8");
            k8 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k9");
            k9 = Double.Parse(Console.ReadLine());

            Console.WriteLine("ENTER VALUE FOR v1");
            v1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR v2");
            v2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR v3");
            v3 = Double.Parse(Console.ReadLine());

            double[,] matrixArray = new double[3, 4];
            matrixArray[0, 0] = k1; matrixArray[0, 1] = k2; matrixArray[0, 2] = k3; matrixArray[0, 3] = v1;
            matrixArray[1, 0] = k4; matrixArray[1, 1] = k5; matrixArray[1, 2] = k6; matrixArray[1, 3] = v2;
            matrixArray[2, 0] = k7; matrixArray[2, 1] = k8; matrixArray[2, 2] = k9; matrixArray[2, 3] = v3;


            printThreeByThreeMatrix(k1, k2, k3, k4, k5, k6, k7, k8, k9, v1, v2, v3);
            
            double xInitial, yInitial, zInitial;
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR x");
            xInitial = Double.Parse(Console.ReadLine());
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR y");
            yInitial = Double.Parse(Console.ReadLine());
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR z");
            zInitial = Double.Parse(Console.ReadLine());
            int j = 1;
            while (true)
            {
                if (Math.Abs(matrixArray[0, 0]) >= Math.Abs(matrixArray[0, 1]) + Math.Abs(matrixArray[0, 2]) &&
                    Math.Abs(matrixArray[1, 1]) >= Math.Abs(matrixArray[1, 0]) + Math.Abs(matrixArray[1, 2]) &&
                    Math.Abs(matrixArray[2, 2]) >= Math.Abs(matrixArray[2, 0]) + Math.Abs(matrixArray[2, 1]))
                {
                    double xNew = (matrixArray[0, 3] - ((zInitial * matrixArray[0, 2]) + (yInitial * matrixArray[0, 1]))) / matrixArray[0, 0];
                    double yNew = (matrixArray[1, 3] - ((xNew * matrixArray[1, 0]) + (zInitial * matrixArray[1, 2]))) / matrixArray[1, 1];
                    double zNew = (matrixArray[2, 3] - ((xNew * matrixArray[2, 0]) + (yNew * matrixArray[2, 1]))) / matrixArray[2, 2];

                    Console.WriteLine("NEW VALUES = {0:0.00}, {1:0.00}, {2:0.00}", xNew, yNew, zNew);
                    double percentage1, percentage2, percentage3;
                    percentage1 = Math.Abs((xNew - xInitial) / xNew) * 100;
                    percentage2 = Math.Abs((yNew - yInitial) / yNew) * 100;
                    percentage3 = Math.Abs((zNew - zInitial) / zNew) * 100;
                    Console.WriteLine("\nITERATION {0}=====COMPUTING ABSOLUTE RELATIVE APPROXIMATE ERROR=====",j);
                    Console.WriteLine("x, y, z = {0:0.0000}%, {1:0.0000}%, {2:0.0000}%", percentage1, percentage2, percentage3);
                    xInitial = xNew;
                    yInitial = yNew;
                    zInitial = zNew;

                    if (percentage1 < 1 && percentage2 < 1 && percentage3 < 1)
                    {
                        break;
                    }
                    j++;
                }
                else
                {
                    Console.WriteLine("IT IS NOT DIAGONALLY DOMINANT SO IT DOES NOT CONVERGE");
                    break;
                }
            }
        }
        public double[] matrixOrderThreeGaussSiedel(double k1, double k2, double k3, double k4, double k5, double k6, double k7,
            double k8, double k9, double v1, double v2, double v3)
        {
            

            double[,] matrixArray = new double[3, 4];
            matrixArray[0, 0] = k1; matrixArray[0, 1] = k2; matrixArray[0, 2] = k3; matrixArray[0, 3] = v1;
            matrixArray[1, 0] = k4; matrixArray[1, 1] = k5; matrixArray[1, 2] = k6; matrixArray[1, 3] = v2;
            matrixArray[2, 0] = k7; matrixArray[2, 1] = k8; matrixArray[2, 2] = k9; matrixArray[2, 3] = v3;


            printThreeByThreeMatrix(k1, k2, k3, k4, k5, k6, k7, k8, k9, v1, v2, v3);

            double xInitial, yInitial, zInitial;
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR x");
            xInitial = Double.Parse(Console.ReadLine());
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR y");
            yInitial = Double.Parse(Console.ReadLine());
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR z");
            zInitial = Double.Parse(Console.ReadLine());
            int j = 1;
            while (true)
            {
                if (Math.Abs(matrixArray[0, 0]) >= Math.Abs(matrixArray[0, 1]) + Math.Abs(matrixArray[0, 2]) &&
                    Math.Abs(matrixArray[1, 1]) >= Math.Abs(matrixArray[1, 0]) + Math.Abs(matrixArray[1, 2]) &&
                    Math.Abs(matrixArray[2, 2]) >= Math.Abs(matrixArray[2, 0]) + Math.Abs(matrixArray[2, 1]))
                {
                    double xNew = (matrixArray[0, 3] - ((zInitial * matrixArray[0, 2]) + (yInitial * matrixArray[0, 1]))) / matrixArray[0, 0];
                    double yNew = (matrixArray[1, 3] - ((xNew * matrixArray[1, 0]) + (zInitial * matrixArray[1, 2]))) / matrixArray[1, 1];
                    double zNew = (matrixArray[2, 3] - ((xNew * matrixArray[2, 0]) + (yNew * matrixArray[2, 1]))) / matrixArray[2, 2];

                    Console.WriteLine("NEW VALUES = {0:0.00}, {1:0.00}, {2:0.00}", xNew, yNew, zNew);
                    double percentage1, percentage2, percentage3;
                    percentage1 = Math.Abs((xNew - xInitial) / xNew) * 100;
                    percentage2 = Math.Abs((yNew - yInitial) / yNew) * 100;
                    percentage3 = Math.Abs((zNew - zInitial) / zNew) * 100;
                    Console.WriteLine("\nITERATION {0}=====COMPUTING ABSOLUTE RELATIVE APPROXIMATE ERROR=====", j);
                    Console.WriteLine("x, y, z = {0:0.0000}%, {1:0.0000}%, {2:0.0000}%", percentage1, percentage2, percentage3);
                    xInitial = xNew;
                    yInitial = yNew;
                    zInitial = zNew;

                    if (percentage1 < 1 && percentage2 < 1 && percentage3 < 1)
                    {
                        break;
                    }
                    j++;
                }
                else
                {
                    Console.WriteLine("IT IS NOT DIAGONALLY DOMINANT SO IT DOES NOT CONVERGE");
                    break;
                }
            }
            return new Double[] { xInitial, yInitial, zInitial };
        }
        public void matrixOrderFourGaussSiedel()
        {
            double k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11, k12, k13, k14, k15, k16, v1, v2, v3, v4;
            Console.WriteLine("GIVEN A 4 X 4 MATRIX BELOW WHERE THE VALUES OF k and v ARE NUMBERS:\n");
            Console.WriteLine("(k1   k2   k3   k4) (w) | (v1)\n\n(k5   k6   k7   k8) (x) | (v2)\n\n(k9   k10   k11   k12) (y) | (v3)\n\n(k13   k14   k15   k16) (z) | (v4)\n");

            Console.WriteLine("ENTER VALUE FOR k1");
            k1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k2");
            k2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k3");
            k3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k4");
            k4 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k5");
            k5 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k6");
            k6 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k7");
            k7 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k8");
            k8 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k9");
            k9 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k10");
            k10 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k11");
            k11 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k12");
            k12 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k13");
            k13 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k14");
            k14 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k15");
            k15 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR k16");
            k16 = Double.Parse(Console.ReadLine());

            Console.WriteLine("ENTER VALUE FOR v1");
            v1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR v2");
            v2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR v3");
            v3 = Double.Parse(Console.ReadLine());
            Console.WriteLine("ENTER VALUE FOR v4");
            v4 = Double.Parse(Console.ReadLine());

            double[,] matrixArray = new double[4, 5];
            matrixArray[0, 0] = k1; matrixArray[0, 1] = k2; matrixArray[0, 2] = k3; matrixArray[0, 3] = k4; matrixArray[0, 4] = v1;
            matrixArray[1, 0] = k5; matrixArray[1, 1] = k6; matrixArray[1, 2] = k7; matrixArray[1, 3] = k8; matrixArray[1, 4] = v2;
            matrixArray[2, 0] = k9; matrixArray[2, 1] = k10; matrixArray[2, 2] = k11; matrixArray[2, 3] = k12; matrixArray[2, 4] = v3;
            matrixArray[3, 0] = k13; matrixArray[3, 1] = k14; matrixArray[3, 2] = k15; matrixArray[3, 3] = k16; matrixArray[3, 4] = v4;


            printFourByFourMatrix(k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11, k12, k13, k14, k15, k16, v1, v2, v3, v4);

            double wInitial, xInitial, yInitial, zInitial;
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR w");
            wInitial = Double.Parse(Console.ReadLine());
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR x");
            xInitial = Double.Parse(Console.ReadLine());
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR y");
            yInitial = Double.Parse(Console.ReadLine());
            Console.WriteLine("CHOOSE YOU INITIAL GUESS FOR z");
            zInitial = Double.Parse(Console.ReadLine());
            int j = 1;
            while (true)
            {
                if (Math.Abs(matrixArray[0, 0]) >= Math.Abs(matrixArray[0, 1]) + Math.Abs(matrixArray[0, 2]) + Math.Abs(matrixArray[0, 3]) &&
                    Math.Abs(matrixArray[1, 1]) >= Math.Abs(matrixArray[1, 0]) + Math.Abs(matrixArray[1, 2]) + Math.Abs(matrixArray[1, 3]) &&
                    Math.Abs(matrixArray[2, 2]) >= Math.Abs(matrixArray[2, 0]) + Math.Abs(matrixArray[2, 1]) + Math.Abs(matrixArray[2, 3]) &&
                    Math.Abs(matrixArray[3, 3]) >= Math.Abs(matrixArray[3, 0]) + Math.Abs(matrixArray[3, 1]) + Math.Abs(matrixArray[3 , 2]))
                {
                    double wNew = (matrixArray[0, 4] - ((zInitial * matrixArray[0, 3]) + (yInitial * matrixArray[0, 2]) + (xInitial * matrixArray[0, 1]))) / matrixArray[0, 0];
                    double xNew = (matrixArray[1, 4] - ((zInitial * matrixArray[1, 3]) + (yInitial * matrixArray[1, 2]) + (wNew * matrixArray[1, 0]))) / matrixArray[1, 1];
                    double yNew = (matrixArray[2, 4] - ((xNew * matrixArray[2, 1]) + (zInitial * matrixArray[2, 3]) + (wNew * matrixArray[2, 0]))) / matrixArray[2, 2];
                    double zNew = (matrixArray[3, 4] - ((xNew * matrixArray[3, 1]) + (yNew * matrixArray[3, 2]) + (wNew * matrixArray[3, 0]))) / matrixArray[3, 3];


                    //double xNew = (matrixArray[0, 3] - ((zInitial * matrixArray[0, 2]) + (yInitial * matrixArray[0, 1]))) / matrixArray[0, 0];
                    //double yNew = (matrixArray[1, 3] - ((xNew * matrixArray[1, 0]) + (zInitial * matrixArray[1, 2]))) / matrixArray[1, 1];
                    //double zNew = (matrixArray[2, 3] - ((xNew * matrixArray[2, 0]) + (yNew * matrixArray[2, 1]))) / matrixArray[2, 2];

                    Console.WriteLine("NEW VALUES = {0:0.00}, {1:0.00}, {2:0.00}, {3:0.00}", wNew, xNew, yNew, zNew);
                    double percentage1, percentage2, percentage3, percentage4;
                    percentage1 = Math.Abs((wNew - wInitial) / wNew) * 100;
                    percentage2 = Math.Abs((xNew - xInitial) / xNew) * 100;
                    percentage3 = Math.Abs((yNew - yInitial) / yNew) * 100;
                    percentage4 = Math.Abs((zNew - zInitial) / zNew) * 100;
                    Console.WriteLine("\nITERATION {0}=====COMPUTING ABSOLUTE RELATIVE APPROXIMATE ERROR=====", j);
                    Console.WriteLine("w, x, y, z = {0:0.0000}%, {1:0.0000}%, {2:0.0000}%, {3:0.0000}%\n\n", percentage1, percentage2, 
                        percentage3, percentage4);
                    wInitial = wNew;
                    xInitial = xNew;
                    yInitial = yNew;
                    zInitial = zNew;

                    if (percentage1 < 1 && percentage2 < 1 && percentage3 < 1 && percentage4 < 1)
                    {
                        break;
                    }
                    j++;
                }
                else
                {
                    Console.WriteLine("IT IS NOT DIAGONALLY DOMINANT SO IT DOES NOT CONVERGE");
                    break;
                }
            }
        }
        public double determinantTwoByTwo(double a1, double a2, double b1, double b2)
        {
            return ((a1 * b2) - (b1 * a2));
        }
        public void printThreeByThreeMatrix(double a1, double a2, double a3, double b1, double b2, double b3, double c1,
            double c2, double c3, double d1, double d2, double d3)
        {
            Console.WriteLine("\n{0:0.00}   {1:0.00}   {2:0.00}  :  {3:0.00}\n\n{4:0.00}   {5:0.00}   {6:0.00}  :  {7:0.00}\n\n"+
                "{8:0.00}   {9:0.00}   {10:0.00}  :  {11:0.00}\n",
                a1,a2,a3,d1,b1,b2,b3,d2,c1,c2,c3,d3);
        }
        public void printFourByFourMatrix(double a1, double a2, double a3, double a4, double b1, double b2, double b3, double b4,
            double c1, double c2, double c3, double c4, double d1, double d2, double d3, double d4, double e1, double e2,
            double e3, double e4)
        {
            Console.WriteLine("\n{0:0.00}   {1:0.00}   {2:0.00}   {3:0.00}  :  {4:0.00}\n\n{5:0.00}   {6:0.00}   {7:0.00}   {8:0.00}  :"
            + "  {9:0.00}\n\n{10:0.00}   {11:0.00}   {12:0.00}   {13:0.00}  :  {14:0.00}\n\n{15:0.00}   {16:0.00}   {17:0.00}   "+
            "{18:0.00}  :  {19:0.00}\n", a1, a2, a3, a4, e1, b1, b2, b3, b4, e2, c1, c2, c3, c4, e3, d1, d2, d3, d4, e4);
        }
        public double maximumOfThreeNumbers(double a, double b, double c)
        {
            double max = a-1;
            if (a > max)
            {
                max = a;
            }
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }
            return max;
        }
        public double maximumOfFourNumbers(double a, double b, double c, double d)
        {
            double max = a - 1;
            if (a > max)
            {
                max = a;
            }
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }
            if (d > max)
            {
                max = d;
            }
            return max;
        }
    }
}
