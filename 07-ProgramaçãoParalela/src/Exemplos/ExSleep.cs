using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07_ProgramaçãoParalela.src.Exemplos;

public class ExSleep {
    const int MILISECONDS = 2000;

    public void Run() {
        for (int i = 0; i < 5; i++) {
            Thread.Sleep(MILISECONDS); //! sleep faz a thread parar por x milisegundos
            Console.WriteLine($"Passou {MILISECONDS / 1000.0} segundo(s).");
        }
    }
}
