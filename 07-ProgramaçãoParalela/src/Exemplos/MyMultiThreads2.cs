using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07_ProgramaçãoParalela.src.Exemplos;

public class MyMultiThreads2 {
    public void Run() {
        Thread t1 = new Thread(new ThreadStart(MinhaThreadSemParametro));
        //Thread t1 = new Thread(() => MinhaThreadSemParametro());
        t1.Start();

        Thread t2 = new Thread(() => MinhaThreadComParametro(5));
        t2.Start();

        var param = new ThreadParams() {
            Contador = 15,
            Nome = "TerceiraThread"
        };
        //Thread t3 = new Thread(() => MinhaThreadComParametro2(param));
        //t3.Start();
        Thread t3 = new Thread(new ParameterizedThreadStart(MinhaThreadComParametro2));
        t3.Start(param);
    }

    private void MinhaThreadSemParametro() {
        int contador = 10;
        do {
            Console.WriteLine(contador++);
            Thread.Sleep(250);
        } while (contador < 20);
    }

    private void MinhaThreadComParametro(int inicioContador) {
        int contador = inicioContador;
        do {
            Console.WriteLine(contador++);
            Thread.Sleep(250);
        } while (contador < 20);
    }

    private void MinhaThreadComParametro2(object pThreadParams) {
        var myParams = (ThreadParams)pThreadParams;
        int contador = myParams.Contador;
        do {
            Console.WriteLine($"{myParams.Nome} - {contador++}");
            Thread.Sleep(250);
        } while (contador < 20);
    }

    internal class ThreadParams {
        public int Contador { get; set; }
        public string Nome { get; set; }
    }
}
