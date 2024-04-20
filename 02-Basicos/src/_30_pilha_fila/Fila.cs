using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Basicos.src._30_pilha_fila;

public static class Fila {
  public static void Run() {
    Queue<string> FilaDeNomes = new Queue<string>();

    //! adicionando elementos
    FilaDeNomes.Enqueue("Nome1");
    FilaDeNomes.Enqueue("Nome2");
    FilaDeNomes.Enqueue("Nome3");
    FilaDeNomes.Enqueue("Nome4");
    Console.WriteLine($"Total de nomes na fila: {FilaDeNomes.Count}");

    //! removendo elementos
    string nomeRemovido;
    nomeRemovido = FilaDeNomes.Dequeue();
    Console.WriteLine($"Nome removido: {nomeRemovido}");
    Console.WriteLine($"Total de nomes na fila: {FilaDeNomes.Count}");

    nomeRemovido = FilaDeNomes.Dequeue();
    Console.WriteLine($"Nome removido: {nomeRemovido}");
    Console.WriteLine($"Total de nomes na fila: {FilaDeNomes.Count}");

    //! 'espiando' o primeiro elemento da Fila (consegue a obter, sem remover nada da fila)
    var nomeEspiado = FilaDeNomes.Peek();
    Console.WriteLine($"Nome espiado: {nomeEspiado}");
    Console.WriteLine($"Total de nomes na fila: {FilaDeNomes.Count}");

    //! usando try pra tentar remover (se usar Dequeue direto e não tiver itens na lista, dá excessão)
    while (FilaDeNomes.TryDequeue(out nomeRemovido)) {
      Console.WriteLine($"Nome removido: {nomeRemovido}");
      Console.WriteLine($"Total de nomes na fila: {FilaDeNomes.Count}");
    }
    Console.WriteLine("Acabaram os itens da Fila.");

  }
}
