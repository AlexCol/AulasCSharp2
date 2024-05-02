

using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace _02_Basicos.src._36_manip_arquivos;

public static class ManipArquivo {
    private static string caminhoBaseDoProjeto = Directory.GetCurrentDirectory();
    private static string caminhoPasta = caminhoBaseDoProjeto + @"\temp\";
    private static string nomeArquivo = "arquivo.txt";
    private static string nomeArquivoEscrita = "arquivoEscrita.txt";

    public static void Run() {
        ConfirmaOuCriaPasta(caminhoPasta);
        CriaArquivo(caminhoPasta, nomeArquivo);
        DeletaArquivo(caminhoPasta + nomeArquivo);
        MovendoArquivo(caminhoPasta + "PdfExemplo.pdf", @"C:\Alexandre\temp\");
        EscrevendoEmArquivoDeTexto();
        LendoDeArquivoTexto();
    }

    private static void ConfirmaOuCriaPasta(string caminho) {
        if (Directory.Exists(caminho)) return;
        Directory.CreateDirectory(caminho);
    }

    private static void CriaArquivo(string caminhoPasta, string nomeArquivo) {
        var caminhoCompleto = caminhoPasta + nomeArquivo;

        if (File.Exists(caminhoCompleto)) {
            Console.WriteLine("Arquivo já existe.");
        } else {
            FileStream file = File.Create(caminhoPasta + nomeArquivo);
            file.Close();
            Console.WriteLine("Arquivo Criado.");
        }
    }

    private static void DeletaArquivo(string caminhoCompleto) {
        if (!File.Exists(caminhoCompleto)) {
            Console.WriteLine("Arquivo não encontrado.");
        } else {
            File.Delete(caminhoCompleto);
            Console.WriteLine("Arquivo deletado.");
        }
    }

    private static void MovendoArquivo(string origem, string pastaDestino) {
        ConfirmaOuCriaPasta(pastaDestino);
        var nomeArquivo = origem.Substring(origem.LastIndexOf(@"\") + 1);
        Console.WriteLine(nomeArquivo);
        var destino = pastaDestino + nomeArquivo;

        if (File.Exists(destino))
            File.Delete(destino);

        //File.Move(origem, destino); //!apaga o arquivo na origem
        File.Copy(origem, destino);
    }

    private static void EscrevendoEmArquivoDeTexto() {
        CriaArquivo(caminhoPasta, nomeArquivoEscrita);
        var builder = new StringBuilder();
        builder.AppendLine("Programação é divertida.");
        builder.AppendLine("Quem gosta de programar é doido.");

        //! escreve sobreescrevendo tudo que tiver no arquivo
        //File.WriteAllText(caminhoPasta + nomeArquivoEscrita, builder.ToString());

        var realizaAppend = true; //! se falso, o arquivo todo é sobrescrito com as novas informações
        using (StreamWriter writer = new StreamWriter(caminhoPasta + nomeArquivoEscrita, realizaAppend)) {
            writer.Write(builder.ToString()); //!apaga o arquivo e escreve desde o inicio
        };
    }
    private static void LendoDeArquivoTexto() {
        using (StreamReader reader = new StreamReader(caminhoPasta + nomeArquivoEscrita)) {
            while (!reader.EndOfStream) {
                Console.WriteLine(reader.ReadLine());
            }
        }
    }
}
