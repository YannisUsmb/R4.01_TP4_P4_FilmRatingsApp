using TP4_FilmRatingsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4_FilmRatingsApp.Models;
using Windows.ApplicationModel.VoiceCommands;

namespace TP4_FilmRatingsApp.ViewModels.Tests
{
    [TestClass()]
    public class VisualiserUtilisateurViewModelTests
    {
        private VisualiserUtilisateurViewModel viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            viewModel = new VisualiserUtilisateurViewModel();
        }

        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void VisualiserUtilisateurViewModelTest()
        {
            Assert.IsNotNull(viewModel);
            Assert.IsNotNull(viewModel.UtilisateurSearch);
        }

        [TestMethod()]
        public async Task ActionSearchUtilisateurTest()
        {
            // Arrange
            viewModel.SearchMail = "iosdqrgusbu@jsrb.d";

            Utilisateur utilisateur = new Utilisateur
            {
                  UtilisateurId = 14,
                  Nom = "Barrier",
                  Prenom = "Florian",
                  Mobile = "0612131415",
                  Mail = "iosdqrgusbu@jsrb.d",
                  Pwd = "qqqqqSSS11!!",
                  Rue = "983 rue de cote-barrier",
                  CodePostal = "73160",
                  Ville = "Saint Jean de Couz",
                  Pays = "France"
            };

            // Act
            viewModel.ActionSearchUtilisateur();
            Thread.Sleep(1000);

            // Assert
            Assert.AreEqual(utilisateur, viewModel.UtilisateurSearch, "Les Utilisateurs ne sont pas identiques !");
        }
    }
}