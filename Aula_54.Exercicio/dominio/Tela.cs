using System;


namespace Aula_54.Exercicio.dominio {
    class Tela {

        
        public static void MostrarMenu() {
            Console.WriteLine("1 - Listar Marcas");
            Console.WriteLine("2 - Listar carros de uma marca ordenadamente");
            Console.WriteLine("3 - Cadastrar Marca");
            Console.WriteLine("4 - Cadastrar Carro");
            Console.WriteLine("5 - Cadastrar Acessório");
            Console.WriteLine("6 - Mostrar detalhes de um carro");
            Console.WriteLine("7 - Sair");
            Console.WriteLine();
            Console.Write("Digite uma opção: ");
        }
            

        public static void ListarMarcas() {
            for (int i = 0; i < Program.marcas.Count; i++) {
                int cod = Program.marcas[i].codigo;
                int N = 0;
                for (int j = 0; j < Program.carros.Count; j++) {
                    int pos = Program.carros[j].marca.codigo;
                    if (pos == cod) {
                        N += 1;
                    }
                }
                Console.Write(Program.marcas[i] + ", Número de carros: " + N + "\n");       
            }
        }

        public static void ListarCarros() {
            Console.Write("Digite o código da marca: ");
            int cod = int.Parse(Console.ReadLine());
            int pos = Program.marcas.FindIndex(x => x.codigo == cod);

            if (pos == -1) {
                throw new ModelException("Código digitado não encontrado: " + cod);
            }

            string nome = Program.marcas[Program.marcas.FindIndex(x => x.codigo == cod)].nome;
            Console.WriteLine("Carros da marca " + nome + ":");
            for (int i = 0; i < Program.carros.Count; i++) {
                if (Program.carros[i].marca.codigo == cod) {
                    Console.WriteLine(Program.carros[i]);
                }
            }
            
        }

        public static void CadastrarMarca() {
            Console.WriteLine("Digite os dados da marca:");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("País de origem: ");
            string origem = Console.ReadLine();
            Marca m = new Marca(codigo, nome, origem);
            Program.marcas.Add(m);
        }

        public static void CadastroCarro() {
            Console.WriteLine("Digite os dados do carro:");
            Console.Write("Marca (código): ");
            int codMarca = int.Parse(Console.ReadLine());

            int posMarca = Program.marcas.FindIndex(x => x.codigo == codMarca);
            if (posMarca == -1) {
                throw new ModelException("Código de marca não encontrado: " + codMarca);
            }
            Console.Write("Código do carro: ");
            int codCarro = int.Parse(Console.ReadLine());
            Console.Write("Modelo: ");
            string md = Console.ReadLine();
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());
            Console.Write("Preço básico: ");
            double preco = double.Parse(Console.ReadLine());
            Carro carro = new Carro(codCarro, md, ano, preco, Program.marcas[posMarca]);
            Program.carros.Add(carro);
            Program.carros.Sort();
        }

        public static void CadastrarAcessorio() {
            Console.WriteLine("Digite os dados do acessório:");
            Console.Write("Carro (código): ");
            int codCarro = int.Parse(Console.ReadLine());

            int posCarro = Program.carros.FindIndex(x => x.codigo == codCarro);
            if (posCarro == -1) {
                throw new ModelException("Código de carro não encontrado: " + codCarro);
            }

            Console.Write("Descrição: ");
            string desc = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());
            Acessorio acessorio = new Acessorio(desc, preco, Program.carros[posCarro]);
            Program.acessorios.Add(acessorio);
        }

        public static void DetalheCarro() {
            Console.Write("Digite o código do carro: ");
            int codCarro = int.Parse(Console.ReadLine());

            int posCarro = Program.carros.FindIndex(x => x.codigo == codCarro);
            if (posCarro == -1) {
                throw new ModelException("Código de carro não encontrado: " + codCarro);
            }

            Console.WriteLine(Program.carros[posCarro]);
            Console.WriteLine("Acessórios:");
            for (int i = 0; i < Program.acessorios.Count; i++) {
                int posAcessorio = Program.acessorios[i].carro.codigo;
                if (posAcessorio == codCarro) {
                    Console.WriteLine(Program.acessorios[i]);
                }  
            }

        }
    }
}
