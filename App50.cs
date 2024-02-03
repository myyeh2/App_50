// 
// 參考 https://en.wikipedia.org/wiki/Time-frequency_analysis 
// 其中的實例。 y(t) = cos(pi*t) + cos(3*pi*t) + cos(2*pi*t)  且 0 <= t  。 
// 

using System;
using System.IO;
using Matrix_0; 

namespace ConsoleApp50
{
	internal class Program
	{
		static void Main(string[] args)
		{			
			double step = 0.09; 
			ReMatrix y; 
			int iNum = (int)(5/step); 
			ReMatrix Mat = new ReMatrix(iNum, 2); 

			for(int i = 0; i != iNum; i++)
			{
				double t = step * i ; 
			    double[,] t2 = { { t } };
				ReMatrix tMat = (ReMatrix)t2; 

				double[,] y1 = { { Math.Cos(1 * Math.PI * t) } };
				double[,] y2 = { { Math.Cos(3 * Math.PI * t) } };
				double[,] y3 = { { Math.Cos(2 * Math.PI * t) } };
				y = (ReMatrix)y1 + y2 + y3;

				Mat[i, 0] = tMat; 
				Mat[i, 1] = y; 
			} 
			Console.WriteLine("**  時頻分析【輸出的數值結果】 (方法一)  **\n"); 
			Console.WriteLine("            t             y(振幅）   \n"); 
			Console.WriteLine("\n{0}\n", new PR(Mat));  

			Console.WriteLine("\n=============================================\n\n");  

			for (int i = 0; i != iNum; i++)
			{
				double t = step * i;
				double[,] t2 = { { t } }; 
				ReMatrix tMat = (ReMatrix)t2; 

				double[,] y1 = { { Math.Cos(1 * Math.PI * t) } };
				double[,] y2 = { { Math.Cos(3 * Math.PI * t) } };
				double[,] y3 = { { Math.Cos(2 * Math.PI * t) } };

				// D 
				ReMatrix D = new ReMatrix(3, 3); 
				D[0, 0] = (ReMatrix)y1; 
				D[1, 1] = (ReMatrix)y2; 
				D[2, 2] = (ReMatrix)y3; 
				// Q特徵向量(Identity Matrix) 
				Iden I = new Iden(3, 3); 
				ReMatrix Q = I.Matrix; 
				// d 
				double[,] d = {{1}, {1}, {1} };
				y = Q * D * d;
				y = y[0, 0] + y[1, 0] + y[2, 0]; 
				
				Mat[i, 0] = tMat; 
				Mat[i, 1] = y; 
			}
			Console.WriteLine("**  時頻分析【輸出的數值結果】 (方法二) **\n");
			Console.WriteLine("            t             y(振幅）   \n");
			Console.WriteLine("\n{0}\n", new PR(Mat));
		}
	}
}
//  ** 數值的輸出結果，請參見儲存庫中的程式碼 ** 