using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PIM.DataContext
{
    public static class ContextFactory
    {
        /// <summary>
        /// Get a context
        /// </summary>
        /// <returns></returns>
        public static DbContext GetContext()
        {
            var dbContext = CallContext.GetData(typeof(ContextFactory).FullName) as DbContext;

            if (dbContext == null)
            {
                return CreateContext();
            }

            return dbContext;
        }

        /// <summary>
        /// Create a context and save it
        /// </summary>
        /// <returns></returns>
        private static DbContext CreateContext()
        {
            var dbContext = new PIMContext();
            CallContext.SetData(typeof(ContextFactory).FullName, dbContext);
            return dbContext;
        }
    }
}
