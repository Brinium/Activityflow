using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatefullWorkflow.Entities;
using StatefullWorkflow.DataAccess.Test;
using System.IO;

namespace StatefullWorkflow.DataAccess.Tests
{
    [TestClass()]
    public class JsonContextTests
    {
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void SaveDataSet_Test()
        {
            var connectionString = Path.Combine(this.TestContext.DeploymentDirectory, "TestData");
            var context = new JsonContext(connectionString);
            var entities = new Dictionary<int, TestEntity>
            {
                { 1, new TestEntity{ Id =1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false }},
                { 2, new TestEntity{ Id =2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true }},
                { 3, new TestEntity{ Id =3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false }},
                { 4, new TestEntity{ Id =4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true }}
            };

            context.SaveDataSet<TestEntity>(entities);

            var file = new FileInfo(Path.Combine(connectionString, "TestEntities.json"));
            
            Assert.IsTrue(file.Exists);
        }

        [TestMethod()]
        [DeploymentItem(@"TestData\States.json", "TestData")]
        public void GetDataSet_Test()
        {
            var connectionString = Path.Combine(this.TestContext.DeploymentDirectory, "TestData");
            var context = new JsonContext(connectionString);
            var entities = context.GetDataSet<State>();
            Assert.IsTrue(entities.Count == 7);
            Assert.IsTrue(entities[1].Id == 1);
            Assert.IsTrue(entities[2].Id == 2);
            Assert.IsTrue(entities[3].Id == 3);
            Assert.IsTrue(entities[4].Id == 4);
            Assert.IsTrue(entities[5].Id == 5);
            Assert.IsTrue(entities[6].Id == 6);
            Assert.IsTrue(entities[7].Id == 7);
        }
    }
}
