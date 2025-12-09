using System;
using System.Collections.Generic;
using System.Linq;

public class Processo
{
    public string Nome;
    public int Prioridade;

    public Processo(string nome, int prioridade)
    {
        Nome = nome;
        Prioridade = prioridade;
    }
}

public class CPU
{
    private List<Processo> filaProcessos = new List<Processo>();

    public void AdicionarProcesso(string nome, int prioridade)
    {
        Processo novo = new Processo(nome, prioridade);
        filaProcessos.Add(novo);
        filaProcessos = filaProcessos.OrderByDescending(p => p.Prioridade).ToList();
        Console.WriteLine($"Agendado: {nome} (Prioridade {prioridade})");
    }

    public void ExecutarCiclo()
    {
        Console.WriteLine("\n--- Processando ---");

        while (filaProcessos.Count > 0)
        {
            Processo atual = filaProcessos[0];
            Console.WriteLine($"CPU Executando: {atual.Nome} [Prio: {atual.Prioridade}]");
            filaProcessos.RemoveAt(0);
        }

        Console.WriteLine("Todos os processos finalizados.");
    }
}

class Program
{
    static void Main()
    {
        CPU cpu = new CPU();

        cpu.AdicionarProcesso("Bloco de Notas", 1);
        cpu.AdicionarProcesso("Atualização Windows", 10);
        cpu.AdicionarProcesso("Google Chrome", 5);
        cpu.AdicionarProcesso("Antivírus", 9);

        cpu.ExecutarCiclo();
    }
}
