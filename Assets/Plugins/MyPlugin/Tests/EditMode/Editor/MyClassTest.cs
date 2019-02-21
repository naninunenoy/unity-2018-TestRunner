using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MyPlugin.Tests {
    public class MyClassTest {
        MyClass myClass;

        [SetUp]
        public void SetUpTest() {
            myClass = new MyClass();
        }

        // A Test behaves as an ordinary method
        [Test]
        public void MyClassの初期値が正しいか確認する() {
            Assert.AreEqual(99, myClass.ID);
            Assert.AreEqual("Taro", myClass.Name);
        }
    }
}
