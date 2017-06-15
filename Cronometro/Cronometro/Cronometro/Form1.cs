using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Cronometro
{
    public partial class Form1 : Form
    {
        Stopwatch cronometro = new Stopwatch();
        int vezParcial = 0;
        string temp = "{0:00}:{0:00}:{0:02}";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //zerar o cronometro
            cronometro.Reset();

            //iniciar o cronometro
            cronometro.Start();

            //zerar as variaveis
            tbParcial.Text = null;
            vezParcial = 0;

            //desativar botão iniciar e ativar os de parada
            btnParar.Enabled = true;
            btnIniciar.Enabled = false;
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            //para o cronômetro
            cronometro.Stop();

            //desativar botões de paradas e ativar o de início
            btnParar.Enabled = false;
            btnIniciar.Enabled = true;
        }

        private void btnParcial_Click(object sender, EventArgs e)
        {
            vezParcial++;
            //jogar parcial no textbox e pular uma linha
            tbParcial.Text += vezParcial + "- " + lblTempo.Text + Environment.NewLine;
            //ir para a última linha do textbox
            tbParcial.SelectionStart = tbParcial.TextLength;
            tbParcial.ScrollToCaret();
        }

        private void tmrCronometro_Tick(object sender, EventArgs e)
        {
            lblTempo.Text = String.Format("{0:00}:{1:00}:{2:00}", cronometro.Elapsed.Hours, cronometro.Elapsed.Minutes, cronometro.Elapsed.Seconds, cronometro.Elapsed.Milliseconds / 10);
            //:{3:00}

            if (lblTempo.Text == String.Format("{0:00}:{0:00}:{0:15}", cronometro.Elapsed.Hours, cronometro.Elapsed.Minutes, cronometro.Elapsed.Seconds, cronometro.Elapsed.Milliseconds / 10))
            {
                tbParcial.Text = "Hora da 1ºpausa" + Environment.NewLine;
                //para o cronômetro
                cronometro.Stop();
                cronometro.Start();
            }


            else if (lblTempo.Text == string.Format("{0:00}:{0:00}:{0:30}", cronometro.Elapsed.Hours, cronometro.Elapsed.Minutes, cronometro.Elapsed.Seconds, cronometro.Elapsed.Milliseconds / 10))
            {
                cronometro.Stop();
                tbParcial.Text = "Final da pausa";
                cronometro.Reset();
                cronometro.Stop();
                cronometro.Start();
            }

            else if (lblTempo.Text == String.Format("{0:00}:{0:00}:{0:45}", cronometro.Elapsed.Hours, cronometro.Elapsed.Minutes, cronometro.Elapsed.Seconds, cronometro.Elapsed.Milliseconds / 10))
            {
                tbParcial.Text = "Hora da 2ºpausa" + Environment.NewLine;
                //para o cronômetro
                cronometro.Stop();
                cronometro.Start();
                cronometro.Reset();
                cronometro.Stop();
            }
        }
            

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblTempo_Click(object sender, EventArgs e)
        {

        }
    }
}

            

        

        
    
