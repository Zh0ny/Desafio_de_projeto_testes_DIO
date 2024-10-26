using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class CalculadoraMetodos
    {
        private List<string> Historico;
        private string data;
        public CalculadoraMetodos(string data){
            Historico = new List<string>();
            this.data = data;
        }
        public double Somar(double num1, double num2)
        {
            Historico.Insert(0, $"{num1} + {num2} = {num1 + num2} - {data}");
            return num1 + num2;
        }
        public double Subtrair(double num1, double num2)
        {
            Historico.Insert(0, $"{num1} - {num2} = {num1 - num2} - {data}");
            return num1 - num2;
        }
        public double Multiplicar(double num1, double num2)
        {
            Historico.Insert(0, $"{num1} * {num2} = {num1 * num2} - {data}");
            return num1 * num2;
        }
        public double Dividir(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }
            Historico.Insert(0, $"{num1} / {num2} = {num1 / num2} - {data}");
            return num1/num2;
        }

        public List<string> ObterHistorico()
        {
            Historico.RemoveRange(3, Historico.Count - 3);
            return Historico;
        }
    }
}