using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TraducaoHexaText
{
    class ManipulaArquivo
    {
        private string entrada;
        private string[,] saida, manipulado;
        public ManipulaArquivo(string [,]entrada)
        {
            this.manipulado= entrada;
            tabelaFinal();
        }

        private void tabelaFinal()
        {
            for(int x=0;x<manipulado.GetLength(0);x++)
            {
                entrada = manipulado[x, 4];
                if(entrada!=null)
                this.manipulado[x, 4] = converteHexa(entrada);
            }
            this.saida = manipulado;
            salvaTabela(this.saida);
        }
        private string converteHexa(string entrada)
        {
            string resultado = "";
            while (entrada.Length > 0)
            {
                resultado += System.Convert.ToChar(System.Convert.ToUInt32(entrada.Substring(0, 2), 16)).ToString();
                entrada = entrada.Substring(2, entrada.Length - 2);
            }
            return resultado;
        }
        private void salvaTabela(string [,]saida)
        {
            StreamWriter caminhoSaida = new StreamWriter("//srvdc03/COMUM/CPD/DDGIP.txt", true);
            string linhaAtual = "";
            for(int x = 0; x < saida.GetLength(0); x++)
            {
                if (saida[x, 0] != null)
                {
                    for (int y = 0; y < saida.GetLength(1) - 1; y++)
                    {
                        linhaAtual += saida[x, y].ToString() + '\t';
                    }
                    caminhoSaida.WriteLine(linhaAtual);
                    linhaAtual = "";
                }
                else
                {
                    caminhoSaida.Close();
                }
            }
        }
    }
}
