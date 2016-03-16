using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess.IO
{
    public class FileAccessor : IFileAccessor
    {
        public PluralizationService Pluralizer { get; set; }

        public FileAccessor()
        {
            Pluralizer = PluralizationService.CreateService(CultureInfo.CurrentCulture);
        }

        public bool FileExists<TEntity>(string folder) where TEntity : Entity
        {
            if (String.IsNullOrEmpty(folder))
            {
                throw new ApplicationException("A folder must be provided");
            }
            var className = typeof(TEntity).Name;
            var fileInfo = new FileInfo(GetFileFullName(folder, className));
            return fileInfo.Exists;
        }

        public string ReadFile<TEntity>(string folder) where TEntity : Entity
        {
            var contents = string.Empty;
            if (String.IsNullOrEmpty(folder))
            {
                throw new ApplicationException("A folder must be provided");
            }

            var className = typeof(TEntity).Name;
            var fileInfo = new FileInfo(GetFileFullName(folder, className));
            if (fileInfo.Exists == false)
            {
                throw new ApplicationException("File not found");
            }

            try
            {
                using (StreamReader sr = fileInfo.OpenText())
                {
                    contents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                //NLog.LogManager.GetLogger("Standard").Error(ex, ex.Message);
                throw;
            }
            return contents;
        }

        public bool SaveToFile<TEntity>(string folder, string contents) where TEntity : Entity
        {
            try
            {
                var directory = new DirectoryInfo(folder);
                if (!directory.Exists)
                    directory.Create();
                var className = typeof(TEntity).Name;
                using (TextWriter writer = new StreamWriter(GetFileFullName(folder, className), false))
                {
                    writer.Write(contents);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                //NLog.LogManager.GetLogger("Standard").Error(ex, ex.Message);
                throw;
            }
            return true;
        }

        public string GetFileFullName(string folder, string className)
        {
            return Path.Combine(folder, Pluralizer.Pluralize(className) + ".json");
        }
    }
}
