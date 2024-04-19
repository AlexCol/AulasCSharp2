using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05_Eventos.src.Model {
    public class Cozinha {
        public delegate void MensagemPedidoProntoEventHandler(object fonte, EventArgsPedidoPronto e);
        public event MensagemPedidoProntoEventHandler MensagemPedidoProntoEvent;

        public void EnviaMensagemPedidoPronto(UInt32 pNumeroPedido) {
            if (MensagemPedidoProntoEvent != null) {
                EventArgsPedidoPronto e = new EventArgsPedidoPronto(pNumeroPedido);
                MensagemPedidoProntoEvent(this, e);
            }
        }
    }
}