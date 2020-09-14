using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APIRegistro.Controllers;
using APIRegistro.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace admRegistro.Tests.Controllers
{
    [TestClass]
    public class UnitTestAPIRegistro
    {
        [TestMethod]
        public void TestGetRegistro()
        {
            //Arrange
            RegistroesController registroesController = new RegistroesController();

            //Act
            var ListaReg = registroesController.GetRegistroes();

            //Asert
            Assert.IsNotNull(ListaReg);
        }

        [TestMethod]
        public void TestPostRegistro()
        {
            //Arrange
            RegistroesController registroesController = new RegistroesController();
            Registro registro_esp = new Registro()
            {
                FriendofRamirez = "Frencisco Zenteno",
                RamirezID = 2015110789,
                Email = "panchozenteno@gmail.com",
                Place = Place.LPZ,
                Birthdate = DateTime.Today
            };

            //Act
            IHttpActionResult actionResult = registroesController.PostRegistro(registro_esp);
            var registro_act = actionResult as CreatedAtRouteNegotiatedContentResult<Registro>;

            //Asert
            Assert.IsNotNull(registro_act);
            Assert.AreEqual("DefaultApi", registro_act.RouteName);
            Assert.AreEqual(registro_esp.FriendofRamirez, registro_act.Content.FriendofRamirez);
            Assert.AreEqual(registro_esp.Email, registro_act.Content.Email);
            Assert.AreEqual(registro_esp.Birthdate, registro_act.Content.Birthdate);
            Assert.AreEqual(registro_esp.Place, registro_act.Content.Place);

        }

        [TestMethod]
        public void TestDeleteRegistro()
        {
            //Arrange
            RegistroesController registroesController = new RegistroesController();
            Registro registro_esp = new Registro()
            {
                FriendofRamirez = "Frencisco Zenteno",
                RamirezID = 2015110789,
                Email = "panchozenteno@gmail.com",
                Place = Place.LPZ,
                Birthdate = DateTime.Today
            };

            //Act
            IHttpActionResult actionResult = registroesController.DeleteRegistro(registro_esp.RamirezID);

            //Asert
            Assert.IsNotInstanceOfType(actionResult, typeof(OkResult));

        }

        [TestMethod]
        public void TestPutRegistro()
        {
            //Arrange
            RegistroesController registroesController = new RegistroesController();
            Registro registro_esp = new Registro()
            {
                FriendofRamirez = "Frencisco Zenteno",
                RamirezID = 2015110789,
                Email = "panchozenteno@gmail.com",
                Place = Place.LPZ,
                Birthdate = DateTime.Today
            };
            string newname = "Galia Zenteno";

            //Act
            var actionResult = registroesController.PostRegistro(registro_esp);
            registro_esp.FriendofRamirez = newname;
            var actionResultPut = registroesController.PutRegistro(registro_esp.RamirezID, registro_esp) as StatusCodeResult;

            //Asert
            Assert.IsNotNull(actionResultPut);
            Assert.AreEqual(HttpStatusCode.NoContent, actionResultPut.StatusCode);
            Assert.IsInstanceOfType(actionResultPut, typeof(StatusCodeResult));
        }
    }
}
