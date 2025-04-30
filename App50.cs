// 參考 https://en.wikipedia.org/wiki/Time-frequency_analysis 
// y(t) = cos(pi*t)       0 <= t < 10 
// y(t) = cos(3*pi*t)    10 <= t < 20 
// y(t) = cos(2*pi*t)    20 <= t 

using Matrix_0; 

double step = 0.05;
ReMatrix y;
int iNum = (int)(30 / step) + 1;
ReMatrix Mat = new ReMatrix(iNum, 2);

for (int i = 0; i != iNum; i++)
{
    double t = step * i;
    double[,] t2 = { { t } };
    ReMatrix tMat = (ReMatrix)t2;

    if( (0 <= t) && (t < 10))
    { 
        double yTemp = Math.Cos(1 * Math.PI * t);
        double[,] yTemp2 = { { yTemp } };
        y = (ReMatrix)yTemp2; 
     }
    else if( (10 <= t) && (t < 20))
    { 
        double yTemp = Math.Cos(3 * Math.PI * t);
        double[,] yTemp2 = { { yTemp } };
        y = (ReMatrix)yTemp2; 
    }
    else
    {  
        double yTemp = Math.Cos(2 * Math.PI * t);
        double[,] yTemp2 = { {yTemp} };
        y = (ReMatrix)yTemp2; 
    }
    Mat[i, 0] = tMat;
    Mat[i, 1] = y;
}
Console.Write("         t(時間)          y(振幅）   ");
Console.Write("\n{0}", new PR(Mat));
// 列印時間和變位序列 
Console.Write("\n時間序列\n{0}", new PR4(Mat, 0));
Console.Write("\n位移序列\n{0}", new PR4(Mat, 1));

/* 輸出結果 ：
         t(時間)          y(振幅）
        0.00000          1.00000
        0.05000          0.98769
        0.10000          0.95106
        0.15000          0.89101
            .
            .
            .
            .
   1.0000,   0.9511,   0.8090,   0.5878,   0.3090,
   0.0000,  -0.3090,  -0.5878,  -0.8090,  -0.9511,
  -1.0000,  -0.9511,  -0.8090,  -0.5878,  -0.3090,
   0.0000,   0.3090,   0.5878,   0.8090,   0.9511,
   1.0000,
*/
