using System.Collections.Generic;
using NUnit.Framework;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;
using System.IO;
using StatefullWorkflow.DataAccess.Test;

namespace StatefullWorkflow.DataAccess.Tests
{
    [TestFixture()]
    public class JsonContextTests
    {
        [NUnit.Framework.SetUp]
        public void SetupTests()
        {
            TestHelper.SetupTestDataOutputFolder(TestContext.CurrentContext, true);
        }

        [Test()]
        public void SaveDataSet_All_Test()
        {
            string connectionString = TestHelper.GetTestDataOuputFolder(TestContext.CurrentContext);
            var context = new JsonContext(connectionString);
            var testOneEntities = new Dictionary<int, TestEntityOne>
            {
                { 1, new TestEntityOne{ Id = 1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { 2, new TestEntityOne{ Id = 2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { 3, new TestEntityOne{ Id = 3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { 4, new TestEntityOne{ Id = 4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
            };
            context.DataSets.Add("TestEntityOne", testOneEntities);

            var testTwoEntities = new Dictionary<int, TestEntityTwo>
            {
                { 1, new TestEntityTwo{ Id = 1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { 2, new TestEntityTwo{ Id = 2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { 3, new TestEntityTwo{ Id = 3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { 4, new TestEntityTwo{ Id = 4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
            };
            context.DataSets.Add("TestEntityTwo", testTwoEntities);
            
            context.SaveDataSets();

            var fileOne = new FileInfo(Path.Combine(connectionString, "TestEntityOnes.json"));
            var fileTwo = new FileInfo(Path.Combine(connectionString, "TestEntityTwos.json"));

            Assert.IsTrue(fileOne.Exists);
            Assert.IsTrue(fileTwo.Exists);
        }

        [Test()]
        public void SaveDataSet_Entity_Test()
        {
            string connectionString = TestHelper.GetTestDataOuputFolder(TestContext.CurrentContext);
            var context = new JsonContext(connectionString);
            var entities = new Dictionary<int, TestEntityOne>
            {
                { 1, new TestEntityOne{ Id = 1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { 2, new TestEntityOne{ Id = 2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { 3, new TestEntityOne{ Id = 3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { 4, new TestEntityOne{ Id = 4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
            };

            context.SaveDataSet(entities);

            var file = new FileInfo(Path.Combine(connectionString, "TestEntityOnes.json"));

            Assert.IsTrue(file.Exists);
        }

        [Test()]
        public void GetDataSet__AlreadyLoaded_Test()
        {
            TestHelper.SetupTestFile(TestContext.CurrentContext, "States.json");

            string connectionString = TestHelper.GetTestDataOuputFolder(TestContext.CurrentContext);
            var context = new JsonContext(connectionString);
            var entities = context.GetDataSet<State, int>();

            Assert.IsTrue(entities.Count == 7);
            Assert.IsTrue(entities[1].Id == 1);
            Assert.IsTrue(entities[2].Id == 2);
            Assert.IsTrue(entities[3].Id == 3);
            Assert.IsTrue(entities[4].Id == 4);
            Assert.IsTrue(entities[5].Id == 5);
            Assert.IsTrue(entities[6].Id == 6);
            Assert.IsTrue(entities[7].Id == 7);
        }

        [Test()]
        public void GetDataSet_Test()
        {
            TestHelper.SetupTestFile(TestContext.CurrentContext, "States.json");

            string connectionString = TestHelper.GetTestDataOuputFolder(TestContext.CurrentContext);
            var context = new JsonContext(connectionString);
            var entities = context.GetDataSet<State, int>();

            Assert.IsTrue(entities.Count == 7);
            Assert.IsTrue(entities[1].Id == 1);
            Assert.IsTrue(entities[2].Id == 2);
            Assert.IsTrue(entities[3].Id == 3);
            Assert.IsTrue(entities[4].Id == 4);
            Assert.IsTrue(entities[5].Id == 5);
            Assert.IsTrue(entities[6].Id == 6);
            Assert.IsTrue(entities[7].Id == 7);
        }

        [Test()]
        public void Set_Test()
       {
            TestHelper.SetupTestFile(TestContext.CurrentContext, "States.json");
            TestHelper.SetupTestFile(TestContext.CurrentContext, "Activities.json");

            string connectionString = TestHelper.GetTestDataOuputFolder(TestContext.CurrentContext);
            var context = new JsonContext(connectionString);
            var states = context.Set<State, int>();
            var activities = context.Set<Activity, int>();

            Assert.IsTrue(context.DataSets.Keys.Count == 2);
            Assert.IsTrue(context.DataSets.ContainsKey("State"));
            Assert.IsTrue(context.DataSets.ContainsKey("Activity"));
        }

        [Test()]
        public void Set_ChangePersists_Test()
        {
            TestHelper.SetupTestFile(TestContext.CurrentContext, "States.json");

            string connectionString = TestHelper.GetTestDataOuputFolder(TestContext.CurrentContext);
            var context = new JsonContext(connectionString);
            var states = context.Set<State, int>();

            var state = states[1];
            var displayName = "Changed Display Name";
            state.DisplayName = displayName;

            Assert.IsTrue(((IDictionary<int, State>)context.DataSets["State"])[1].DisplayName == displayName);
        }
    }
}
