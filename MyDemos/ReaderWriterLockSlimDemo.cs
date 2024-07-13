namespace MyDemos
{
    public class ReaderWriterLockSlimDemo
    {
        private static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private static int _sharedResource = 0;

        public static async Task Test()
        {
            var tasks = new List<Task>();

            // Okuyucu işlemleri oluştur
            for (int i = 0; i < 5; i++)
            {
                int readerId = i;
                tasks.Add(Task.Run(() => ReadSharedResource(readerId)));
            }

            // Yazıcı işlemleri oluştur
            for (int i = 0; i < 2; i++)
            {
                int writerId = i;
                tasks.Add(Task.Run(() => WriteSharedResource(writerId)));
            }

            for (int a = 0; a < 10; a++)
            {
                int slimReader = a;
                tasks.Add(Task.Run(() => UpdateSharedResourceAsync(slimReader)));
            }


            await Task.WhenAll(tasks);

            Console.WriteLine($"Final value of shared resource: {_sharedResource}");
        }

        private static void ReadSharedResource(int readerId)
        {
            try
            {
                _lock.EnterReadLock();
                Console.WriteLine($"Reader {readerId} is reading the shared resource. Value: {_sharedResource}");
                Thread.Sleep(5000); // Simulate some read work
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        private static void WriteSharedResource(int writerId)
        {
            try
            {
                _lock.EnterWriteLock();
                Console.WriteLine($"Writer {writerId} is writing to the shared resource.");
                _sharedResource++;
                Thread.Sleep(5000); // Simulate some write work
                Console.WriteLine($"Writer {writerId} has updated the shared resource to: {_sharedResource}");
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

       

        private static async Task UpdateSharedResourceAsync(int threadId)
        {
            await _semaphore.WaitAsync();
            try
            {
                Console.WriteLine($"Thread {threadId} is entering critical section for SemaphoreSlim.");

                // Simulate some work
                int temp = _sharedResource;
                await Task.Delay(5000); // Simulate work delay
                _sharedResource = temp + 1;

                Console.WriteLine($"Thread {threadId} is leaving critical section. Shared resource value: {_sharedResource}");
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }

}
