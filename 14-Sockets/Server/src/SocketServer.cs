using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server.src;

public static class SocketServer {
    public static void Run(int _porta) {
        TcpListener listener = new TcpListener(IPAddress.Any, _porta);
        listener.Start();
        Console.WriteLine("Esperando conexão.");
        TcpClient client = listener.AcceptTcpClient();
        Console.WriteLine("Conexão estabelecida.");
        NetworkStream netStreamReader = client.GetStream();

        try {
            //! ler dados do cliente
            byte[] bufferRecebeDoCliente = new byte[1024];
            int bytesLidos = netStreamReader.Read(bufferRecebeDoCliente, 0, bufferRecebeDoCliente.Length);
            Console.WriteLine("Dados recebidos do cliente: " + Encoding.ASCII.GetString(bufferRecebeDoCliente, 0, bytesLidos));

            //!Enviando dados para o cliente
            byte[] bufferEnviaProCliente = Encoding.ASCII.GetBytes("Olá do servidor.");
            netStreamReader.Write(bufferEnviaProCliente, 0, bufferEnviaProCliente.Length);

            //!Encerrar a comunicação
            netStreamReader.Close();
            client.Close();
            listener.Stop();
        } catch (Exception e) {
            Console.WriteLine("Deu ero: " + e.Message);
        }
    }
}
