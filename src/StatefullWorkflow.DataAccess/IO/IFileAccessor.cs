using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess.IO
{
    public interface IFileAccessor
    {
        Task<bool> FileExists<TEntity, Tid>(string folder) where TEntity : Entity<Tid> where Tid : struct;

        Task<bool> SaveToFile<TEntity, Tid>(string folder, string contents) where TEntity : Entity<Tid> where Tid : struct;

        Task<string> ReadFile<TEntity, Tid>(string folder) where TEntity : Entity<Tid> where Tid : struct;

        string JoinPaths(string partA, string partB);
    }
}
