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
            var testOneEntities = new Dictionary<string, TestEntityOne>
            {
                { "3c0b80ed-6542-42c0-a3df-eef2d784011f", new TestEntityOne{ Id = "3c0b80ed-6542-42c0-a3df-eef2d784011f", FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { "caab946b-a155-4297-a8a6-aaaa5aedf76d", new TestEntityOne{ Id = "caab946b-a155-4297-a8a6-aaaa5aedf76d", FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { "3e627ea2-27e6-48a3-9846-3f27008edd6b", new TestEntityOne{ Id = "3e627ea2-27e6-48a3-9846-3f27008edd6b", FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { "77a906b7-46ca-4e9a-b94b-5cf816f4d984", new TestEntityOne{ Id = "77a906b7-46ca-4e9a-b94b-5cf816f4d984", FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
            };
            context.DataSets.Add("TestEntityOne", testOneEntities);

            var testTwoEntities = new Dictionary<string, TestEntityTwo>
            {
                { "3c0b80ed-6542-42c0-a3df-eef2d784011f", new TestEntityTwo{ Id = "3c0b80ed-6542-42c0-a3df-eef2d784011f", FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { "caab946b-a155-4297-a8a6-aaaa5aedf76d", new TestEntityTwo{ Id = "caab946b-a155-4297-a8a6-aaaa5aedf76d", FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { "3e627ea2-27e6-48a3-9846-3f27008edd6b", new TestEntityTwo{ Id = "3e627ea2-27e6-48a3-9846-3f27008edd6b", FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { "77a906b7-46ca-4e9a-b94b-5cf816f4d984", new TestEntityTwo{ Id = "77a906b7-46ca-4e9a-b94b-5cf816f4d984", FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
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
            var entities = new Dictionary<string, TestEntityOne>
            {
                { "3c0b80ed-6542-42c0-a3df-eef2d784011f", new TestEntityOne{ Id = "3c0b80ed-6542-42c0-a3df-eef2d784011f", FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { "caab946b-a155-4297-a8a6-aaaa5aedf76d", new TestEntityOne{ Id = "caab946b-a155-4297-a8a6-aaaa5aedf76d", FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { "3e627ea2-27e6-48a3-9846-3f27008edd6b", new TestEntityOne{ Id = "3e627ea2-27e6-48a3-9846-3f27008edd6b", FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { "77a906b7-46ca-4e9a-b94b-5cf816f4d984", new TestEntityOne{ Id = "77a906b7-46ca-4e9a-b94b-5cf816f4d984", FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
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
            var entities = context.GetDataSet<State>();

            Assert.IsTrue(entities.Count == 7);
            Assert.IsTrue(entities["c3a1f46c-6fcc-44ce-898c-a822f046f2c4"].Id == "c3a1f46c-6fcc-44ce-898c-a822f046f2c4");
            Assert.IsTrue(entities["f3be2ed6-cef7-4518-9ed5-36dde2faec37"].Id == "f3be2ed6-cef7-4518-9ed5-36dde2faec37");
            Assert.IsTrue(entities["a0d0dfb9-c7af-412f-8e1b-a669fca95589"].Id == "a0d0dfb9-c7af-412f-8e1b-a669fca95589");
            Assert.IsTrue(entities["8afde442-e3f6-40c5-96a1-4fad55f3db23"].Id == "8afde442-e3f6-40c5-96a1-4fad55f3db23");
            Assert.IsTrue(entities["fca4fcd3-e6dc-4a7c-aa71-513655702ec9"].Id == "fca4fcd3-e6dc-4a7c-aa71-513655702ec9");
            Assert.IsTrue(entities["a443be19-7e04-4aa8-a910-b9f4e45f68d2"].Id == "a443be19-7e04-4aa8-a910-b9f4e45f68d2");
            Assert.IsTrue(entities["f9140737-fa1c-4a0d-8db8-dee2b9d0268d"].Id == "f9140737-fa1c-4a0d-8db8-dee2b9d0268d");
        }

        [Test()]
        public void GetDataSet_Test()
        {
            TestHelper.SetupTestFile(TestContext.CurrentContext, "States.json");

            string connectionString = TestHelper.GetTestDataOuputFolder(TestContext.CurrentContext);
            var context = new JsonContext(connectionString);
            var entities = context.GetDataSet<State>();

            Assert.IsTrue(entities.Count == 7);
            Assert.IsTrue(entities["c3a1f46c-6fcc-44ce-898c-a822f046f2c4"].Id == "c3a1f46c-6fcc-44ce-898c-a822f046f2c4");
            Assert.IsTrue(entities["f3be2ed6-cef7-4518-9ed5-36dde2faec37"].Id == "f3be2ed6-cef7-4518-9ed5-36dde2faec37");
            Assert.IsTrue(entities["a0d0dfb9-c7af-412f-8e1b-a669fca95589"].Id == "a0d0dfb9-c7af-412f-8e1b-a669fca95589");
            Assert.IsTrue(entities["8afde442-e3f6-40c5-96a1-4fad55f3db23"].Id == "8afde442-e3f6-40c5-96a1-4fad55f3db23");
            Assert.IsTrue(entities["fca4fcd3-e6dc-4a7c-aa71-513655702ec9"].Id == "fca4fcd3-e6dc-4a7c-aa71-513655702ec9");
            Assert.IsTrue(entities["a443be19-7e04-4aa8-a910-b9f4e45f68d2"].Id == "a443be19-7e04-4aa8-a910-b9f4e45f68d2");
            Assert.IsTrue(entities["f9140737-fa1c-4a0d-8db8-dee2b9d0268d"].Id == "f9140737-fa1c-4a0d-8db8-dee2b9d0268d");
        }

        [Test()]
        public void Set_Test()
       {
            TestHelper.SetupTestFile(TestContext.CurrentContext, "States.json");
            TestHelper.SetupTestFile(TestContext.CurrentContext, "StateActivities.json");

            string connectionString = TestHelper.GetTestDataOuputFolder(TestContext.CurrentContext);
            var context = new JsonContext(connectionString);
            var states = context.Set<State>();
            var activities = context.Set<StateActivity>();

            Assert.IsTrue(context.DataSets.Keys.Count == 2);
            Assert.IsTrue(context.DataSets.ContainsKey("State"));
            Assert.IsTrue(context.DataSets.ContainsKey("StateActivity"));
        }

        [Test()]
        public void Set_ChangePersists_Test()
        {
            TestHelper.SetupTestFile(TestContext.CurrentContext, "States.json");

            string connectionString = TestHelper.GetTestDataOuputFolder(TestContext.CurrentContext);
            var context = new JsonContext(connectionString);
            var states = context.Set<State>();

            var state = states["c3a1f46c-6fcc-44ce-898c-a822f046f2c4"];
            var displayName = "Changed Display Name";
            state.DisplayName = displayName;

            Assert.IsTrue(((IDictionary<string, State>)context.DataSets["State"])["c3a1f46c-6fcc-44ce-898c-a822f046f2c4"].DisplayName == displayName);
        }
    }
}
