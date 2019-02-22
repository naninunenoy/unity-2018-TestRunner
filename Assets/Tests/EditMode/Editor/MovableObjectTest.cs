using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MyProject.Tests.EditMode {
    public class MovableObjectTest {

        MovableObject testObj;

        [SetUp]
        public void SetUp() {
            testObj = new GameObject("").AddComponent<MovableObject>();
        }

        [UnityTest]
        public IEnumerator 開始時に原点にいるか() {
            yield return null; // Start()のため一応1frame待ち
            Assert.AreEqual(Vector3.zero, testObj.transform.position);
        }

        [Test]
        public void 移動するか() {
            var newPosition = new Vector3(111, 222, 333);
            testObj.MovePosition(newPosition);
            Assert.AreEqual(newPosition, testObj.transform.position);
        }

        [Test]
        public void 移動した後Restで元に戻るか() {
            var newPosition = new Vector3(111, 222, 333);
            testObj.MovePosition(newPosition);
            Assert.AreNotEqual(Vector3.zero, testObj.transform.position);
            testObj.ResetPosition();
            Assert.AreEqual(Vector3.zero, testObj.transform.position);
        }
    }
}
