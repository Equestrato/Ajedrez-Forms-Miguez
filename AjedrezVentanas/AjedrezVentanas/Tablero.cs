using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFINALLP2
{
    class Tablero
    {
        int[,] tablero = new int[8, 8];
        public Tablero()
        {

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    tablero[i, j] = 0;
                }
            }

        }
        public void amenazarlugar(int x, int y)
        {
            tablero[x, y] = tablero[x, y] + 1;
        }
        public void desamenazarlugar(int x, int y)
        {
            if (tablero[x, y] > -1)
            {
                tablero[x, y] = tablero[x, y] - 1;
            }
        }
        public void setXY(int X, int Y, int pieza)
        {
            tablero[Y, X] = pieza;
        }
        public int[,] GetXY()
        {
            return tablero;
        }
    }

}
