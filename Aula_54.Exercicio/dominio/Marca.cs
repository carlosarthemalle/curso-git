using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aula_54.Exercicio.dominio {
    class Marca {

        public int codigo { get; set; }
        public string nome { get; set; }
        public string origem { get; set; }

       
        public Marca(int codigoMarca, string nome, string origem) {
            this.codigo = codigoMarca;
            this.nome = nome;
            this.origem = origem;
        }

        public override string ToString() {
            return codigo
                 + ", "
                 + nome
                 + ", País: "
                 + origem;
        }
    }
}
