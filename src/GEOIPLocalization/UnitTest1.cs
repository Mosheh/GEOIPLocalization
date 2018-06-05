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
            var obj = new LocalizationService().GetLocalization("8.8.8.8");
            Assert.AreEqual("California", obj.Region);
        }

        [TestMethod]
        public void TestGoianiaLocalization()
        {
            var obj = new LocalizationService().GetLocalization();
            Assert.AreEqual("Goiânia", obj.City);
        }

        [TestMethod]
        public void TestRioDeJaneiroLocalization()
        {
            var obj = new LocalizationService().GetLocalization("186.192.90.5");
            Assert.AreEqual("Rio de Janeiro", obj.City);
        }
    }
}
