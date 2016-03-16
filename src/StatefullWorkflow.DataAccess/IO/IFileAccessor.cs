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
        bool FileExists<TEntity>(string folder) where TEntity : Entity;
        bool SaveToFile<TEntity>(string folder, string contents) where TEntity : Entity;
        string ReadFile<TEntity>(string folder) where TEntity : Entity;
    }
}
