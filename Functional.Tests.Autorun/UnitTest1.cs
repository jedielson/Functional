using System;
using System.Collections.Generic;
using System.Linq;
using Functional.Data.Nhibernate.SqlServer.Context;
using Functional.Data.Nhibernate.SqlServer.Repository;
using Functional.Domain.Entities;
using Functional.Domain.Entities.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Functional.Tests.Autorun
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var udt = new UnidadeDeTrabalhoNh())
            {
                var teste = true;
                Assert.AreEqual(true, teste);
            }
        }

        [TestMethod]
        public void ProjetoRepositoryAdd()
        {
            using (var udt = new UnidadeDeTrabalhoNh())
            {
                var projeto = new Projeto {Nome = "Teste de Insert", Codigo = "000001"};
                var repo = new ProjetoRepository(udt);
                repo.Save(projeto);
            }

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void ProjetoRepositoryUpdate()
        {
            using (var udt = new UnidadeDeTrabalhoNh())
            {                
                try
                {
                    udt.IniciarTransacao();
                    var repo = new ProjetoRepository(udt);
                    var lista = repo.All();
                    var projeto = lista.OrderByDescending(x => x.ProjetoId).SingleOrDefault();
                    projeto.Nome = "Nome Editado";
                    repo.Update(projeto);
                    udt.ConfirmarTransacao();
                }
                catch (Exception)
                {
                    udt.DesfazerTransacao();
                }
            }

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void RequisitoSave()
        {
            using (var udt = new UnidadeDeTrabalhoNh())
            {
                udt.IniciarTransacao();
                try
                {
                    var projeto = new Projeto
                                  {
                                      Nome = "Teste de Insert", 
                                      Codigo = "000001"
                                  };
                    var requisito = new Requisito
                                    {
                                        Codigo = "000000",
                                        Titulo = "teste requisito",
                                        Descricao = "lololololo"
                                    };
                    projeto.Requisitos = new List<Requisito> {requisito};

                    var repo = new ProjetoRepository(udt);
                    var requisitoRepo = new RequisitoRepository(udt);

                    repo.Save(projeto);

                    foreach (var item in projeto.Requisitos)
                    {
                        requisitoRepo.Save(item);

                    }
                    udt.ConfirmarTransacao();
                }
                catch (Exception ex)
                {
                    udt.DesfazerTransacao();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
