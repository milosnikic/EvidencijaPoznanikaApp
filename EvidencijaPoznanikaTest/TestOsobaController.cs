using EvidencijaPoznanika.API.Models;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using EvidencijaPoznanika.API.Controllers;
using System.Threading.Tasks;
using System;

namespace EvidencijaPoznanikaTest
{
    // Zbog potrebe za usloznjavanja kontrolera i logike aplikacije 
    // testirana je jednostavna metoda kontrolera koja ima za cilj da 
    // sabere listu brojeva. Pokriveni su slucajevi gde se umesto liste prosledi NULL
    // , korektan unos i prazna lista
    public class Tests
    {
        private List<int> numbers;
        [SetUp]
        public void Setup()
        {
            numbers = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 });
        }

        [Test]
        public void TestAddNumbers()
        {
            var controller = new OsobaController();
            var sum = controller.AddNumbers(numbers); 
            Assert.AreEqual(sum, 28);
        }

        [Test]
        public void TestAddNumbers_NotCorrect()
        {
            var controller = new OsobaController();
            var sum = controller.AddNumbers(numbers);
            Assert.AreNotEqual(sum, 24);
        }

        [Test]
        public void TestAddNumbers_NullPassed()
        {
            var controller = new OsobaController();
            var sum = controller.AddNumbers(null);
            Assert.AreEqual(sum, null);
        }


        [Test]
        public void TestAddNumbers_EmptyListPassed()
        {
            var controller = new OsobaController();
            var sum = controller.AddNumbers(new List<int>());
            Assert.AreEqual(sum, null);
        }
    }
}