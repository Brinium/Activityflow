using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.DataAccess.Tests
{
    public static class TestHelper
    {
        public static void SetupTestDataOutputFolder(TestContext context, bool purgeExistingFiles)
        {
            var workingLocation = GetTestDataOuputFolder(context);
            if (!Directory.Exists(workingLocation))
                Directory.CreateDirectory(workingLocation);
            else
            {
                if (purgeExistingFiles)
                {
                    var files = Directory.GetFiles(workingLocation);
                    foreach (var file in files)
                    {
                        File.Delete(file);
                    }
                }
            }
        }

        public static string GetTestDataOuputFolder(TestContext context)
        {
            return Path.Combine(context.WorkDirectory, "TestDataOutput");
        }

        public static void SetupTestFile(TestContext context, string fileName)
        {
            var sourceLocation = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
            var workingLocation = Path.Combine(GetTestDataOuputFolder(context), fileName);
            SetupTestDataOutputFolder(context, false);
            if (File.Exists(workingLocation))
                File.Delete(workingLocation);
            File.Copy(sourceLocation, workingLocation);
        }
    }
}
