using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07_ProgramaçãoParalela.src.Exemplos;

public class MyTask {
    public void Run() {
        int resultadoTask;
        Task taskImprimeMensagem = Task.Run(() => resultadoTask = ImprimeMensagem(5));
        for (int i = 0; i < 10; i++) {
            Console.WriteLine("Eu sou a Main thread: " + i);
            Thread.Sleep(500);
        }
    }

    private int ImprimeMensagem(int valorInicialDoContador) {
        for (int i = valorInicialDoContador; i < 10; i++) {
            Console.WriteLine("Eu sou uma task: " + i);
            Thread.Sleep(500);
        }
        return 10;
    }
}
