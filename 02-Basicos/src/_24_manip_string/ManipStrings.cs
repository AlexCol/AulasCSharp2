using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Basicos.src._24_manip_string;

public static class ManipStrings {
  public static void Run() {
    //! index
    var name = "Alexandre";
    Console.WriteLine(name[0]);

    //! concat string
    var sobreNome = "Coletti";
    Console.WriteLine(name + " " + sobreNome);
    Console.WriteLine(string.Concat(name, " ", sobreNome));

    //! subst
    var flor = "Rosa Branca";
    var novaFlor = flor.Replace("Branca", "Vermelha");
    Console.WriteLine($"{novaFlor} defere de {flor}");

    //! remove
    var padrao = flor.Remove(4); //usa como 'substring' --podendo ter um inicio e um fim, ou só o inicio se deseja remover dali pra frente
    Console.WriteLine(padrao);

    //! contain
    var nomeCompleto = "Alexandre Coletti";
    if (nomeCompleto.Contains("Coletti")) {
      Console.WriteLine("Tem o sobrenome");
    } else {
      Console.WriteLine("Não tem o sobrenome");
    }

    //! find text
    var inicialPosition = nomeCompleto.IndexOf("Coletti");
    Console.WriteLine($"O sobrenome inicia em: {inicialPosition}");
    inicialPosition = nomeCompleto.IndexOf("Silva");
    Console.WriteLine($"Quando não encontra o retorno é: {inicialPosition}");

    //! divide string
    var stringDeNumeros = "1,2,3,4,5,6,7";
    var dividido = stringDeNumeros.Split(",");
    foreach (var item in dividido) {
      Console.WriteLine(item);
    }

    //! formatação composta
    var stringComParametros = "Alex {0} {1}";
    var ehFeliz = true;
    if (ehFeliz) {
      Console.WriteLine(stringComParametros, "é muito", "feliz");
    } else {
      Console.WriteLine(stringComParametros, "não é muito", "feliz");
    }

    var novaStringFormatada = string.Format(stringComParametros, "adora", "programar.");
    Console.WriteLine(novaStringFormatada);
  }
}
