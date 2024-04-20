using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05_Eventos.src.Model {
  public class TabletGarcom {
    public string NomeGarcom { get; set; }
    public void MostraMensagemPedidoProntoNaCozinha(object fonte, EventArgsPedidoPronto e) {
      Console.WriteLine($"O pedido {e.NumeroPedido} está pronto na cozinha, {NomeGarcom}.");
    }

    public TabletGarcom(string pNome, Cozinha pCozinha) {
      NomeGarcom = pNome;
      pCozinha.MensagemPedidoProntoEvent += MostraMensagemPedidoProntoNaCozinha;
    }
  }
}