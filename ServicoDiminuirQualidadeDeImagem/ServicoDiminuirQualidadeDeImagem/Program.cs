using System;

namespace ServicoDiminuirQualidadeDeImagem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o caminho do arquivo origem: ");
            var pathOrigin = Console.ReadLine();

            Console.WriteLine("Digite o novo caminho do arquivo: ");
            var newPath = Console.ReadLine();

            Console.WriteLine("Digite o percentual para diminuir a imagem: ");
            var percentage = int.Parse(Console.ReadLine());

            var s = new Service(pathOrigin, newPath, percentage);
            try
            {
                s.Run();
                Console.WriteLine("Imagem reduzida com sucesso !");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write("Houve um problema: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
