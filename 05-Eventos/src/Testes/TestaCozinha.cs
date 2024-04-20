using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _05_Eventos.src.Model;

namespace _05_Eventos.src.Testes {
  public static class TestaCozinha {
    public static void Run() {
      //! cadastrando as cozinhas
      Cozinha cozinhaHamburger = new Cozinha();
      Cozinha cozinhaJaponesa = new Cozinha();

      //! cadastrando os garçons em suas cozinhas
      TabletGarcom tabletJoao = new TabletGarcom("João", cozinhaHamburger);
      TabletGarcom tabletPedro = new TabletGarcom("Pedro", cozinhaHamburger);
      TabletGarcom tabletMaria = new TabletGarcom("Maria", cozinhaHamburger);

      TabletGarcom tabletJoana = new TabletGarcom("Joana", cozinhaJaponesa);
      TabletGarcom tabletAline = new TabletGarcom("Aline", cozinhaJaponesa);
      TabletGarcom tabletMarcos = new TabletGarcom("Marcos", cozinhaJaponesa);

      //! garçom nas duas cozinhas
      TabletGarcom tabletAlexHamb = new TabletGarcom("Alex", cozinhaHamburger);
      TabletGarcom tabletAlexJap = new TabletGarcom("Alex", cozinhaJaponesa);


      cozinhaHamburger.EnviaMensagemPedidoPronto(1);

      //! simulando envio de pedido pronto em tempo real
      UInt32 cozinha;
      UInt32 pedidoPronto;
      do {
        Console.WriteLine("Informe a cozinha:");
        do {
          Console.WriteLine("1 - Hamburger.");
          Console.WriteLine("2 - Japonesa.");
          Console.WriteLine("0 - Para encerrar.");
          uint.TryParse(Console.ReadLine(), out cozinha);
        } while (cozinha < 0 || cozinha > 2);
        if (cozinha == 0) break;

        Console.Write("Informe o numero do pedido (ou 0 para voltar): ");
        uint.TryParse(Console.ReadLine(), out pedidoPronto);
        Console.WriteLine("");

        if (pedidoPronto != 0) {
          switch (cozinha) {
            case 1:
              cozinhaHamburger.EnviaMensagemPedidoPronto(pedidoPronto);
              break;
            case 2:
              cozinhaJaponesa.EnviaMensagemPedidoPronto(pedidoPronto);
              break;
            default:
              break;
          }
        }
      } while (true);
    }
  }
}