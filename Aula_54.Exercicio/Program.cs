using System;
using System.Collections.Generic;
using Aula_54.Exercicio.dominio;

namespace Aula_54.Exercicio {
    class Program {

        public static List<Marca> marcas = new List<Marca>();
        public static List<Carro> carros = new List<Carro>();
        public static List<Acessorio> acessorios = new List<Acessorio>();

        static void Main(string[] args) {

            int opcao = 0;

            marcas.Add(new Marca(1001, "Volkswagen", "Alemanha"));
            marcas.Add(new Marca(1002, "General Motors", "Estados Unidos"));

            carros.Add(new Carro(101, "Fusca", 1980, 5000, marcas[marcas.FindIndex(x => x.codigo == 1001)]));
            carros.Add(new Carro(102, "Golf", 2016, 60000, marcas[marcas.FindIndex(x => x.codigo == 1001)]));
            carros.Add(new Carro(103, "Fox", 2017, 30000, marcas[marcas.FindIndex(x => x.codigo == 1001)]));
            carros.Add(new Carro(104, "Cruze", 2016, 30000, marcas[marcas.FindIndex(x => x.codigo == 1002)]));
            carros.Add(new Carro(105, "Cobalt", 2015, 25000, marcas[marcas.FindIndex(x => x.codigo == 1002)]));
            carros.Add(new Carro(106, "Cobalt", 2017, 35000, marcas[marcas.FindIndex(x => x.codigo == 1002)]));
            carros.Sort();

            while (opcao != 7) {
                Console.Clear();
                Tela.MostrarMenu();

                try {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch(Exception e) {
                    Console.WriteLine("Erro inesperado! " + e.Message);
                    opcao = 0;
                }

                switch (opcao) {
                    case 1:
                        Tela.ListarMarcas();
                        break;
                    case 2:
                        try {
                            Tela.ListarCarros();
                        }
                        catch (ModelException e) {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e) {
                            Console.WriteLine("Erro inesperado: " + e.Message);
                        }
                        
                        break;
                    case 3:
                        try {
                            Tela.CadastrarMarca();
                        }
                        catch (ModelException e) {
                            Console.WriteLine(e.Message);
                        }
                            
                        break;
                    case 4:
                        try {
                            Tela.CadastroCarro();
                        }
                        catch(ModelException e) {
                            Console.WriteLine(e.Message);
                        }
                        catch(Exception e) {
                            Console.WriteLine("Erro inesperado! " + e.Message);
                        }
                        break;
                    case 5:
                        try {
                            Tela.CadastrarAcessorio();
                        }
                        catch (ModelException e) {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e) {
                            Console.WriteLine("Erro inesperado! " + e.Message);
                        }
                        break;
                    case 6:
                        try {
                            Tela.DetalheCarro();
                        }
                        catch (ModelException e) {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 7:
                        Console.WriteLine("Fim do programa!");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                 
                }


                Console.ReadLine();
            }

        }
    }
}
