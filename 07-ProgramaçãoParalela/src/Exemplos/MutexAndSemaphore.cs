using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07_ProgramaçãoParalela.src.Exemplos;

public class MutexAndSemaphore {
    private Mutex mutex;
    private Semaphore semaphore;

    public void Run() {
        mutex = new Mutex();
        semaphore = new Semaphore(2, 2);

        Task t1 = Task.Run(() => MostraMensagem(1));
        Task t2 = Task.Run(() => MostraMensagem(2));
        Task t3 = Task.Run(() => MostraMensagem(3));
        Task t4 = Task.Run(() => MostraMensagem(4));

        //! tasks morrem se o programa principal terminar, por isso precisamos fazela esperar
        Task.WaitAll(t1, t2, t3, t4); //todas tem que termina para dar sequencia
        //Task.WaitAny(t1, t2, t3, t4); //basta uma terminar que a espera finaliza

        //! threads não morrem se o programa principal acabar
        // new Thread(() => MostraMensagem(1)).Start();
        // new Thread(() => MostraMensagem(2)).Start();
        // new Thread(() => MostraMensagem(3)).Start();
        // new Thread(() => MostraMensagem(4)).Start();
    }

    private void MostraMensagem(int numeroTask) {

        semaphore.WaitOne();
        //mutex.WaitOne();
        for (int i = 0; i < 3; i++) {
            Console.WriteLine($"Numero da Task: {numeroTask}. Numero contador: {i}.");
            Thread.Sleep(500);
        }

        //mutex.ReleaseMutex();
        semaphore.Release();
    }
}
