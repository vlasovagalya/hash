using System;
using System.ComponentModel;
using NUnit.Framework;
      
        

namespace HashTests
{
    [TestFixture]
    public class HashTests
    {
        
        [Test]
        public void AddingThreeElementsTest()
        {
            var key1 = "int";
            var key2 = 4;
            var key3 = 3;
            var ht = new HashTable.Hash(3);
            ht.PutPair(key1, 2);
            ht.PutPair(key2, 34);
            ht.PutPair(key3, new[] { 0, 1, 2 });
            Assert.AreEqual(ht.GetValueByKey(key1), 2);
            Assert.AreEqual(ht.GetValueByKey(key2), 34);
            Assert.AreEqual(ht.GetValueByKey(key3), new[] { 0, 1, 2 });
        }

        [Test]
        public void TwoEquialsElementsTest()
        {
            var element = "el2";
            var newElement = "new";
            var ht = new HashTable.Hash(3);
            ht.PutPair(2, element);
            ht.PutPair(2, newElement);
            Assert.AreEqual(newElement, ht.GetValueByKey(2));
        }

        [Test]
        public void ThousandsElementsTest()
        {
        
            var size = 10000;
            var ht = new HashTable.Hash(size);
            for (int i = 0; i < size; i++)
               {
                   ht.PutPair(i, i + 1);
               }
            Assert.AreEqual(ht.GetValueByKey(15), 16);
            
        }
        [Test]
        public void FindingAlienKeys()
        {
            var size = 10000;
            var ht = new HashTable.Hash(size);

            for (int i = 1; i < size; i++)
            {
                ht.PutPair(i, i + 1);
            }

            for (int i = size; i < 11000; i++)
            {
                Assert.AreEqual(ht.GetValueByKey(i), null);
            }
        }
    }
}