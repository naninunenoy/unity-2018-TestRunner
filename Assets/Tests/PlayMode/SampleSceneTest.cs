using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests {
    public class SampleSceneTest {

        [SetUp]
        public void SetUpTest() {
            SceneManager.LoadScene("SampleScene");
        }

        [UnityTest]
        public IEnumerator 時間経過で右に移動していることを確認する() {
            var cube = GameObject.Find("Cube");
            yield return new WaitForFixedUpdate();
            var x1 = cube.transform.position.x;
            yield return new WaitForFixedUpdate();
            var x2 = cube.transform.position.x;
            Assert.Greater(x2, x1);
        }

        [UnityTest]
        public IEnumerator 結構時間がたつとcubeが消えることを確認する() {
            var cube = GameObject.Find("Cube");
            Assert.NotNull(cube);
            yield return new WaitForSeconds(5);
            //Assert.Null(cube);
            Assert.IsTrue(cube == null);
        }
    }
}
