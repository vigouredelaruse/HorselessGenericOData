using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorselessGenericOData.EFCoreFeatures.Infrastructure
{
    public static class EntityRegistrationExtensions
    {
        /// <summary>
        /// generate dbset properties for the provided types
        /// filtered by the supplied interface
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <param name="modelBuilder"></param>
        /// <param name="types"></param>
        public static void RegisterTypes<TInterface>(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder, params Type[] types)
        {
            IEnumerable<Type> filteredTypes = types.Where(c => c.IsClass && !c.IsAbstract && c.IsPublic &&
            typeof(TInterface).IsAssignableFrom(c));

            foreach (Type type in filteredTypes)
            {
                try
                {
                    modelBuilder.Entity(type);
                }
                catch (Exception e)
                {
                    // fail silent
                }
            }
        }

    }
}
