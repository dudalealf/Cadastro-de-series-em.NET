using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();
            while(opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        listarSeries();
                        break;
                    case "2":
                        inserirSerie();
                        break;
                    case "3":
                        atualizarSerie();
                        break;
                    case "4":
                        excluirSerie();
                        break;
                    case "5":
                        visualizarSerie();
                        break;
                    case "C":
                    Console.Clear();
                        break;
                    default:
                        throw new ArgumentException();
                }
                opcaoUsuario = obterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
        }

        private static void visualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());  

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);   
        }


        private static void excluirSerie()
        {
            Console.Write("Digite o id da série que deseja excluir: ");
            int indiceExcluir = int.Parse(Console.ReadLine());
            Console.WriteLine("Tem certeza que deseja excluir a série de id '{0}'?", indiceExcluir);
            Console.WriteLine("1- Sim | 2- Não");
            int opcao = int.Parse(Console.ReadLine());
            if(opcao == 1){
                repositorio.Exclui(indiceExcluir);
            } else return;
        }

        private static void atualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de ínicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.atualiza(indiceSerie, atualizaSerie);
        }

        private static void inserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de ínicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            
            Serie novaSerie = new Serie(id: repositorio.proximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.insere(novaSerie);
        }

        private static void listarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }
            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), serie.retornaExcluido() ? "Série excluída" : "Série ativa");
            }
        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("     DIO Séries");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série"); 
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;               
        }
    }
}
