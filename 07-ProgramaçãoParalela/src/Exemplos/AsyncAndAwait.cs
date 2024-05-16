using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07_ProgramaçãoParalela.src.Exemplos;

public class AsyncAndAwait {
    public void Run() {
        //metodos syncronos
        // string sabor = CompraBolo("Juliana");
        // string cor = CompraBexiga("Pedro");

        //metodos assync
        FazFesta(); //como a main não é sync, precisa ser controlado pelo readkey pra esperar a execução
        Console.ReadKey();
    }

    private async void FazFesta() {
        var boloTask = CompraBoloAsync("Juliana");
        var bexigaTask = CompraBexigaAsync("Pedro");

        var bolo = await boloTask;
        var cor = await bexigaTask;

        Console.WriteLine($"O sabor do bolo é {bolo}");
        Console.WriteLine($"A cor da bexiga é {cor}");
    }

    //!------------
    private async Task<string> CompraBoloAsync(string nomeCliente) {
        Console.WriteLine($"{nomeCliente} foi ao mercado. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        await Task.Delay(2000);
        Console.WriteLine($"{nomeCliente} comprou o bolo. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        await Task.Delay(2000);
        Console.WriteLine($"{nomeCliente} voltou para casa. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        return "Chocolate";
    }

    private async Task<string> CompraBexigaAsync(string nomeCliente) {
        Console.WriteLine($"{nomeCliente} foi ao mercado. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        await Task.Delay(2000);
        Console.WriteLine($"{nomeCliente} comprou a besiga. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        await Task.Delay(2000);
        Console.WriteLine($"{nomeCliente} voltou para casa. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        return "Azul";
    }

    //!--------------------------
    private string CompraBolo(string nomeCliente) {
        Console.WriteLine($"{nomeCliente} foi ao mercado. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        Thread.Sleep(2000);
        Console.WriteLine($"{nomeCliente} comprou o bolo. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        Thread.Sleep(2000);
        Console.WriteLine($"{nomeCliente} voltou para casa. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        return "Chocolate";
    }

    private string CompraBexiga(string nomeCliente) {
        Console.WriteLine($"{nomeCliente} foi ao mercado. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        Thread.Sleep(2000);
        Console.WriteLine($"{nomeCliente} comprou a besiga. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        Thread.Sleep(2000);
        Console.WriteLine($"{nomeCliente} voltou para casa. A hora atual é: {DateTime.Now:hh:mm:ss}.");
        return "Azul";
    }
}
