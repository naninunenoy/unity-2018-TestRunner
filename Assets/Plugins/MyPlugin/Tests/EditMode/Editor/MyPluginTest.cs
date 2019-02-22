using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MyPlugin.Tests {
    public class MyPluginTest {
        [Test]
        public void TranslationTypeのテスト() {
            Assert.AreEqual(Vector3.right, TranslationType.Right.ToUnitVector());
            Assert.AreEqual(Vector3.left, TranslationType.Left.ToUnitVector());
            Assert.AreEqual(Vector3.up, TranslationType.Up.ToUnitVector());
            Assert.AreEqual(Vector3.down, TranslationType.Down.ToUnitVector());
            Assert.AreEqual(Vector3.zero, TranslationType.None.ToUnitVector());
        }

        [Test] 
        public void UnityKeyDownTranslationNotifierのテスト() {
            var obj = new GameObject("").AddComponent<UnityKeyDownTranslationNotifier>();
            Assert.False(obj.IsSessionRunning);
            obj.StartSession();
            Assert.True(obj.IsSessionRunning);
            obj.StopSession();
            Assert.False(obj.IsSessionRunning);
        }
    }
}
