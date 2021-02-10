using System;

namespace Juegos
{
    public class Maletin
    {
        private int _numeroMaletin;
        private int _importe;

        public Maletin(int numeroMaletin, int importe)
        {
            _numeroMaletin = numeroMaletin;
            _importe = importe;
        }
        public Maletin()
        {
        }

        public int Importe
        {
            get
            {
                return _importe;
            }
            set
            {
                _importe = value;
            }
        }
        public int NumeroMaletin
        {
            get
            {
                return _numeroMaletin;
            }
            set
            {
                _numeroMaletin = value;
            }
        }
    }
}
