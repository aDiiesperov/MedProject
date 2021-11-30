using System;
using System.Collections.Concurrent;
using System.Timers;

namespace MedProject.Services.Services
{
    internal class AuthCacheManager : IDisposable
    {
        private readonly ConcurrentDictionary<string, DateTime> usedTokens = new ConcurrentDictionary<string, DateTime>();

        private Timer timer;

        private bool disposedValue;


        public AuthCacheManager()
        {
            this.InitTimer();

        }

        private void InitTimer()
        {
            var time = TimeSpan.FromHours(1).TotalMilliseconds;
            this.timer = new Timer(time);
            this.timer.Elapsed += this.RemoveExpiredTokens;
            this.timer.Start();
        }

        private void RemoveExpiredTokens(object sender, ElapsedEventArgs e)
        {
            var now = DateTime.UtcNow;
            foreach (var usedToken in this.usedTokens)
            {
                if (usedToken.Value <= now)
                {
                    this.usedTokens.TryRemove(usedToken.Key, out _);
                }
            }
        }

        public bool Contains(string token)
        {
            return usedTokens.ContainsKey(token);
        }

        public bool TryAdd(string token, DateTime validTo)
        {
            return usedTokens.TryAdd(token, validTo);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                this.timer.Dispose();
                disposedValue = true;
            }
        }

        ~AuthCacheManager()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
