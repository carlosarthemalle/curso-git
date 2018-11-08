using System;
using System.Globalization;

namespace Aula_54.Exercicio.dominio {
    class Carro : IComparable {

        public int codigo { get; set; }
        public string modelo { get; set; }
        public int fabricacao { get; set; }
        public double precoBase { get; set; }
        public Marca marca { get; set; }
        
        public Carro(int codigo, string modelo, int fabricacao, double precoBase, Marca marca) {
            this.codigo = codigo;
            this.modelo = modelo;
            this.fabricacao = fabricacao;
            this.precoBase = precoBase;
            this.marca = marca;
            
        }

        public double precoTotal() {
            double v = 0;
            for (int i = 0; i < Program.acessorios.Count; i++) {
                int pos = Program.acessorios[i].carro.codigo;
                if (pos == codigo) {
                    v += Program.acessorios[i].preco;
                }
            }
            return precoBase + v;
        }

        public override string ToString() {
            return codigo
                 + ", "
                 + modelo
                 + ", Ano: "
                 + fabricacao
                 + ", Preço Básico: "
                 + precoBase.ToString("F2", CultureInfo.InvariantCulture)
                 + ", Preço Total: "
                 + precoTotal().ToString("F2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj) {
            Carro m = (Carro)obj;
            int resultado = modelo.CompareTo(m.modelo);
            if (resultado != 0) {
                return resultado;
            }
            else {
                return resultado;
            }
        }
    }
}
