using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Controller
{
    public class Geracao
    {
        int quantidadeCidades, quantidadeDeIndividuos;
        List<int> aleatorioUsado = new List<int>();
        List<int[]> individuos = new List<int[]>();
        Random numAleatorio = new Random();
        int[,] cidades;
        public Geracao(int[,] cidades)
        {
            //Pega quantidade de cidades e quantidade de individuos
            quantidadeCidades = cidades.GetLength(0);
            quantidadeDeIndividuos = quantidadeCidades * 5;
            this.cidades = cidades;
            //Gera individuos aleatorios
            gerarIndiviuosAleatorios(quantidadeCidades, cidades);
        }
        public Geracao(int[,] cidades, List<int[]> individuosSelecionados, int[] melhorIndividuo)
        {
            quantidadeCidades = cidades.GetLength(0);
            //Quantidade de individuoos é a quantiade de cidades * algum número - a quantidade de indivíduos que vamos manter da geração anterior
            quantidadeDeIndividuos = ( (quantidadeCidades * 1) - individuosSelecionados.Count - 1);
            this.cidades = cidades;

            //Gera individuos aleatorios
            gerarIndiviuosAleatorios(quantidadeCidades, cidades);
            cruzamento(individuosSelecionados);
            this.individuos.Add(melhorIndividuo);
        }
        public void cruzamento(List<int[]>pais)
        {
            List<int> filho1 = new List<int>();
            List<int> filho2 = new List<int>();

            for(int i = 0; i < pais[0].Length; i++)
            {
                if(i <= ((pais[0].Length-1)/2))
                {
                    filho1.Add(pais[0][i]);
                }
                else
                {
                   for(int j = 0; j < pais[1].Length; j++)
                    {
                        if (!filho1.Contains(pais[1][j]))
                        {
                            filho1.Add(pais[1][j]);
                        }
                    }
                }
            }

            for (int i = 0; i < pais[1].Length; i++)
            {
                if (i <= (pais[1].Length)/2)
                {
                    filho2.Add(pais[1][i]);
                }
                else
                {
                    for (int j = 0; j < pais[0].Length; j++)
                    {
                        if (!filho2.Contains(pais[0][j]))
                        {
                            filho2.Add(pais[0][j]);
                        }
                    }
                }
            }
            filho1[filho1.Count-1] = calcTamanhoTrajeto(filho1.ToArray(), this.cidades);
            filho2[filho2.Count-1] = calcTamanhoTrajeto(filho2.ToArray(), this.cidades);

            this.individuos.Add(filho1.ToArray());
            this.individuos.Add(filho2.ToArray());
        }
        public void gerarIndiviuosAleatorios(int quantidadeCidades, int[,] cidades)
        {
            for (int qi = 0; qi < quantidadeDeIndividuos; qi++)
            {
                clearAleatorioUsado();
                //Define a rota aleatória do indivíduo
                int[] rota = new int[quantidadeCidades + 1];
                rota[0] = 1;
                for (int i = 1; i <= quantidadeCidades; i++)
                {
                    if (i == quantidadeCidades)
                    {
                        rota[i] = calcTamanhoTrajeto(rota, cidades);
                    }
                    else
                    {
                        rota[i] = getCidadeAleatoria(quantidadeCidades);
                    }
                }

                //Adciona a rota criada em um indivíduo
                this.individuos.Add(rota);
            }
        }
        public void clearAleatorioUsado()
        {
            this.aleatorioUsado.Clear();
        }
        public int getCidadeAleatoria(int quantidade)
        {
            int cidade;
            do
            {
                cidade = numAleatorio.Next(2, quantidade+1);
            } while (ValorUsado(cidade));
            aleatorioUsado.Add(cidade);
            return cidade;
        }
        public Boolean ValorUsado(int valor){
            Boolean retorno = false;

            if (aleatorioUsado.Contains(valor))
            {
                retorno = true;
            }
            return retorno;
        }
        public int calcTamanhoTrajeto(int[] rota, int[,] cidades)
        {
            int tamanho = 0;
            int cidadePosterior,cidadeAnterior, cidadeAtual;
            for (int i = 0; i < rota.Length-1; i++)
            {
                cidadeAtual = rota[i] - 1;
                if ( (i + 1) == rota.Length-1)
                {
                    tamanho += cidades[0, cidadeAtual];
                }
                else
                {
                    cidadePosterior = rota[i + 1] - 1;

                    if (cidades[cidadeAtual, cidadePosterior] == 0)
                    {
                        tamanho += cidades[cidadePosterior, cidadeAtual];
                    }
                    else
                    {
                        tamanho += cidades[cidadeAtual, cidadePosterior];
                    }
                } 
            }
            return tamanho;
        }
        public List<int[]> getIndividuos()
        {
            return this.individuos;
        }
    }
}
