using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07_ProgramaçãoParalela.src.Exemplos;

public static class MyMultiThreads {
    private const int MILISECONDS = 1000;
    private static Thread t1;
    private static Thread t2;
    private static bool podeFinalizar;
    private static int numeroDaThread;
    private static object lockObj;
    private static Mutex meuMutex; //! outra forma de usar lock, as duas não podem ser usadas ao mesmo tempo

    public static void Run() {
        lockObj = new object();
        meuMutex = new Mutex();

        podeFinalizar = false;
        t1 = new Thread(new ThreadStart(MinhaThread1)) {
            Priority = ThreadPriority.AboveNormal //controla prioridade
        };

        t2 = new Thread(() => MinhaThread2()); //! segunda forma de chamar

        t1.Start();
        t2.Start();

        //t1.Join(); //!impede que o programa continue pra baixo sem que as threads tenham sido finalizadas
        //t2.Join(); //!como nesse exemplo a finalização delas ocorre num comando abaixo, não pode ser usado join

        Console.ReadKey();
        podeFinalizar = true;

        Console.WriteLine("Finalizado.");
    }

    private static void MinhaThread1() {
        while (!podeFinalizar) {
            //! bloqueio com lock
            // lock (lockObj) {
            //     numeroDaThread = 1;
            //     Thread.Sleep(MILISECONDS);
            //     Console.WriteLine($"Thread1: Passou um segundo. - {numeroDaThread}"); //cuidar ao usar variaveis globais em multithread
            // }
            //! bloqueio com mutex
            meuMutex.WaitOne();
            numeroDaThread = 1;
            Thread.Sleep(MILISECONDS);
            Console.WriteLine($"Thread1: Passou um segundo. - {numeroDaThread}"); //cuidar ao usar variaveis globais em multithread
            meuMutex.ReleaseMutex();

        }
        Console.WriteLine("Thread 1, finalizando.");
    }

    private static void MinhaThread2() {
        while (!podeFinalizar) {
            //! bloqueio com lock
            // lock (lockObj) {
            //     numeroDaThread = 2;
            //     Thread.Sleep(MILISECONDS);
            //     Console.WriteLine($"Thread2: Passou um segundo. - {numeroDaThread}"); //cuidar ao usar variaveis globais em multithread
            // }
            //! bloqueio com mutex
            meuMutex.WaitOne();
            numeroDaThread = 2;
            Thread.Sleep(MILISECONDS);
            Console.WriteLine($"Thread2: Passou um segundo. - {numeroDaThread}"); //cuidar ao usar variaveis globais em multithread
            meuMutex.ReleaseMutex();
        }
        Console.WriteLine("Thread 2, finalizando.");
    }
}

/*  obj do lock
? -> Inicialização: No código que você forneceu, lockObj é inicializado como um novo objeto do tipo object na declaração do campo.
* -> Uso dentro das threads: Dentro dos métodos MinhaThread1 e MinhaThread2, você usa o lock para adquirir um bloqueio no objeto lockObj. 
* Isso significa que, quando uma thread adquire o bloqueio, nenhuma outra thread pode entrar em seção de código protegida pelo lock com o mesmo objeto, 
* até que o bloqueio daquele objeto seja liberado.
! -> Proteção de variáveis globais: Dentro das seções críticas protegidas pelo lock, você está acessando e modificando a variável numeroDaThread. Usar o lock garante que apenas uma thread por vez possa acessar e modificar essa variável, evitando condições de corrida e garantindo consistência nos dados compartilhados.
*/