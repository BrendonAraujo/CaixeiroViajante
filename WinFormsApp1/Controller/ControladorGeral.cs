using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Controller
{
    public class ControladorGeral
    {
        List<string> rotas = new List<string>();
        public ControladorGeral(string[] linhas)
        {
            foreach(string linha in linhas)
            {
                string[] Arraylinha = linha.Split(";");
                if(Arraylinha.Length > 0)
                {
                    if (Convert.ToInt32(Arraylinha[0]) > 20)
                    {
                        MessageBox.Show("Dados de entrada incorretos, não serão processados mais que 20 cidades", "Input Incorreto");
                        rotas.Add("Impossível identificar uma rota para os parâmetros passados");
                    }
                    else
                    {
                        Darwin darwin = new Darwin(linha);
                        rotas.Add(converteRotaParaString(darwin.getMelhorIndividuo()));
                    }
                }
            }
            Form2 form = new Form2();
            form.text = rotas;
            form.Show();
        }
        public string converteRotaParaString(int[] individuo)
        {
            string rota = "";
            for (int i = 0; i < individuo.Length;i++)
            {
                if (i == (individuo.Length - 1))
                {
                    rota += " || Total da Distancia = " + individuo[i].ToString();
                }
                else {
                    rota += (i+1).ToString()+ "º Cidade : " + individuo[i].ToString() + "; ";
                }
            }
            return rota;
        }
    }
}
