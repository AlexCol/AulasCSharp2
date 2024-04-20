using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Basicos.src._30_pilha_fila;

public static class Pilha {
  public static void Run() {
    Stack<string> pilhaDeNomes = new Stack<string>();

    //! adicionando elementos
    pilhaDeNomes.Push("Nome1");
    pilhaDeNomes.Push("Nome2");
    pilhaDeNomes.Push("Nome3");
    pilhaDeNomes.Push("Nome4");
    pilhaDeNomes.Push("Nome5");


    //! removendo elementos
    string nomeRemovido;
    nomeRemovido = pilhaDeNomes.Pop();
    Console.WriteLine($"Nome removido: {nomeRemovido}.");
    Console.WriteLine($"Ainda sobraram {pilhaDeNomes.Count} nome na pilha.");

    nomeRemovido = pilhaDeNomes.Pop();
    Console.WriteLine($"Nome removido: {nomeRemovido}.");
    Console.WriteLine($"Ainda sobraram {pilhaDeNomes.Count} nome na pilha.");


    //! espiando
    var nomeEspiado = pilhaDeNomes.Peek();
    Console.WriteLine($"Nome espiado: {nomeEspiado}.");
    Console.WriteLine($"Ainda sobraram {pilhaDeNomes.Count} nome na pilha.");

    //! removendo com trypop pra evitar excessões
    while (pilhaDeNomes.TryPop(out nomeRemovido)) {
      Console.WriteLine($"Nome removido: {nomeRemovido}.");
      Console.WriteLine($"Ainda sobraram {pilhaDeNomes.Count} nome na pilha.");
    }
    Console.WriteLine("Acabaram os nomes da pilha.");
  }
}
