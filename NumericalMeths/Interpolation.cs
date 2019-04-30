using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericalMeths
{
    public class Interpolation
    {
        int interpolationType = 8; int equationType = 8;
        public Interpolation()
        {
            while (interpolationType >= 6 || interpolationType <= 0)
            {
                try
                {
                    Console.Write("\n1. NORMAL INTERPOLATION\n2. LAGRANGIAN INTERPOLATION \n3. NEWTON DIVIDED DIFFERENCE" +
                        "\n4. NEWTON-RAPHSON INTERPOLATION\n5. SPLINE INTERPOLATION\n\nSELECT INTERPOLATION TYPE : ");
                    interpolationType = Int16.Parse(Console.ReadLine());
                    if (interpolationType > 5 || interpolationType < 1)
                    {
                        Console.WriteLine("SELECTION MUST BE BETWEEN 1 TO 5\n\n");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("ONLY NUMBERS ARE ALLOWED AS VALID INPUT\n\n");
                }
            }
            while (equationType >= 4 || interpolationType <= 0)
            {
                try
                {
                    Console.Write("\n1. LINEAR\n2. QUADRATIC\n3. CUBIC\n\nSELECT EQUATION TYPE : ");
                    equationType = Int16.Parse(Console.ReadLine());
                    if (interpolationType > 3 || interpolationType < 1)
                    {
                        Console.WriteLine("SELECTION MUST BE BETWEEN 1 TO 3\n\n");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("ONLY NUMBERS ARE ALLOWED AS VALID INPUT\n\n");
                }
            }
            switch (interpolationType)
            {
                case 1:
                    switch (equationType)
                    {
                        case 1:
                            double x1, y1, x2, y2, delta, delta1, delta2, a0, a1;
                            Console.Write("Enter t - (s) : ");
                            x1 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter v(t) - (m/s) : ");
                            y1 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter t - (s) : ");
                            x2 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter v(t) - (m/s) : ");
                            y2 = Double.Parse(Console.ReadLine());
                            delta = new Matrix().determinantTwoByTwo(1, x1, 1, x2);
                            delta1 = new Matrix().determinantTwoByTwo(y1, x1, y2, x2);
                            delta2 = new Matrix().determinantTwoByTwo(1, y1, 1, y2);
                            a0 = delta1 / delta;
                            a1 = delta2 / delta;
                            Console.WriteLine("a0, a1 = {0:0.00}, {1:0.00}", a0, a1);
                            Console.Write("Enter time to get v(t) : \n");
                            double t = Double.Parse(Console.ReadLine());
                            double equation = a0 + (a1 * t);
                            Console.WriteLine("v(t) at t = {0:0.00} is {1:0.00}", t, equation);

                            break;
                        case 2:
                            double x_1, y_1, x_2, y_2, x_3, y_3;
                            Console.Write("Enter t - (s) : ");
                            x_1 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter v(t) - (m/s) : ");
                            y_1 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter t - (s) : ");
                            x_2 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter v(t) - (m/s) : ");
                            y_2 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter t - (s) : ");
                            x_3 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter v(t) - (m/s) : ");
                            y_3 = Double.Parse(Console.ReadLine());
                            Double[] result = new Matrix().matrixOrderThreeGaussJordan(1, x_1, Math.Pow(x_1, 2), 1, x_2,
                                    Math.Pow(x_2, 2), 1, x_3, Math.Pow(x_3, 2), y_1, y_2, y_3);
                            Console.WriteLine("THE VALUES OF a0, a1 and a2 are {0:0.00}, {1:0.00}, {2:0.00}", result[0], result[1],
                                result[2]);
                            /*
                             * GAUSS-JORDEN BEING USED BY DEFAULT AS GAUSS-SEIDEL RELIESON DIAGONAL DOMINANCE
                             * Console.Write("\n1.GAUSS-SEIDEL\n2.GAUSS-JORDAN\nSELECT MATRIX METHOD TO BE USED : ");
                            int matrixType = Int16.Parse(Console.ReadLine());
                            if (matrixType == 1)
                            {
                                Double[] result = new Matrix().matrixOrderThreeGaussSiedel(1, x_1, Math.Pow(x_1, 2), 1, x_2,
                                    Math.Pow(x_2, 2), 1, x_3, Math.Pow(x_3, 2), y_1, y_2, y_3);
                                Console.WriteLine("THE VALUES OF a0, a1 and a2 are {0:0.00}, {1:0.00}, {2:0.00}", result[0], result[1],
                                    result[2]);
                            }
                            else if (matrixType == 2 )
                            {
                                Double [] result = new Matrix().matrixOrderThreeGaussJordan(1, x_1, Math.Pow(x_1, 2), 1, x_2, 
                                    Math.Pow(x_2, 2), 1, x_3, Math.Pow(x_3, 2), y_1, y_2, y_3);
                                Console.WriteLine("THE VALUES OF a0, a1 and a2 are {0:0.00}, {1:0.00}, {2:0.00}",result[0], result[1],
                                    result[2]);
                            }*/
                            break;
                        case 3:
                            double x__1, y__1, x__2, y__2, x__3, y__3, x__4, y__4; ;
                            Console.Write("Enter t - (s) : ");
                            x__1 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter v(t) - (m/s) : ");
                            y__1 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter t - (s) : ");
                            x__2 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter v(t) - (m/s) : ");
                            y__2 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter t - (s) : ");
                            x__3 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter v(t) - (m/s) : ");
                            y__3 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter t - (s) : ");
                            x__4 = Double.Parse(Console.ReadLine());
                            Console.Write("Enter v(t) - (m/s) : ");
                            y__4 = Double.Parse(Console.ReadLine());
                            Double[] result_ = new Matrix().matrixOrderFourGaussJordan(1, x__1, Math.Pow(x__1, 2), Math.Pow(x__1, 3),
                                1, x__2, Math.Pow(x__2, 2), Math.Pow(x__2, 3), 1, x__3, Math.Pow(x__3, 2), Math.Pow(x__3, 3),
                                1, x__4, Math.Pow(x__4, 2), Math.Pow(x__4, 3), y__1, y__2, y__3, y__4);
                            Console.WriteLine("THE VALUES OF a0, a1, a2 and a3 are {0:0.00}, {1:0.00}, {2:0.00}, {3:0.00}",
                                result_[0], result_[1], result_[2], result_[3]);
                            break;
                    }
                    break;
            }
            //Console.WriteLine(new Matrix().determinantTwoByTwo(4,1,1,2));
        }
    }
}
