using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace TDD.UI
{
    /// <summary>
    /// Description résumée pour CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void T701CodedUITestMethod1()
        {
            // Pour générer le code de ce test, sélectionnez "Générer le code pour le test codé de l'interface utilisateur" dans le menu contextuel et sélectionnez un des éléments de menu.
            this.UIMap.Search();
            this.UIMap.BookIdAssert();

        }

        #region Attributs de tests supplémentaires

        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :

        ////Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // Pour générer le code de ce test, sélectionnez "Générer le code pour le test codé de l'interface utilisateur" dans le menu contextuel et sélectionnez un des éléments de menu.
        //}

        ////Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // Pour générer le code de ce test, sélectionnez "Générer le code pour le test codé de l'interface utilisateur" dans le menu contextuel et sélectionnez un des éléments de menu.
        //}

        #endregion

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
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
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
