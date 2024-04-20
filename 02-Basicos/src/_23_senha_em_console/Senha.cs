using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Basicos.src._23_senha_em_console;

public static class Senha {
  public static void Run() {
    string senha = "";

    Console.WriteLine("Informe sua senha:");
    while (true) {
      ConsoleKeyInfo tecla = Console.ReadKey(true);
      if (tecla.Key == ConsoleKey.Enter) {
        break;
      } else {
        senha += tecla.KeyChar;
      }
    }

    if (senha == "1234") {
      Console.WriteLine("Senha valida");
    } else {
      Console.WriteLine("Senha invalida");
    }

    //Console.WriteLine(senha);
  }
}
