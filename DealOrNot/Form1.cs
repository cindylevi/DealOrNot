using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Juegos;

namespace DealOrNot
{
    public partial class fDealOrNoDeal : Form
    {
        List<Button> listaBotones;
        List<Button> LISTAMontos;
        int MaletinElegido;
        deal_or_not Mijuego = new deal_or_not();
        public fDealOrNoDeal()
        {
            InitializeComponent();
            listaBotones = new List<Button>() { mal1, mal2, mal3, mal4, mal5, mal6, mal7, mal8, mal9, mal10, mal11, mal12, mal13, mal14, mal15, mal16 };
            LISTAMontos = new List<Button>() { btn1, btn5, btn10, btn50, btn100, btn500, btn1000, btn20000, btn5000, btn10000, btn20000, btn50000, btn100000, btn200000, btn300000, btn500000, btnMillon };
            picLogo.Image = Properties.Resources.Logo;
        }

        private void maletinclick(object sender, EventArgs e)
        {
            int ClickMal;
            int montoElegido;
            bool EligioOferta;
            Button botonMaletin = (Button)sender;
            botonMaletin.Visible = false;
            bool a = int.TryParse(botonMaletin.Text, out ClickMal);
            montoElegido = Mijuego.AbrirMaletin(ClickMal - 1);
            BorrarMonto(montoElegido);
            int JugadasRestantes = Mijuego.JugadasRestantes();
            int OfertaBanca = Mijuego.OfertaBanca();
            if (MaletinesRestantes(LISTAMontos))
            {
                MessageBox.Show("Selecciona el maletin que desees, inclusive el tuyo", "FINAL");
                listaBotones[MaletinElegido - 1].Enabled = true;
            }
            if (JugadasRestantes == 0)
            {
                
                    DialogResult result = MessageBox.Show("La oferta es " + OfertaBanca, "BANCA", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        EligioOferta = true;
                        int montoganado = Mijuego.DecisionOferta(EligioOferta);
                        MessageBox.Show("GANASTE $" + OfertaBanca);
                        Application.Exit();
                    }
                    else
                    {
                        EligioOferta = false;
                        int montoganado = Mijuego.DecisionOferta(EligioOferta);
                    }
            }

                      
        }

        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            btnIniciarJuego.Enabled = false;
            DOMelegirMaletin.Enabled = false;
            bool a = int.TryParse(DOMelegirMaletin.Text, out MaletinElegido);
            Mijuego.IniciarJuego(MaletinElegido);
            listaBotones[MaletinElegido - 1].Location = new Point(672, 12);
            listaBotones[MaletinElegido - 1].Enabled = false;
        }

        private void BorrarMonto(int montoelegido)
        {
            int i = 0;
            int montoprobar;
            bool cambiar = int.TryParse(LISTAMontos[i].Text, out montoprobar);
            while (montoelegido != montoprobar)
            {
                i++;
                cambiar = int.TryParse(LISTAMontos[i].Text, out montoprobar);
            }
            LISTAMontos[i].Visible = false;
        }
        private bool MaletinesRestantes(List<Button> LISTAMontos)
        {
            bool QuedanDos = false;
            int i, cantidadMaletines = 0;
            for (i = 0; i < 17; i++)
            {
               if (LISTAMontos[i].Visible == true)
                {
                    cantidadMaletines++;
                }
            }
            if (cantidadMaletines == 2)
            {
                QuedanDos = true;
            }
            return QuedanDos;
        }
    }
}
