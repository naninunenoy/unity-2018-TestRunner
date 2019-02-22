using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MyPlugin.Tests {
    public class MyClassTest {

        [SetUp]
        public void SetUpTest() {
        }

        // A Test behaves as an ordinary method
        [Test]
        public void 空のテスト() {
            Assert.True(true);
        }
    }
}
