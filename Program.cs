using System.Runtime.InteropServices;
using System.Diagnostics;

Console.WriteLine($"Логических процессоров: {Environment.ProcessorCount}");
Console.WriteLine($"Архитектура процесса: {RuntimeInformation.ProcessArchitecture}");
Console.WriteLine($"64-битный процесс: {Environment.Is64BitProcess}");



Console.WriteLine($"Логических процессоров: {Environment.ProcessorCount}");
Console.WriteLine("Запуск вычислений…");

Stopwatch timer = Stopwatch.StartNew();
long result = 0;
while (timer.Elapsed.TotalSeconds < 5) {
    for (int i = 0; i < 1_000_000; i++) {
        result += i * i;
    }
}

Console.WriteLine($"Результат: {result}");
Console.WriteLine("Готово.");



int threadCount = Environment.ProcessorCount;

Console.WriteLine($"Логических процессоров: {threadCount}");
Console.WriteLine($"Потоков запущено: {threadCount}");
Console.WriteLine("Запуск вычислений...");

Thread[] threads = new Thread[threadCount];

for (int i = 0; i < threadCount; i++) {
    threads[i] = new Thread(() => {
        long result = 0;
        Stopwatch timer = Stopwatch.StartNew();

        while (timer.Elapsed.TotalSeconds < 5) {
            for (int j = 0; j < 1_000_000; j++) {
                result += j * j;
            }
        }
    });

    threads[i].Start();
}

foreach (Thread thread in threads) {
    thread.Join();
}

Console.WriteLine("Все потоки завершили работу.");



int threadCount1 = 8;

Console.WriteLine($"Логических процессоров: {threadCount1}");
Console.WriteLine($"Потоков запущено: {threadCount1}");
Console.WriteLine("Запуск вычислений...");

Thread[] threads1 = new Thread[threadCount1];

for (int i = 0; i < threadCount1; i++) {
    threads1[i] = new Thread(() => {
        long result1 = 0;
        Stopwatch timer1 = Stopwatch.StartNew();

        while (timer1.Elapsed.TotalSeconds < 5) {
            for (int j = 0; j < 1_000_000; j++) {
                result1 += j * j;
            }
        }
    });

    threads1[i].Start();
}

foreach (Thread thread1 in threads1) {
    thread1.Join();
}

Console.WriteLine("Все потоки завершили работу.");
