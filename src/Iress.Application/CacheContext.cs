using Iress.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iress.Application
{
    // Ideally, I would want an object more representative of an event store
    // but to avoid writing too much code this will do
    public sealed class CacheContext
    {
        private CacheContext()
        {
            Table = new List<Table>();
            Robot = new List<Iress.Domain.Robot>();
        }

        public IList<Table> Table { get; set; }
        public IList<Iress.Domain.Robot> Robot { get; set; }

        private static readonly Lazy<CacheContext> lazy = new Lazy<CacheContext>(() => new CacheContext());
        public static CacheContext Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
