using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFINALLP2
{
    class Pieza
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
