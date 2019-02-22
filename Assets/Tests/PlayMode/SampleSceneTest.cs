using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace MyProject.Tests.PlayMode {
    public class SampleSceneTest {

        PlayModeTestTranlationNotifier translationNotifier;
        MovableObject cube;
        SampleScene sceneObj;
        bool sceneLoading;

        [OneTimeSetUp]
        public void InitializeTest() {
            translationNotifier = new PlayModeTestTranlationNotifier();
            sceneLoading = true;
            SceneManager.LoadSceneAsync("SampleScene").completed += _ => {
                Debug.Log("Scene Loaded");
                cube = GameObject.Find("Cube")?.GetComponent<MovableObject>();
                sceneObj = GameObject.Find("SampleScene")?.GetComponent<SampleScene>();
                sceneObj?.SetTranslationNotifierAndStartSession(translationNotifier);
                sceneLoading = false;
            };
        }

        [SetUp]
        public void InitializeAllTest() {
            cube?.ResetPosition();
        }


        [UnityTest]
        [Order(-100)]
        public IEnumerator 最初に呼ばれるテストでロード待ち() {
            yield return new WaitWhile(() => sceneLoading);
        }

        //[UnityTest]
        //public void MovableObjectが存在するかのテスト() {
        [UnityTest]
        public IEnumerator MovableObjectが存在するかのテスト() {
            Assert.NotNull(cube);
            yield return null;
        }

        [UnityTest]
        public IEnumerator SampleSceneが存在するかのテスト() {
            Assert.NotNull(sceneObj);
            yield return null;
        }

        [UnityTest]
        public IEnumerator 右に動くかのテスト() {
            var org = cube.transform.position;
            translationNotifier.MoveRight();
            var moved = cube.transform.position;
            Assert.Greater(moved.x, org.x);
            yield return null;
        }

        [UnityTest]
        public IEnumerator 左に動くかのテスト() {
            var org = cube.transform.position;
            translationNotifier.MoveLeft();
            var moved = cube.transform.position;
            Assert.Less(moved.x, org.x);
            yield return null;
        }

        [UnityTest]
        public IEnumerator 上に動くかのテスト() {
            var org = cube.transform.position;
            translationNotifier.MoveUp();
            var moved = cube.transform.position;
            Assert.Greater(moved.y, org.y);
            yield return null;
        }

        [UnityTest]
        public IEnumerator 下に動くかのテスト() {
            var org = cube.transform.position;
            translationNotifier.MoveDown();
            var moved = cube.transform.position;
            Assert.Less(moved.y, org.y);
            yield return null;
        }

        [UnityTest]
        public IEnumerator ある値以上は動かなくなるかのテスト() {
            cube.Speed = 0.1F;
            var pre = cube.transform.position;
            // right
            while (true) {
                translationNotifier.MoveRight();
                var cur = cube.transform.position;
                if (Mathf.Approximately(pre.x, cur.x)) {
                    break;
                }
                pre = cur;
                yield return null;
            }
            cube.ResetPosition();
            pre = cube.transform.position;
            // left
            while (true) {
                translationNotifier.MoveLeft();
                var cur = cube.transform.position;
                if (Mathf.Approximately(pre.x, cur.x)) {
                    break;
                }
                pre = cur;
                yield return null;
            }
            cube.ResetPosition();
            pre = cube.transform.position;
            // up
            while (true) {
                translationNotifier.MoveUp();
                var cur = cube.transform.position;
                if (Mathf.Approximately(pre.y, cur.y)) {
                    break;
                }
                pre = cur;
                yield return null;
            }
            cube.ResetPosition();
            pre = cube.transform.position;
            // down
            while (true) {
                translationNotifier.MoveDown();
                var cur = cube.transform.position;
                if (Mathf.Approximately(pre.y, cur.y)) {
                    break;
                }
                pre = cur;
                yield return null;
            }
        }

        [UnityTest]
        public IEnumerator 移動にSpeedが関係するかのテスト() {
            cube.Speed = 1.0F;
            translationNotifier.MoveRight();
            var firstPos = cube.transform.position;
            cube.ResetPosition();
            cube.Speed = 10.0F;
            translationNotifier.MoveRight();
            var secondPos = cube.transform.position;
            Assert.Greater(secondPos.x, firstPos.x);
            yield return null;
        }
    }
}
