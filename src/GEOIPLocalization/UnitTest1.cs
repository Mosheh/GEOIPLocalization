using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GEOIPLocalization.Net.Services;

namespace GEOIPLocalization.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGoogleLocalization()
        {
            var localization = new LocalizationService().GetLocalization("8.8.8.8");
            Assert.AreEqual("California", localization.Region);
        }

        [TestMethod]
        public void TestGoianiaBrazilLocalization()
        {
            var localization = new LocalizationService().GetLocalization();
            Assert.AreEqual("Goiânia", localization.City);
        }

        [TestMethod]
        public void TestRioDeJaneiroLocalization()
        {
            var localization = new LocalizationService().GetLocalization("186.192.90.5");
            Assert.AreEqual("Rio de Janeiro", localization.City);
        }
    }
}
