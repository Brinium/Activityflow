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
        Task<bool> FileExists<TEntity>(string folder) where TEntity : Entity;

        Task<bool> SaveToFile<TEntity>(string folder, string contents) where TEntity : Entity;

        Task<bool> SaveToFile(string folder, string className, string contents);

        Task<string> ReadFile<TEntity>(string folder) where TEntity : Entity;

        string JoinPaths(params string[] parts);
    }
}
