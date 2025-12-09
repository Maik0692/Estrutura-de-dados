using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o caminho de uma pasta (ex: C:\\Windows\\Web ou . para atual):");
        string caminhoInicial = Console.ReadLine();

        if (caminhoInicial == ".")
            caminhoInicial = Directory.GetCurrentDirectory();

        Console.WriteLine($"\nExplorando: {caminhoInicial}\n");

        try
        {
            ListarArquivos(caminhoInicial);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }

    static void ListarArquivos(string diretorio)
    {
        try
        {
            string[] arquivos = Directory.GetFiles(diretorio);
            foreach (string arquivo in arquivos)
            {
                Console.WriteLine(Path.GetFileName(arquivo));
            }

            string[] subpastas = Directory.GetDirectories(diretorio);
            foreach (string sub in subpastas)
            {
                Console.WriteLine("[" + Path.GetFileName(sub) + "]");
                ListarArquivos(sub);
            }
        }
        catch (UnauthorizedAccessException)
        {
        }
    }
}
