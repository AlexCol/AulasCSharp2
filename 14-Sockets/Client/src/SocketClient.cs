using System.Net.Sockets;
using System.Text;

namespace Client.src;

public static class SocketClient {
    public static void Run(int _porta) {
        //!Criando o client TCP
        TcpClient tcpClient = new TcpClient("localhost", _porta);
        NetworkStream networkStream = tcpClient.GetStream();

        //!Enviando dados para o servidor
        byte[] bufferEnviaProServidor = Encoding.ASCII.GetBytes("Olá do cliente!");
        networkStream.Write(bufferEnviaProServidor, 0, bufferEnviaProServidor.Length);

        //! Recebendo dados do servidor
        byte[] bufferRecebeDoServidor = new byte[1024];
        int byteLidos = networkStream.Read(bufferRecebeDoServidor, 0, bufferRecebeDoServidor.Length);
        Console.WriteLine("Dados do servidor: " + Encoding.ASCII.GetString(bufferRecebeDoServidor, 0, byteLidos));

        //! finaliza conexão
        tcpClient.Close();
        networkStream.Close();
    }
}
