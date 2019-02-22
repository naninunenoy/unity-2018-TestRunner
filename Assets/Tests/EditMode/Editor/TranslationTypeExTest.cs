using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MyProject.Tests.EditMode {
    public class TranslationTypeExTest {
        [Test]
        public void Noneだとzeroが返る() {
            var result = MyPlugin.TranslationType.None.GetSafeNextPosition(new Vector3(), 0, 0);
            Assert.AreEqual(Vector3.zero, result);
        }

        [Test]
        public void 右へ移動() {
            var result = MyPlugin.TranslationType.Right.GetSafeNextPosition(Vector3.zero, 1, 100);
            Assert.AreEqual(new Vector3(1,0,0), result);
            result = MyPlugin.TranslationType.Right.GetSafeNextPosition(Vector3.zero, 999, 100);
            Assert.AreEqual(new Vector3(100, 0, 0), result);
        }

        [Test]
        public void 左へ移動() {
            var result = MyPlugin.TranslationType.Left.GetSafeNextPosition(Vector3.zero, 1, -100);
            Assert.AreEqual(new Vector3(-1, 0, 0), result);
            result = MyPlugin.TranslationType.Left.GetSafeNextPosition(Vector3.zero, 999, -100);
            Assert.AreEqual(new Vector3(-100, 0, 0), result);
        }

        [Test]
        public void 上へ移動() {
            var result = MyPlugin.TranslationType.Up.GetSafeNextPosition(Vector3.zero, 1, 100);
            Assert.AreEqual(new Vector3(0, 1, 0), result);
            result = MyPlugin.TranslationType.Up.GetSafeNextPosition(Vector3.zero, 999, 100);
            Assert.AreEqual(new Vector3(0, 100, 0), result);
        }

        [Test]
        public void 下へ移動() {
            var result = MyPlugin.TranslationType.Down.GetSafeNextPosition(Vector3.zero, 1, -100);
            Assert.AreEqual(new Vector3(0, -1, 0), result);
            result = MyPlugin.TranslationType.Down.GetSafeNextPosition(Vector3.zero, 999, -100);
            Assert.AreEqual(new Vector3(0, -100, 0), result);
        }
    }
}
