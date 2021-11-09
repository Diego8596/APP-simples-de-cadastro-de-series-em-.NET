using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        public static SerieRepositorio Repositorio { get => repositorio; set => repositorio = value; }

        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario();

          while (opcaoUsuario.ToUpper() != "X")
          {
              switch(opcaoUsuario)
              {
                  case "1":
                  ListarSeries();
                  break;

                  case "2":
                  InserirSerie();
                  break;

                  case "3":
                  AtualizarSerie();
                  break;

                  case "4":
                  ExcluirSerie();
                  break;

                  case "5":
                  VisualizarSerie();
                  break;

                  case "C":
                  Console.Clear();
                  break;

                  default:
                throw new ArgumentOutOfRangeException();
              }

              opcaoUsuario = ObterOpcaoUsuario();
              
               }
               Console.WriteLine("Obrigado por Utilizar Nossos Serviços.");
               Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o Id da Série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            Repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o Id da Série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = Repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private  static  void  AtualizarSerie()
		{
			Console.Write("Digite o ID da série:");
			int  indiceSerie  =  int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof( Genero )))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof( Genero ), i));
			}
			Console.Write("Digite o gênero entre as opções acima:");
			int entradaGenero  =  int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série:");
			string entradaTitulo  =  Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série:");
			int entradaAno  =  int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série:");
			string entradaDescricao  =  Console.ReadLine();

			Serie atualizaSerie  =  new  Serie(id: indiceSerie,
										genero : (Genero)entradaGenero,
										titulo : entradaTitulo,
										ano : entradaAno,
										descricao : entradaDescricao);

			Repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = Repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? " * Excluído * ": ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }
            Console . Write ( " Digite o gênero entre as opções acima: " );
			int  entradaGenero  =  int . Parse ( Console . ReadLine ());

			Console . Write ( " Digite o Título da Série: " );
			string  entradaTitulo  =  Console . ReadLine ();

			Console . Write ( " Digite o Ano de Início da Série: " );
			int  entradaAno  =  int . Parse ( Console . ReadLine ());

			Console . Write ( " Digite a Descrição da Série: " );
			string  entradaDescricao  =  Console . ReadLine ();

			Serie  novaSerie  =  new  Serie ( id : Repositorio . ProximoId (),
										genero : ( Genero ) entradaGenero ,
										titulo : entradaTitulo ,
										ano : entradaAno ,
										descricao : entradaDescricao );
            Repositorio.Insere(novaSerie);

            }
        
    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Séries a seu Dispor!!!");
        Console.WriteLine("Informe a opção desejada");

        Console.WriteLine("1 - Listar Séries");
        Console.WriteLine("2 - Inserir Nova Série");
        Console.WriteLine("3 - Atualizar Série");
        Console.WriteLine("4 - Excluir Série");
        Console.WriteLine("5 - Visualizar Série");
        Console.WriteLine("C - Limpar Tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }        
                    
    }
}

