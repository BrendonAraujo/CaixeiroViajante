using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Controller
{
    public class Darwin
    {
        public int[,] cidadesDistancias;
        List<int[]> ListaIndividuosSelecionados = new List<int[]>();
        int[] melhorIndividuoGeracaoAnterior = new int[0];
        int[] melhorIndividuo = new int[0];
        int quantidadeRepeticoesIndividuo;
        int quantidadeGeracoes = 0;
        public Darwin(string linha)
        {
            //Transforma linha obtida em array
            string[] linhas = linha.Split(";");
            Boolean objetivoAlcancado = false;
            Geracao ger;
            
            do
            {// Se não existe resquicio da geração anterior então cria geração aleatória
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                if (this.melhorIndividuo.Length == 0 && this.ListaIndividuosSelecionados.Count == 0)
                {
                    ger = new Geracao(convertToMatrix(linhas));
                }//Se existe resquício então cria uma geração baseada nos indivíduos selecionados
                else
                {
                    ger = new Geracao(convertToMatrix(linhas), ListaIndividuosSelecionados, melhorIndividuo);
                }

                List<int[]> ListaIndividuos = ger.getIndividuos();
                this.ListaIndividuosSelecionados = selecaoNatural(ListaIndividuos);
                this.melhorIndividuo = getMelhorIndividuo(ListaIndividuos);
                quantidadeGeracoes++;
                objetivoAlcancado = validaObjetivo(stopwatch);
            } while (!objetivoAlcancado);
        }
        public Boolean validaObjetivo(Stopwatch timer)
        {
            Boolean retorno = false;
            Boolean individuoDuplicado = false;
            Boolean tempoEsgontado = false;
            
            #region "ValidaIndividuoDuplicado"
            if (this.melhorIndividuoGeracaoAnterior.Length == 0)
            {
                this.melhorIndividuoGeracaoAnterior = this.melhorIndividuo;
            }
            else if (this.melhorIndividuoGeracaoAnterior[melhorIndividuoGeracaoAnterior.Length - 1] == this.melhorIndividuo[melhorIndividuo.Length-1])
            {
                this.quantidadeRepeticoesIndividuo++;
            }
            else
            {
                this.quantidadeRepeticoesIndividuo = 0;
            }
            if (this.quantidadeRepeticoesIndividuo == 5)
            {
                individuoDuplicado = true;
            }
            #endregion

            #region "TempoEsgotado"
            if (timer.ElapsedMilliseconds >= 900000)
            {
                tempoEsgontado = true;
            }
            #endregion

            if ((tempoEsgontado) || (individuoDuplicado))
            {
                retorno = true;
            }
            return retorno;
        }
        public int[] getMelhorIndividuo()
        {
            return this.melhorIndividuo;
        }
        public List<int[]> selecaoNatural(List<int[]> individuos)
        {
            List<int[]> individuosSelecionados = new List<int[]>();

            List<int> roleta = lista_como_roleta(individuos);
            Random numAleatorio = new Random();
            int individuoSelecionado;
            int voltasRoleta = 1;
            int posicaoAgulha = 0;

            for (int i = 0; i < voltasRoleta; i++)
            {
                posicaoAgulha = numAleatorio.Next(0, roleta.Count);
                individuoSelecionado = roleta[posicaoAgulha]; 

                individuosSelecionados.Add(individuos[individuoSelecionado]);
                if (posicaoAgulha > (roleta.Count / 2))
                {
                    posicaoAgulha = posicaoAgulha - (roleta.Count / 2);
                }
                else
                {
                    posicaoAgulha = posicaoAgulha + (roleta.Count / 2);
                }
                if(posicaoAgulha > 0 && posicaoAgulha <= roleta.Count -1)
                {
                    individuoSelecionado = roleta[posicaoAgulha];
                }
                else
                {
                    posicaoAgulha = numAleatorio.Next(0, roleta.Count);
                    individuoSelecionado = roleta[posicaoAgulha];
                }
                individuosSelecionados.Add(individuos[individuoSelecionado]);
            }

            return individuosSelecionados; 
        }
        public int[] getMelhorIndividuo(List<int[]> individuos)
        {
            int[] melhorIndividuo = individuos[0];
            int melhorDistancia = melhorIndividuo[melhorIndividuo.Length - 1];

            foreach (int[] individuo in individuos)
            {
                if (individuo[ individuo.Length - 1 ] < melhorDistancia)
                {
                    melhorIndividuo = individuo;
                    melhorDistancia = individuo[individuo.Length - 1];
                }
            }

            return melhorIndividuo;
        }
        public int[,] convertToMatrix(string[] ArraycidadesDistancias)
        {
            int quantidadeCidades = Convert.ToInt32(ArraycidadesDistancias[0]);
            this.cidadesDistancias = new int[quantidadeCidades , quantidadeCidades];
            string StringNumber = "";
            int tamanhoString, count = 0;
            for (int i = 0; i < quantidadeCidades; i++)
            {
                for (int j = 0; j < quantidadeCidades; j++)
                {
                    {
                        if (j > i)
                        {
                            if (i == 0)
                            {
                                StringNumber = ArraycidadesDistancias[j];
                            }
                            else
                            {
                                StringNumber = ArraycidadesDistancias[(count+1)];
                            }
                            count++;
                            tamanhoString = StringNumber.Length;
                            StringNumber = StringNumber.Substring(1, tamanhoString - 1);
                            this.cidadesDistancias[i,j] = Convert.ToInt32(StringNumber);
                        }
                    }
                }
            }
            return this.cidadesDistancias;
        }
        public List<int> lista_como_roleta(List<int[]> individuosGeracao)
        {
            List<int> roleta = new List<int>();
            float[] ret = definirFitness(individuosGeracao);
            float prop;
            
            for (int i = 0; i < ret.Length; i++)
            {
                prop = ( (ret[i] * 100)/ret.Sum() );
                for(int j = 0;j < prop; j++)
                {
                    roleta.Add(i);
                }
            }
            
            return roleta;
        }
        public float[] definirFitness(List<int[]> individuosGeracao)
        {
            int[] DistanciaIndividuos = new int[individuosGeracao.Count];
            int distanciaTotal;
            float[] fitnessIndividuos = new float[individuosGeracao.Count];

            //Percorre os indivíduos da geração obtendo sua distancia percorrida
            int i = 0; 
            foreach (int[] individuo in individuosGeracao)
            {
                DistanciaIndividuos[i] = individuo[individuo.Length - 1];
                i++;
            }

            //Calcula a distancia total percorrida pela geração
            distanciaTotal = calculaDistanciaTotalGeracao(DistanciaIndividuos);

            //Calcula o fitness, ele é dado pela diferença entre a distancia individual e a distancia total da geração
            /*
            Calculo de fitness:
                100 - (( distancia percorrida pelo individuo * 100 ) / distancia total percorrida pela geração )
             */
            i = 0;
            foreach (int[] individuo in individuosGeracao)
            {
                fitnessIndividuos[i] = 100 - ( (individuo[individuo.Length - 1] * 100) / distanciaTotal );
                i++;
            }
            return fitnessIndividuos;
        }
        public int calculaDistanciaTotalGeracao(int[] listaDistancia)
        {
            int distancia = 0;
            for (int i = 0; i < listaDistancia.Length; i++)
            {
                distancia += listaDistancia[i];
            }

            return distancia;
        }
    }
}
