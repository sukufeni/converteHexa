using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TraducaoHexaText
{
    public partial class Form1 : Form
    {
        string[,] tabelaEntrada;
        int linhaAtual;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader entrada = new StreamReader("C:/DDGIP.txt");
            entrada.ReadLine();
            int contador = 0;
            tabelaEntrada = new string[71,17];
            while (!entrada.EndOfStream)
            {
                string atual = entrada.ReadLine();
                string[] verificacao = atual.Split('\t');
                for(int x =0; x<verificacao.Length;x++)
                {
                    tabelaEntrada[contador, x] = verificacao[x];
                }
                contador++;
            }
            ManipulaArquivo arquivo = new ManipulaArquivo(this.tabelaEntrada);
        }
    }
}
