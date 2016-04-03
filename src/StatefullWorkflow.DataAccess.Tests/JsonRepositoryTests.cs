using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using Moq;
using StatefullWorkflow.DataAccess.Test;
using NUnit.Framework;

namespace StatefullWorkflow.DataAccess.Tests
{
    [TestFixture()]
    public class JsonRepositoryTests
    {
        private static int GenerateId(IDictionary<int, TestEntityOne> entities)
        {
            int id = 1;
            while (entities.ContainsKey(id))
            {
                id++;
            }
            return id;
        }

        [Test()]
        public void Get_Test()
        {
            var entities = new Dictionary<string, TestEntityOne>
            {
                { "3c0b80ed-6542-42c0-a3df-eef2d784011f", new TestEntityOne{ Id = "3c0b80ed-6542-42c0-a3df-eef2d784011f", FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { "caab946b-a155-4297-a8a6-aaaa5aedf76d", new TestEntityOne{ Id = "caab946b-a155-4297-a8a6-aaaa5aedf76d", FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { "3e627ea2-27e6-48a3-9846-3f27008edd6b", new TestEntityOne{ Id = "3e627ea2-27e6-48a3-9846-3f27008edd6b", FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { "77a906b7-46ca-4e9a-b94b-5cf816f4d984", new TestEntityOne{ Id = "77a906b7-46ca-4e9a-b94b-5cf816f4d984", FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Set<TestEntityOne>()).Returns(entities);

            var repo = new JsonRepository<TestEntityOne>(uowMock.Object);

            var testGet = repo.Get("3e627ea2-27e6-48a3-9846-3f27008edd6b");
            Assert.IsNotNull(testGet);
            Assert.IsTrue(testGet.Id == "3e627ea2-27e6-48a3-9846-3f27008edd6b");

            var testGet_IsNull = repo.Get("not an id");
            Assert.IsNull(testGet_IsNull);
        }

        [Test()]
        public void All_Test()
        {
            var entities = new Dictionary<string, TestEntityOne>
            {
                { "3c0b80ed-6542-42c0-a3df-eef2d784011f", new TestEntityOne{ Id = "3c0b80ed-6542-42c0-a3df-eef2d784011f", FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { "caab946b-a155-4297-a8a6-aaaa5aedf76d", new TestEntityOne{ Id = "caab946b-a155-4297-a8a6-aaaa5aedf76d", FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { "3e627ea2-27e6-48a3-9846-3f27008edd6b", new TestEntityOne{ Id = "3e627ea2-27e6-48a3-9846-3f27008edd6b", FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { "77a906b7-46ca-4e9a-b94b-5cf816f4d984", new TestEntityOne{ Id = "77a906b7-46ca-4e9a-b94b-5cf816f4d984", FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Set<TestEntityOne>()).Returns(entities);
            var unitOfWork = uowMock.Object;
            var repo = new JsonRepository<TestEntityOne>(unitOfWork);

            var testAll = repo.All().ToList();
            Assert.IsNotNull(testAll);
            Assert.IsTrue(testAll.Count == 4);
            Assert.IsTrue(testAll[0].Id == "3c0b80ed-6542-42c0-a3df-eef2d784011f");
            Assert.IsTrue(testAll[1].Id == "caab946b-a155-4297-a8a6-aaaa5aedf76d");
            Assert.IsTrue(testAll[2].Id == "3e627ea2-27e6-48a3-9846-3f27008edd6b");
            Assert.IsTrue(testAll[3].Id == "77a906b7-46ca-4e9a-b94b-5cf816f4d984");
        }

        [Test()]
        public void Where_Test()
        {
            var entities = new Dictionary<string, TestEntityOne>
            {
                { "3c0b80ed-6542-42c0-a3df-eef2d784011f", new TestEntityOne{ Id = "3c0b80ed-6542-42c0-a3df-eef2d784011f", FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { "caab946b-a155-4297-a8a6-aaaa5aedf76d", new TestEntityOne{ Id = "caab946b-a155-4297-a8a6-aaaa5aedf76d", FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { "3e627ea2-27e6-48a3-9846-3f27008edd6b", new TestEntityOne{ Id = "3e627ea2-27e6-48a3-9846-3f27008edd6b", FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { "77a906b7-46ca-4e9a-b94b-5cf816f4d984", new TestEntityOne{ Id = "77a906b7-46ca-4e9a-b94b-5cf816f4d984", FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Set<TestEntityOne>()).Returns(entities);

            var repo = new JsonRepository<TestEntityOne>(uowMock.Object);

            var testWhere = repo.Where(x => x.FieldB == 303 || x.FieldC == "Field_C_4").ToList();
            Assert.IsNotNull(testWhere);
            Assert.IsTrue(testWhere.Count == 2);
            Assert.IsTrue(testWhere[0].Id == "3e627ea2-27e6-48a3-9846-3f27008edd6b");
            Assert.IsTrue(testWhere[1].Id == "77a906b7-46ca-4e9a-b94b-5cf816f4d984");
        }

        [Test()]
        public void FirstOrDefault_Test()
        {
            var entities = new Dictionary<string, TestEntityOne>
            {
                { "3c0b80ed-6542-42c0-a3df-eef2d784011f", new TestEntityOne{ Id = "3c0b80ed-6542-42c0-a3df-eef2d784011f", FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { "caab946b-a155-4297-a8a6-aaaa5aedf76d", new TestEntityOne{ Id = "caab946b-a155-4297-a8a6-aaaa5aedf76d", FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { "3e627ea2-27e6-48a3-9846-3f27008edd6b", new TestEntityOne{ Id = "3e627ea2-27e6-48a3-9846-3f27008edd6b", FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { "77a906b7-46ca-4e9a-b94b-5cf816f4d984", new TestEntityOne{ Id = "77a906b7-46ca-4e9a-b94b-5cf816f4d984", FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } }
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Set<TestEntityOne>()).Returns(entities);

            var repo = new JsonRepository<TestEntityOne>(uowMock.Object);

            var testFirstOrDefault_NotNull = repo.FirstOrDefault(x => x.FieldB == 303 || x.FieldC == "Field_C_4");
            Assert.IsNotNull(testFirstOrDefault_NotNull);
            Assert.IsTrue(testFirstOrDefault_NotNull.Id == "3e627ea2-27e6-48a3-9846-3f27008edd6b" || testFirstOrDefault_NotNull.Id == "77a906b7-46ca-4e9a-b94b-5cf816f4d984");

            var testFirstOrDefault_IsNull = repo.FirstOrDefault(x => x.FieldB == 555);
            Assert.IsNull(testFirstOrDefault_IsNull);
        }

        [Test()]
        public void Insert_Test()
        {
            var entities = new Dictionary<string, TestEntityOne>
            {
                { "3c0b80ed-6542-42c0-a3df-eef2d784011f", new TestEntityOne{ Id = "3c0b80ed-6542-42c0-a3df-eef2d784011f", FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { "caab946b-a155-4297-a8a6-aaaa5aedf76d", new TestEntityOne{ Id = "caab946b-a155-4297-a8a6-aaaa5aedf76d", FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { "3e627ea2-27e6-48a3-9846-3f27008edd6b", new TestEntityOne{ Id = "3e627ea2-27e6-48a3-9846-3f27008edd6b", FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { "77a906b7-46ca-4e9a-b94b-5cf816f4d984", new TestEntityOne{ Id = "77a906b7-46ca-4e9a-b94b-5cf816f4d984", FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } },
                { "71bb8f25-cdc5-43f5-a66c-4e3dab81d2af", new TestEntityOne{ Id = "71bb8f25-cdc5-43f5-a66c-4e3dab81d2af", FieldA = "Field_A_6", FieldB = 606, FieldC = "Field_C_6", FieldD = false } }
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Set<TestEntityOne>()).Returns(entities);

            var repo = new JsonRepository<TestEntityOne>(uowMock.Object);

            var testEntityOne = new TestEntityOne { FieldA = "Insert_1", FieldB = 111, FieldC = "Insert_1", FieldD = true };
            var newIdOne = repo.Insert(testEntityOne);

            var result = repo.Get(newIdOne);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == newIdOne);
            Assert.IsTrue(result.FieldA == "Insert_1");
            Assert.IsTrue(repo.All().Count() == 6);

            var testEntityTwo = new TestEntityOne { FieldA = "Insert_2", FieldB = 222, FieldC = "Insert_2", FieldD = false };
            var newIdTwo = repo.Insert(testEntityTwo);

            result = repo.Get(newIdTwo);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == newIdTwo);
            Assert.IsTrue(result.FieldA == "Insert_2");
            Assert.IsTrue(repo.All().Count() == 7);
        }

        [Test()]
        public void Update_Test()
        {
            var entities = new Dictionary<string, TestEntityOne>
            {
                { "3c0b80ed-6542-42c0-a3df-eef2d784011f", new TestEntityOne{ Id = "3c0b80ed-6542-42c0-a3df-eef2d784011f", FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false } },
                { "caab946b-a155-4297-a8a6-aaaa5aedf76d", new TestEntityOne{ Id = "caab946b-a155-4297-a8a6-aaaa5aedf76d", FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true } },
                { "3e627ea2-27e6-48a3-9846-3f27008edd6b", new TestEntityOne{ Id = "3e627ea2-27e6-48a3-9846-3f27008edd6b", FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false } },
                { "77a906b7-46ca-4e9a-b94b-5cf816f4d984", new TestEntityOne{ Id = "77a906b7-46ca-4e9a-b94b-5cf816f4d984", FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true } },
                { "71bb8f25-cdc5-43f5-a66c-4e3dab81d2af", new TestEntityOne{ Id = "71bb8f25-cdc5-43f5-a66c-4e3dab81d2af", FieldA = "Field_A_6", FieldB = 606, FieldC = "Field_C_6", FieldD = false } }
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Set<TestEntityOne>()).Returns(entities);

            var repo = new JsonRepository<TestEntityOne>(uowMock.Object);

            var testEntityOne = entities["3e627ea2-27e6-48a3-9846-3f27008edd6b"];
            testEntityOne.FieldA = "Changed_1";

            var idOne = repo.Update(testEntityOne);

            Assert.IsTrue(idOne == "3e627ea2-27e6-48a3-9846-3f27008edd6b");
            var result = repo.Get("3e627ea2-27e6-48a3-9846-3f27008edd6b");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == "3e627ea2-27e6-48a3-9846-3f27008edd6b");
            Assert.IsTrue(result.FieldA == "Changed_1");
            Assert.IsTrue(repo.All().Count() == 5);

            var testEntityTwo = new TestEntityOne { FieldA = "Insert_2", FieldB = 222, FieldC = "Insert_2", FieldD = false };
            var idTwo = repo.Update(testEntityTwo);

            Assert.IsNotNull(idTwo);
            result = repo.Get(idTwo);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == idTwo);
            Assert.IsTrue(result.FieldA == "Insert_2");
            Assert.IsTrue(repo.All().Count() == 6);
        }
    }
}
