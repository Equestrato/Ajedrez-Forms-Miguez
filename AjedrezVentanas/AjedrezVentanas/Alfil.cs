using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//4
namespace TPFINALLP2
{
    
    class Alfil : Pieza
        {
            public Tablero matriza, matrizp;
            public int Color;
            int[] POS = { 0, 0 };

            public Alfil(int[] xy, Tablero matrizamenaza, Tablero matrizpos, int color)
            {

                matriza = matrizamenaza;
                matrizp = matrizpos;
                POS[0] = xy[0];
                POS[1] = xy[1];
                Color = color;
                ocuparlugar();
                lugaresamenazados();

            }
            public override void salto()
            {
                Random rd = new Random();

                int[,] casillasblancas = {{1,0},{3,0},{5,0},{7,0},{0,1},{2,1},{4,1},{6,1},
                                      {1,2},{3,2},{5,2},{7,2},{0,3},{2,3},{4,3},{6,3},
                                      {1,4},{3,4},{5,4},{7,4},{0,5},{2,5},{4,5},{6,5},
                                      {1,6},{3,6},{5,6},{7,6},{0,7},{2,7},{4,7},{6,7} };

                int[,] casillasnegras = { {0,0},{2,0},{4,0},{6,0},{1,1},{3,1},{5,1},{7,1},
                                      {0,2},{2,2},{4,2},{6,2},{1,3},{3,3},{5,3},{7,3},
                                      {0,4},{2,4},{4,4},{6,4},{1,5},{3,5},{5,5},{7,5},
                                      {0,6},{2,6},{4,6},{6,6},{1,7},{3,7},{5,7},{7,7} };

                if (Color == 1)
                {
                    POS[0] = casillasblancas[rd.Next(0, 32), 0];
                    POS[1] = casillasblancas[rd.Next(0, 32), 1];
                }
                else
                {
                    POS[0] = casillasnegras[rd.Next(0, 32), 0];
                    POS[1] = casillasnegras[rd.Next(0, 32), 1];
                }


            }
            override public int[] GetPos() { return POS; }
            public override void desamenazar()
            {
                int freecases = 0, aux1 = 0;

                matriza.desamenazarlugar(POS[0], POS[1]);
                if (POS[0] < POS[1]) { aux1 = POS[0]; } else { aux1 = POS[1]; }
                ///PARTE DE ALFIL ARRIBA IZQUIERDA nop
                for (int i = 1; i < 7; i++)
                {
                    if (POS[0] - i > -1 && POS[1] - i > -1)
                    {
                        matriza.desamenazarlugar(POS[1] - i, POS[0] - i);
                    }
                    else { break; }
                    ///contador++;
                }
                ///PARTE DE ALFIL ABAJO DERECHA nop                        
                for (int j = 1; j < 7; j++)
                {
                    if (POS[0] + j < 8 && POS[1] + j < 8)
                    {
                        matriza.desamenazarlugar(POS[1] + j, POS[0] + j);
                    }
                    else { break; }
                    ///contador++;
                }
                ///PARTE DE ALFIL ABAJO IZQUIERDA                                  
                for (int i = 1; i < 7; i++)
                {
                    if (POS[0] - i > -1 && POS[1] + i < 8)
                    {
                        matriza.desamenazarlugar(POS[0] - i, POS[1] + i);
                    }
                    else { break; }
                    ///contador++;
                }
                ///PARTE DE ALFIL ARRIBA DERECHA                         
                for (int i = 1; i < 7; i++)
                {
                    if (POS[0] + i < 8 && POS[1] - i > -1)
                    {
                        matriza.desamenazarlugar(POS[0] + i, POS[1] - i);
                    }
                    else { break; }
                    ///contador++;
                }
            }
            public override void lugaresamenazados()
            {
                int freecases = 0, aux1 = 0;

                matriza.amenazarlugar(POS[0], POS[1]);
                if (POS[0] < POS[1]) { aux1 = POS[0]; } else { aux1 = POS[1]; }
                ///PARTE DE ALFIL ARRIBA IZQUIERDA nop
                for (int i = 1; i < 7; i++)
                {
                    if (POS[0] - i > -1 && POS[1] - i > -1)
                    {
                        matriza.amenazarlugar(POS[1] - i, POS[0] - i);
                    }
                    else { break; }
                    ///contador++;
                }
                ///PARTE DE ALFIL ABAJO DERECHA nop                        
                for (int j = 1; j < 7; j++)
                {
                    if (POS[0] + j < 8 && POS[1] + j < 8)
                    {
                        matriza.amenazarlugar(POS[1] + j, POS[0] + j);
                    }
                    else { break; }
                    ///contador++;
                }
                ///PARTE DE ALFIL ABAJO IZQUIERDA                                  
                for (int i = 1; i < 7; i++)
                {
                    if (POS[0] - i > -1 && POS[1] + i < 8)
                    {
                        matriza.amenazarlugar(POS[0] - i, POS[1] + i);
                    }
                    else { break; }
                    ///contador++;
                }
                ///PARTE DE ALFIL ARRIBA DERECHA                         
                for (int i = 1; i < 7; i++)
                {
                    if (POS[0] + i < 8 && POS[1] - i > -1)
                    {
                        matriza.amenazarlugar(POS[0] + i, POS[1] - i);
                    }
                    else { break; }
                    ///contador++;
                }
            }
            public override int NoPisar(int[] v0, int[] v1, int[] v2, int[] v3, int[] v4, int[] v5, int[] alfil1, int[] alfil2)
            {
                Random rdx = new Random();
                Random rdy = new Random();

                int cont = 0;

                int[,] posiciones = { { v0[0], v0[1] },{ v1[0], v1[1] }, { v2[0], v2[1]}, { v3[0], v3[1] },
                              { v4[0], v4[1]}, { v5[0], v5[1]}, { alfil1[0], alfil1[1]}, {alfil2[0], alfil2[1]}};

                while (cont < 8)
                {
                    cont = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            if (i == j)
                            {
                            }
                            else if (posiciones[i, 0] == posiciones[j, 0] && posiciones[i, 1] == posiciones[j, 1])
                            {
                                return 1;
                            }
                            else
                            {
                                cont++;
                            }
                        }
                    }
                }
                return 0;
            }
            override public void ocuparlugar()
            {
                matrizp.setXY(POS[0], POS[1], 3);
            }
            override public void desocuparlugar(int x, int y)
            {
                matrizp.setXY(x, y, 0);
            }
            public Tablero getMatriza() { return matriza; }
        }
    }

