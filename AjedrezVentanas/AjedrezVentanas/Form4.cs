using Ns1;
using Ns2;
using Ns3;
using Ns4;
using Ns5;
using Ns6;
using Ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
           b(0,7) n(1,7) b(2,7) n(3,7) b(4,7) n(5,7) b(6,7) n(7,7)
           n(0,6) b(1,6) n(2,6) b(3,6) n(4,6) b(5,6) n(6,6) b(7,6)
           b(0,5) n(1,5) b(2,5) n(3,5) b(4,5) n(5,5) b(6,5) n(7,5)
           n(0,4) b(1,4) n(2,4) b(3,4) n(4,4) b(5,4) n(6,4) b(7,4)
           b(0,3) n(1,3) b(2,3) n(3,3) b(4,3) n(5,3) b(6,3) n(7,3)
           n(0,2) b(1,2) n(2,2) b(3,2) n(4,2) b(5,2) n(6,2) b(7,2) 
           b(0,1) n(1,1) b(2,1) n(3,1) b(4,1) n(5,1) b(6,1) n(7,1)
           n(0,0) b(1,0) n(2,0) b(3,0) n(4,0) b(5,0) n(6,0) b(7,0)  

*/

namespace AjedrezVentanas
{
    public partial class Form4 : Form
    {
        Form llamar;
        int checkcont;
        int jugar;
        int[] posinicial = { 0, 0 };
        static Random seed = new Random();        
        List<Tablero> tableros = new List<Tablero>();
        List<Pieza> piezas = new List<Pieza>();
        Tablero tablero = new Tablero();
        Tablero tablerodeamenazas = new Tablero();
        Reina queen = new Reina();
        Rey king = new Rey();
        Alfil wbishop = new Alfil();
        Alfil bbishop = new Alfil();
        Caballo bhorse = new Caballo();
        Caballo whorse = new Caballo();
        Torre wtower = new Torre();
        Torre btower = new Torre();        


        public Form4(Form llamado)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            llamar = llamado;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private const int CP_DISABLE_CLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CP_DISABLE_CLOSE_BUTTON;
                return cp;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkcont = 0;
            /// CREO 10 TABLEROS
            for (int k = 0; k < 10; k++)
            {
                Console.WriteLine("TABLERO NUMERO {0}", k+1);
                createboards(tableros, piezas);
            }
            createboardimage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(this, 1);
            form.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false;
            checkBox8.Checked = false; checkBox9.Checked = false; checkBox10.Checked = false;
            checkcont = 0;            
            //checkBox1.Checked = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false;
            checkBox8.Checked = false; checkBox9.Checked = false; checkBox10.Checked = false;
            checkcont = 8;
            //checkBox2.Checked = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false; checkBox1.Checked = false; checkBox4.Checked = false;
            checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false;
            checkBox8.Checked = false; checkBox9.Checked = false; checkBox10.Checked = false;
            checkcont = 16;            
            //checkBox3.Checked = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false; checkBox3.Checked = false; checkBox1.Checked = false;
            checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false;
            checkBox8.Checked = false; checkBox9.Checked = false; checkBox10.Checked = false;
            checkcont = 24;
            //checkBox4.Checked = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            checkBox1.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false;
            checkBox8.Checked = false; checkBox9.Checked = false; checkBox10.Checked = false;
            checkcont = 32;
            //checkBox5.Checked = true;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            checkBox5.Checked = false; checkBox1.Checked = false; checkBox7.Checked = false;
            checkBox8.Checked = false; checkBox9.Checked = false; checkBox10.Checked = false;
            checkcont = 40;
            //checkBox6.Checked = true;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            checkBox5.Checked = false; checkBox6.Checked = false; checkBox1.Checked = false;
            checkBox8.Checked = false; checkBox9.Checked = false; checkBox10.Checked = false;
            checkcont = 48;
            //checkBox7.Checked = true;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false;
            checkBox1.Checked = false; checkBox9.Checked = false; checkBox10.Checked = false;
            checkcont = 56;
            //checkBox8.Checked = true;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false;
            checkBox8.Checked = false; checkBox1.Checked = false; checkBox10.Checked = false;
            checkcont = 64;
            //checkBox9.Checked = true;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false;
            checkBox8.Checked = false; checkBox9.Checked = false; checkBox1.Checked = false;
            checkcont = 72;
            //checkBox10.Checked = true;
        }

        private void createboards(List<Tablero> list_tableros, List<Pieza> list_piezas)
        {
            Random rd = new Random(seed.Next());

            int[] posreina = { rd.Next(3, 5), rd.Next(3, 5) }; /// SPAWNEA EN EL CENTRO           

            int[] posrey = { rd.Next(1, 6), rd.Next(1, 6) };

            int[] poscaballob = { rd.Next(2, 5), rd.Next(2, 4) };

            int[] poscaballon = { rd.Next(2, 6), rd.Next(4, 6) };

            int[] postorreb = { 0, 0 };

            int[] postorren = { 7, 7 };

            int chnc = rd.Next(0, 4);
            switch (chnc) { 
                case 0:
                    postorreb[0] = 0;
                    postorreb[1] = 0;
                    postorren[0] = 7;
                    postorren[1] = 7;
                    break;
                case 1:
                    postorreb[0] = 7;
                    postorreb[1] = 7;
                    postorren[0] = 0;
                    postorren[1] = 0;
                    break;
                case 2:
                    postorreb[0] = 0;
                    postorreb[1] = 7;
                    postorren[0] = 7;
                    postorren[1] = 0;
                    break;
                case 3:
                    postorreb[0] = 7;
                    postorreb[1] = 0;
                    postorren[0] = 0;
                    postorren[1] = 7;
                    break;
            }

            int[,] casillasblancas = {{1,0},{3,0},{5,0},{7,0},{0,1},{2,1},{4,1},{6,1},
                                      {1,2},{3,2},{5,2},{7,2},{0,3},{2,3},{4,3},{6,3},
                                      {1,4},{3,4},{5,4},{7,4},{0,5},{2,5},{4,5},{6,5},
                                      {1,6},{3,6},{5,6},{7,6},{0,7},{2,7},{4,7},{6,7} };

            int[,] casillasnegras = { {0,0},{2,0},{4,0},{6,0},{1,1},{3,1},{5,1},{7,1},
                                      {0,2},{2,2},{4,2},{6,2},{1,3},{3,3},{5,3},{7,3},
                                      {0,4},{2,4},{4,4},{6,4},{1,5},{3,5},{5,5},{7,5},
                                      {0,6},{2,6},{4,6},{6,6},{1,7},{3,7},{5,7},{7,7} };

            int random = rd.Next(0, 32);
            int[] posalfilb = { casillasblancas[random, 0], casillasblancas[random, 1] };
            random = rd.Next(0, 32);
            int[] posalfiln = { casillasnegras[random, 0], casillasnegras[random, 1] };

            ///NoPisar(posreina, posrey, postorreb, postorren, poscaballob, poscaballon, posalfilb, posalfiln);

            /// posreina posrey postorreb postorren poscaballob poscaballon posalfilb posalfiln

            tablero = new Tablero();
            tablerodeamenazas = new Tablero();

            queen = new Reina(posreina, tablerodeamenazas, tablero);
            king = new Rey(posrey, tablerodeamenazas, tablero);
            wbishop = new Alfil(posalfilb, tablerodeamenazas, tablero, 1);
            bbishop = new Alfil(posalfiln, tablerodeamenazas, tablero, 0);
            bhorse = new Caballo(poscaballon, tablerodeamenazas, tablero);
            whorse = new Caballo(poscaballob, tablerodeamenazas, tablero);
            wtower = new Torre(postorreb, tablerodeamenazas, tablero);
            btower = new Torre(postorren, tablerodeamenazas, tablero);
            Pieza[] array0 = { queen, king, wbishop, bbishop, whorse, bhorse, wtower, btower };

            int[,] matrizposiciones = tablero.GetXY();
            int[,] matrizamenazadas = tablerodeamenazas.GetXY();

            MoverPiezasTableroComun(array0, matrizamenazadas);
            
            ImprimirTablero(matrizposiciones);
            ///Console.Write("\n");
            ImprimirTablero(matrizamenazadas);
            
            list_piezas.Add(queen);
            list_piezas.Add(king);
            list_piezas.Add(wbishop);
            list_piezas.Add(bbishop);
            list_piezas.Add(whorse);
            list_piezas.Add(bhorse);
            list_piezas.Add(wtower);
            list_piezas.Add(btower);

            list_tableros.Add(tablerodeamenazas);

            tablero.clean();
            tablerodeamenazas.clean();            
        }

        public static void ImprimirTablero(int[,] matrizposiciones)
        {
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", matrizposiciones[0, 0], matrizposiciones[0, 1], matrizposiciones[0, 2], matrizposiciones[0, 3], matrizposiciones[0, 4], matrizposiciones[0, 5], matrizposiciones[0, 6], matrizposiciones[0, 7]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", matrizposiciones[1, 0], matrizposiciones[1, 1], matrizposiciones[1, 2], matrizposiciones[1, 3], matrizposiciones[1, 4], matrizposiciones[1, 5], matrizposiciones[1, 6], matrizposiciones[1, 7]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", matrizposiciones[2, 0], matrizposiciones[2, 1], matrizposiciones[2, 2], matrizposiciones[2, 3], matrizposiciones[2, 4], matrizposiciones[2, 5], matrizposiciones[2, 6], matrizposiciones[2, 7]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", matrizposiciones[3, 0], matrizposiciones[3, 1], matrizposiciones[3, 2], matrizposiciones[3, 3], matrizposiciones[3, 4], matrizposiciones[3, 5], matrizposiciones[3, 6], matrizposiciones[3, 7]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", matrizposiciones[4, 0], matrizposiciones[4, 1], matrizposiciones[4, 2], matrizposiciones[4, 3], matrizposiciones[4, 4], matrizposiciones[4, 5], matrizposiciones[4, 6], matrizposiciones[4, 7]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", matrizposiciones[5, 0], matrizposiciones[5, 1], matrizposiciones[5, 2], matrizposiciones[5, 3], matrizposiciones[5, 4], matrizposiciones[5, 5], matrizposiciones[5, 6], matrizposiciones[5, 7]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", matrizposiciones[6, 0], matrizposiciones[6, 1], matrizposiciones[6, 2], matrizposiciones[6, 3], matrizposiciones[6, 4], matrizposiciones[6, 5], matrizposiciones[6, 6], matrizposiciones[6, 7]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", matrizposiciones[7, 0], matrizposiciones[7, 1], matrizposiciones[7, 2], matrizposiciones[7, 3], matrizposiciones[7, 4], matrizposiciones[7, 5], matrizposiciones[7, 6], matrizposiciones[7, 7]);
            ///Console.WriteLine("\n");
            ///Console.ReadLine();
        }
        public static void MoverPiezasTableroComun(Pieza[] piezas, int[,] matriz)
        {
            int contador = 0;

            while (true)
            { /// LA CANTIDAD DE CASILLAS NO IGUALES A CERO DE LA MATRIZ TIENE QUE SER IGUAL A  64
                contador = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (matriz[i, j] != 0) { contador++; }
                    }
                }
                if (contador >= 64) return;
                for (int i = 0; i < 8; i++)
                {
                    piezas[i].desamenazar();
                    piezas[i].desocuparlugar(piezas[i].GetPos()[0], piezas[i].GetPos()[1]);
                    piezas[i].salto();
                    piezas[i].lugaresamenazados();
                    piezas[i].ocuparlugar();
                }
            }

        }
        public static void NoPisar(int[] v0, int[] v1, int[] v2, int[] v3, int[] v4, int[] v5, int[] alfil1, int[] alfil2)
        {
            Random rdx = new Random();
            Random rdy = new Random();

            int cont = 0;

            int[,] posiciones = { { v0[0], v0[1] },{ v1[0], v1[1] }, { v2[0], v2[1]}, { v3[0], v3[1] },
                              { v4[0], v4[1]}, { v5[0], v5[1]}, { alfil1[0], alfil1[1]}, {alfil2[0], alfil2[1]}};

            while (true)
            {
                cont = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (i == j)
                        {
                        }
                        else if (posiciones[i, 0] == posiciones[j, 0] && posiciones[i, 1] == posiciones[j, 1])
                        {
                            posiciones[i, 0] = rdx.Next(0, 8);
                            posiciones[i, 1] = rdy.Next(0, 8);
                        }
                        else
                        {
                            cont++;
                            if (cont >= 8) return;
                        }
                    }
                }
            }
        }

        public System.Drawing.Image Image { get; set; }
        public Button[,] btnGrid = new Button[10, 10];

        private void createboardimage() {

            int tamanio = BoardPanel.Width / 10;
            BoardPanel.Height = BoardPanel.Width;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Height = tamanio;
                    btnGrid[i, j].Width = tamanio;
                    BoardPanel.Controls.Add(btnGrid[i, j]);
                    btnGrid[i, j].Location = new Point((i - 2) * tamanio, (j - 2) * tamanio);

                    if (((i % 2) == 0 && (j % 2) == 0) || ((i % 2) != 0 && (j % 2) != 0))
                    {
                        btnGrid[i, j].BackColor = Color.FromArgb(128, 128, 128);
                        btnGrid[i, j].FlatStyle = FlatStyle.Flat;
                        btnGrid[i, j].FlatAppearance.BorderColor = Color.Black;
                        btnGrid[i, j].FlatAppearance.BorderSize = 1;
                    }
                    if (((i % 2) == 0 && (j % 2) != 0) || ((i % 2) != 0 && (j % 2) == 0))
                    {
                        btnGrid[i, j].BackColor = Color.FromArgb(255, 255, 255);
                        btnGrid[i, j].FlatStyle = FlatStyle.Flat;
                        btnGrid[i, j].FlatAppearance.BorderColor = Color.Black;
                        btnGrid[i, j].FlatAppearance.BorderSize = 1;
                    }
                }
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            /// POSICIONAMOS LAS PIEZAS AMENAZANDO 64 CASILLAS
            
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    btnGrid[i, j].BackgroundImage = null;
                }
            }

            for(int i = 0; i < 8; i++) {
                for(int j = 0; j < 8; j++) {
                    if (tableros[checkcont/8].GetXY()[i, j] > 1)
                    {
                        btnGrid[i + 2, j + 2].BackColor = Color.FromArgb(156, 0, 0);
                    } else {
                        btnGrid[i + 2, j + 2].BackColor = Color.FromArgb(57, 50, 228);
                    }
                }
            }

            if (piezas != null)
            {
                btnGrid[piezas.ElementAt(checkcont).GetPos()[0] + 2, piezas.ElementAt(checkcont).GetPos()[1] + 2].BackgroundImage = Image.FromFile("C:\\Users\\Christian\\source\\repos\\AjedrezVentanas\\AjedrezVentanas\\Imagenes\\queen.png");
                btnGrid[piezas.ElementAt(checkcont).GetPos()[0] + 2, piezas.ElementAt(checkcont).GetPos()[1] + 2].BackgroundImageLayout = ImageLayout.Stretch;
                btnGrid[piezas.ElementAt((checkcont) + 1).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 1).GetPos()[1] + 2].BackgroundImage = Image.FromFile("C:\\Users\\Christian\\source\\repos\\AjedrezVentanas\\AjedrezVentanas\\Imagenes\\king.png");
                btnGrid[piezas.ElementAt((checkcont) + 1).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 1).GetPos()[1] + 2].BackgroundImageLayout = ImageLayout.Stretch;
                btnGrid[piezas.ElementAt((checkcont) + 2).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 2).GetPos()[1] + 2].BackgroundImage = Image.FromFile("C:\\Users\\Christian\\source\\repos\\AjedrezVentanas\\AjedrezVentanas\\Imagenes\\bishopw.png");
                btnGrid[piezas.ElementAt((checkcont) + 2).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 2).GetPos()[1] + 2].BackgroundImageLayout = ImageLayout.Stretch;
                btnGrid[piezas.ElementAt((checkcont) + 3).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 3).GetPos()[1] + 2].BackgroundImage = Image.FromFile("C:\\Users\\Christian\\source\\repos\\AjedrezVentanas\\AjedrezVentanas\\Imagenes\\bishopb.png");
                btnGrid[piezas.ElementAt((checkcont) + 3).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 3).GetPos()[1] + 2].BackgroundImageLayout = ImageLayout.Stretch;
                btnGrid[piezas.ElementAt((checkcont) + 4).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 4).GetPos()[1] + 2].BackgroundImage = Image.FromFile("C:\\Users\\Christian\\source\\repos\\AjedrezVentanas\\AjedrezVentanas\\Imagenes\\whorse.png");
                btnGrid[piezas.ElementAt((checkcont) + 4).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 4).GetPos()[1] + 2].BackgroundImageLayout = ImageLayout.Stretch;
                btnGrid[piezas.ElementAt((checkcont) + 5).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 5).GetPos()[1] + 2].BackgroundImage = Image.FromFile("C:\\Users\\Christian\\source\\repos\\AjedrezVentanas\\AjedrezVentanas\\Imagenes\\horse.png");
                btnGrid[piezas.ElementAt((checkcont) + 5).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 5).GetPos()[1] + 2].BackgroundImageLayout = ImageLayout.Stretch;
                btnGrid[piezas.ElementAt((checkcont) + 6).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 6).GetPos()[1] + 2].BackgroundImage = Image.FromFile("C:\\Users\\Christian\\source\\repos\\AjedrezVentanas\\AjedrezVentanas\\Imagenes\\wtower.png");
                btnGrid[piezas.ElementAt((checkcont) + 6).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 6).GetPos()[1] + 2].BackgroundImageLayout = ImageLayout.Stretch;
                btnGrid[piezas.ElementAt((checkcont) + 7).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 7).GetPos()[1] + 2].BackgroundImage = Image.FromFile("C:\\Users\\Christian\\source\\repos\\AjedrezVentanas\\AjedrezVentanas\\Imagenes\\tower.png");
                btnGrid[piezas.ElementAt((checkcont) + 7).GetPos()[0] + 2, piezas.ElementAt((checkcont) + 7).GetPos()[1] + 2].BackgroundImageLayout = ImageLayout.Stretch;
            }
            
        }
    }
}




///  TORRES FIJAS, ALFILES NO SE CRUCEN A LA REINA, REY ESTA BIEN, REINA ESTA BIEN, CABALLOS ENTRE EN Y (0 1, 6 7) X (0 1, 6 7)

/// LAS CASILLAS AMENAZADAS LETALMENTE SON LAS QUE AMENAZA NORMAL, LAS AMENAZADAS LEVEMENTE SON LAS CASILLAS QUE ESTAN DESPUES DE UNA PIEZA

namespace Ns1
{
    public class Pieza
    {
        public Pieza()
        {

        }
        ///virtual public int Mover(int[] v0, int[] v1, int[] v2, int[] v3, int[] v4, int[] v5, int[] v6, int[] v7) { return 0; }
        ///virtual public void Mover(int[] v0, int[] v1, int[] v2, int[] v3, int[] v4, int[] v5, int[] v6, int[] v7) { }
        ///virtual public int lugaresamenazados() { return 0; }
        virtual public void salto() { }
        virtual public void lugaresamenazados() { }
        virtual public void desamenazar() { }
        virtual public void ocuparlugar() { }
        virtual public void desocuparlugar(int x, int y) { }
        public Tablero getMatriza() { return null; }
        public virtual int[] GetPos() { int[] r = { 0, 0 }; return r; }
        public virtual int NoPisar(int[] v0, int[] v1, int[] v2, int[] v3, int[] v4, int[] v5, int[] alfil1, int[] alfil2) { return 0; }
    }
}
namespace Ns2
{
    public class Reina : Pieza
    {
        Tablero matriza, matrizp;
        static Random rd = new Random();
        int[] POS = { 0, 0 };
        public Reina() { }
        public Reina(int[] xy, Tablero matrizamenaza, Tablero matrizpos)
        {
            matriza = matrizamenaza;
            matrizp = matrizpos;
            POS[0] = xy[0];
            POS[1] = xy[1];
            ocuparlugar();
            lugaresamenazados();

        }
        public override void salto()
        {
            Random random = new Random(rd.Next());
            POS[0] = random.Next(3, 5);
            POS[1] = random.Next(3, 5);

        }
        public void clearPos()
        {
            POS[0] = 0;
            POS[1] = 0;
        }
        override public int[] GetPos() { return POS; }
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
        public override void desamenazar()
        {
            int freecases = 0, aux1 = 0;
            matriza.desamenazarlugar(POS[1], POS[0]);
            ///PARTE DE TORRE ARRIBA 
            for (int i = 1; i < 8; i++)
            {
                if (POS[1] - i > -1)
                {
                    matriza.desamenazarlugar(POS[1] - i, POS[0]);
                }
                else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE ABAJO 
            for (int i = 1; i < 8; i++)
            {
                if (POS[1] + i < 8)
                {
                    matriza.desamenazarlugar(POS[1] + i, POS[0]);
                }
                else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE IZQUIERDA 
            for (int i = 1; i < 8; i++)
            {
                if (POS[0] - i > -1) { matriza.desamenazarlugar(POS[1], POS[0] - i); } else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE DERECHA  
            for (int i = 1; i < 8; i++)
            {
                if (POS[0] + i < 8) { matriza.desamenazarlugar(POS[1], POS[0] + i); } else { break; }
                ///contador++;
            }
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
            matriza.amenazarlugar(POS[1], POS[0]);
            ///PARTE DE TORRE ARRIBA 
            for (int i = 1; i < 8; i++)
            {
                if (POS[1] - i > -1)
                {
                    matriza.amenazarlugar(POS[1] - i, POS[0]);
                }
                else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE ABAJO 
            for (int i = 1; i < 8; i++)
            {
                if (POS[1] + i < 8)
                {
                    matriza.amenazarlugar(POS[1] + i, POS[0]);
                }
                else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE IZQUIERDA 
            for (int i = 1; i < 8; i++)
            {
                if (POS[0] - i > -1) { matriza.amenazarlugar(POS[1], POS[0] - i); } else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE DERECHA  
            for (int i = 1; i < 8; i++)
            {
                if (POS[0] + i < 8) { matriza.amenazarlugar(POS[1], POS[0] + i); } else { break; }
                ///contador++;
            }
            ///if (POS[0] < POS[1]) { aux1 = POS[0]; } else { aux1 = POS[1]; }
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

            ///return contador;

        }
        override public void ocuparlugar()
        {
            matrizp.setXY(POS[0], POS[1], 1);
        }
        override public void desocuparlugar(int x, int y)
        {
            matrizp.setXY(x, y, 0);
        }
        public Tablero getMatriza() { return matriza; }
    }
}
namespace Ns3
{
    public class Rey : Pieza
    {
        public Tablero matriza, matrizp;
        static Random rd = new Random();
        int[] POS = { 0, 0 };
        public Rey() { }
        public Rey(int[] xy, Tablero matrizamenaza, Tablero matrizpos)
        {

            matriza = matrizamenaza;
            matrizp = matrizpos;
            POS[0] = xy[0];
            POS[1] = xy[1];
            ocuparlugar();
            lugaresamenazados();

        }
        
        public override void salto()
        {
            Random random = new Random(rd.Next());
            POS[0] = random.Next(1, 6);
            POS[1] = random.Next(1, 6);

        }
        
        public void clearPos()
        {
            POS[0] = 0;
            POS[1] = 0;
        }
        override public int[] GetPos() { return POS; }
        public override void desamenazar()
        {
            int contador = 0, freecases = 0, aux1 = 0;

            matriza.desamenazarlugar(POS[1], POS[0]);
            ///PARTE DE TORRE ARRIBA 
            if (POS[1] - 1 > -1) { matriza.desamenazarlugar(POS[1] - 1, POS[0]); }
            ///contador++;            
            ///PARTE DE TORRE ABAJO 
            if (POS[1] + 1 < 8) { matriza.desamenazarlugar(POS[1] + 1, POS[0]); }
            ///contador++;
            ///PARTE DE TORRE IZQUIERDA 
            if (POS[0] - 1 > -1) { matriza.desamenazarlugar(POS[1], POS[0] - 1); }
            ///contador++;
            ///PARTE DE TORRE DERECHA 
            if (POS[0] + 1 < 8) { matriza.desamenazarlugar(POS[1], POS[0] + 1); }
            ///contador++;            
            ///
            if (POS[0] < POS[1]) { aux1 = POS[0]; } else { aux1 = POS[1]; }
            ///PARTE DE ALFIL ARRIBA IZQUIERDA nop
            if (POS[0] - 1 > -1 && POS[1] - 1 > -1)
            {
                matriza.desamenazarlugar(POS[1] - 1, POS[0] - 1);
            }
            ///contador++;

            ///PARTE DE ALFIL ABAJO DERECHA nop                        

            if (POS[0] + 1 < 8 && POS[1] + 1 < 8)
            {
                matriza.desamenazarlugar(POS[1] + 1, POS[0] + 1);
            }
            ///contador++;

            ///PARTE DE ALFIL ABAJO IZQUIERDA                                  

            if (POS[0] - 1 > -1 && POS[1] + 1 < 8)
            {
                matriza.desamenazarlugar(POS[0] - 1, POS[1] + 1);
            }

            ///PARTE DE ALFIL ARRIBA DERECHA                         

            if (POS[0] + 1 < 8 && POS[1] - 1 > -1)
            {
                matriza.desamenazarlugar(POS[0] + 1, POS[1] - 1);
            }
        }
        public override void lugaresamenazados()
        {
            int contador = 0, freecases = 0, aux1 = 0;

            matriza.amenazarlugar(POS[1], POS[0]);
            ///PARTE DE TORRE ARRIBA 
            if (POS[1] - 1 > -1) { matriza.amenazarlugar(POS[1] - 1, POS[0]); }
            ///contador++;            
            ///PARTE DE TORRE ABAJO 
            if (POS[1] + 1 < 8) { matriza.amenazarlugar(POS[1] + 1, POS[0]); }
            ///contador++;
            ///PARTE DE TORRE IZQUIERDA 
            if (POS[0] - 1 > -1) { matriza.amenazarlugar(POS[1], POS[0] - 1); }
            ///contador++;
            ///PARTE DE TORRE DERECHA 
            if (POS[0] + 1 < 8) { matriza.amenazarlugar(POS[1], POS[0] + 1); }
            ///contador++;            
            ///
            if (POS[0] < POS[1]) { aux1 = POS[0]; } else { aux1 = POS[1]; }
            ///PARTE DE ALFIL ARRIBA IZQUIERDA nop
            if (POS[0] - 1 > -1 && POS[1] - 1 > -1)
            {
                matriza.amenazarlugar(POS[1] - 1, POS[0] - 1);
            }
            ///contador++;

            ///PARTE DE ALFIL ABAJO DERECHA nop                        

            if (POS[0] + 1 < 8 && POS[1] + 1 < 8)
            {
                matriza.amenazarlugar(POS[1] + 1, POS[0] + 1);
            }
            ///contador++;

            ///PARTE DE ALFIL ABAJO IZQUIERDA                                  

            if (POS[0] - 1 > -1 && POS[1] + 1 < 8)
            {
                matriza.amenazarlugar(POS[0] - 1, POS[1] + 1);
            }

            ///PARTE DE ALFIL ARRIBA DERECHA                         

            if (POS[0] + 1 < 8 && POS[1] - 1 > -1)
            {
                matriza.amenazarlugar(POS[0] + 1, POS[1] - 1);
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
                cont = 1;
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
            matrizp.setXY(POS[0], POS[1], 2);
        }
        override public void desocuparlugar(int x, int y)
        {
            matrizp.setXY(x, y, 0);
        }
        public Tablero getMatriza() { return matriza; }
    }
}
namespace Ns4
{
    public class Alfil : Pieza
    {
        public Tablero matriza, matrizp;
        static Random rd = new Random();
        public int Color;
        int[] POS = { 0, 0 };
        public Alfil() { }
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
            Random random = new Random(rd.Next());
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
                POS[0] = casillasblancas[random.Next(0, 32), 0];
                POS[1] = casillasblancas[random.Next(0, 32), 1];
            }
            else
            {
                POS[0] = casillasnegras[rd.Next(0, 32), 0];
                POS[1] = casillasnegras[rd.Next(0, 32), 1];
            }


        }
        public void clearPos()
        {
            POS[0] = 0;
            POS[1] = 0;
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
namespace Ns5
{
    public class Caballo : Pieza
    {
        public Tablero matriza, matrizp;
        static Random rd = new Random();
        int[] POS = { 0, 0 };
        public Caballo() { }
        public Caballo(int[] xy, Tablero matrizamenaza, Tablero matrizpos)
        {

            matriza = matrizamenaza;
            matrizp = matrizpos;
            POS[0] = xy[0];
            POS[1] = xy[1];
            ocuparlugar();
            lugaresamenazados();

        }
        public override void salto()
        {
            Random random = new Random(rd.Next());
            POS[0] = random.Next(2, 4);
            POS[1] = random.Next(4, 6);

        }
        public void clearPos()
        {
            POS[0] = 0;
            POS[1] = 0;
        }
        override public int[] GetPos() { return POS; }
        public override void desamenazar()
        {
            int aux1 = 0, aux2 = 0;

            matriza.desamenazarlugar(POS[1], POS[0]);
            /// 0
            if (POS[0] > -1 && POS[1] > 1)
            {
                aux1 = POS[0] - 1;
                aux2 = POS[1] - 2;
                matriza.desamenazarlugar(aux2, aux1);
            }
            /// 1
            if (POS[0] > 1 && POS[1] > 0)
            {
                aux1 = POS[0] - 2;
                aux2 = POS[1] - 1;
                matriza.desamenazarlugar(aux2, aux1);
            }
            /// 2
            if (POS[0] > 1 && POS[1] < 6)
            {
                aux1 = POS[0] - 2;
                aux2 = POS[1] + 1;
                matriza.desamenazarlugar(aux2, aux1);
            }
            /// 3
            if (POS[0] > 1 && POS[1] < 7)
            {
                aux1 = POS[0] - 1;
                aux2 = POS[1] + 2;
                matriza.desamenazarlugar(aux2, aux1);
            }
            /// 4
            if (POS[0] < 8 && POS[1] > 1)
            {
                aux1 = POS[0] + 1;
                aux2 = POS[1] - 2;
                matriza.desamenazarlugar(aux2, aux1);
            }
            /// 5
            if (POS[0] < 6 && POS[1] > 0)
            {
                aux1 = POS[0] + 2;
                aux2 = POS[1] - 1;
                matriza.desamenazarlugar(aux2, aux1);
            }
            /// 6
            if (POS[0] > 0 && POS[0] < 8 && POS[1] < 6)
            {
                aux1 = POS[0] + 2;
                aux2 = POS[1] + 1;
                matriza.desamenazarlugar(aux2, aux1);
            }
            /// 7
            if (POS[0] < 6 && POS[1] < 6)
            {
                aux1 = POS[0] + 1;
                aux2 = POS[1] + 2;
                matriza.desamenazarlugar(aux2, aux1);
            }
        }
        public override void lugaresamenazados()
        {
            int aux1 = 0, aux2 = 0;
            matriza.amenazarlugar(POS[1], POS[0]);
            /// 0
            if (POS[0] > -1 && POS[1] > 1)
            {
                aux1 = POS[0] - 1;
                aux2 = POS[1] - 2;
                matriza.amenazarlugar(aux2, aux1);
            }
            /// 1
            if (POS[0] > 1 && POS[1] > 0)
            {
                aux1 = POS[0] - 2;
                aux2 = POS[1] - 1;
                matriza.amenazarlugar(aux2, aux1);
            }
            /// 2
            if (POS[0] > 1 && POS[1] < 6)
            {
                aux1 = POS[0] - 2;
                aux2 = POS[1] + 1;
                matriza.amenazarlugar(aux2, aux1);
            }
            /// 3
            if (POS[0] > 1 && POS[1] < 7)
            {
                aux1 = POS[0] - 1;
                aux2 = POS[1] + 2;
                matriza.amenazarlugar(aux2, aux1);
            }
            /// 4
            if (POS[0] < 8 && POS[1] > 1)
            {
                aux1 = POS[0] + 1;
                aux2 = POS[1] - 2;
                matriza.amenazarlugar(aux2, aux1);
            }
            /// 5
            if (POS[0] < 6 && POS[1] > 0)
            {
                aux1 = POS[0] + 2;
                aux2 = POS[1] - 1;
                matriza.amenazarlugar(aux2, aux1);
            }
            /// 6
            if (POS[0] > 0 && POS[0] < 8 && POS[1] < 6)
            {
                aux1 = POS[0] + 2;
                aux2 = POS[1] + 1;
                matriza.amenazarlugar(aux2, aux1);
            }
            /// 7
            if (POS[0] < 6 && POS[1] < 6)
            {
                aux1 = POS[0] + 1;
                aux2 = POS[1] + 2;
                matriza.amenazarlugar(aux2, aux1);
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
            matrizp.setXY(POS[0], POS[1], 4);
        }
        override public void desocuparlugar(int x, int y)
        {
            matrizp.setXY(x, y, 0);
        }
        public Tablero getMatriza() { return matriza; }
    }
}
namespace Ns6
{
    public class Torre : Pieza
    {
        public Tablero matriza, matrizp;
        int[] POS = { 0, 0 };
        public Torre() { }
        public Torre(int[] xy, Tablero matrizamenaza, Tablero matrizpos)
        {

            matriza = matrizamenaza;
            matrizp = matrizpos;
            POS[0] = xy[0];
            POS[1] = xy[1];
            ocuparlugar();
            lugaresamenazados();

        }
        public void clearPos()
        {
            POS[0] = 0;
            POS[1] = 0;
        }
        override public int[] GetPos() { return POS; }
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
        public override void desamenazar()
        {
            int freecases = 0, aux1 = 0;

            matriza.desamenazarlugar(POS[1], POS[0]);
            ///PARTE DE TORRE ARRIBA 
            for (int i = 1; i < 8; i++)
            {
                if (POS[1] - i > -1)
                {
                    matriza.desamenazarlugar(POS[1] - i, POS[0]);
                }
                else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE ABAJO 
            for (int i = 1; i < 8; i++)
            {
                if (POS[1] + i < 8)
                {
                    matriza.desamenazarlugar(POS[1] + i, POS[0]);
                }
                else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE IZQUIERDA 
            for (int i = 1; i < 8; i++)
            {
                if (POS[0] - i > -1) { matriza.desamenazarlugar(POS[1], POS[0] - i); } else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE DERECHA  
            for (int i = 1; i < 8; i++)
            {
                if (POS[0] + i < 8) { matriza.desamenazarlugar(POS[1], POS[0] + i); } else { break; }
                ///contador++;
            }

        }
        public override void lugaresamenazados()
        {
            int freecases = 0, aux1 = 0;
            matriza.amenazarlugar(POS[1], POS[0]);
            ///PARTE DE TORRE ARRIBA 
            for (int i = 1; i < 8; i++)
            {
                if (POS[1] - i > -1)
                {
                    matriza.amenazarlugar(POS[1] - i, POS[0]);
                }
                else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE ABAJO 
            for (int i = 1; i < 8; i++)
            {
                if (POS[1] + i < 8)
                {
                    matriza.amenazarlugar(POS[1] + i, POS[0]);
                }
                else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE IZQUIERDA 
            for (int i = 1; i < 8; i++)
            {
                if (POS[0] - i > -1) { matriza.amenazarlugar(POS[1], POS[0] - i); } else { break; }
                ///contador++;
            }
            ///PARTE DE TORRE DERECHA  
            for (int i = 1; i < 8; i++)
            {
                if (POS[0] + i < 8) { matriza.amenazarlugar(POS[1], POS[0] + i); } else { break; }
                ///contador++;
            }

        }
        override public void ocuparlugar()
        {
            matrizp.setXY(POS[0], POS[1], 5);
        }
        override public void desocuparlugar(int x, int y)
        {
            matrizp.setXY(x, y, 0);
        }
        public Tablero getMatriza() { return matriza; }
    }
}
namespace Ns8
{
    public class Tablero
    {
        int[,] tablero = new int[8, 8];
        public Tablero()
        {

            clean();

        }
        public void clean() {
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
