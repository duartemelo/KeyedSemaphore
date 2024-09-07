using System.Collections.Concurrent;

namespace KeyedSemaphoreImplementation.Semaphore
{
    public class KeyedSemaphore
    {
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> semaphoreList = new();

        public async Task<bool> WaitAsync(string key, int milliseconds)
        {
            var semaphore = semaphoreList.GetOrAdd(key, _ => new SemaphoreSlim(1, 1)); // if key exists, gets, if not, adds
            return await semaphore.WaitAsync(milliseconds);
        }

        public int Release(string key)
        {
            if (semaphoreList.TryGetValue(key, out var semaphore))
            {
                return semaphore.Release();
            }
            return 0;
        }
    }
}
