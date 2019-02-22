using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject {
    public class SceneObject : MonoBehaviour {
        const float rightMax = 6.0F;
        const float leftMin = -rightMax;
        const float upMax = 4.5F;
        const float downMin = -upMax;


        [SerializeField] [Range(0.0F, 2.0F)] float speed = 0.1F;
        public float Speed { set { speed = value; } get => speed; }

        void Start() {
            Reset();
        }

        public void Reset() {
            transform.position = Vector3.zero;
        }

        public void ToRight() {
            if (transform.Px() + speed <= rightMax) {
                transform.MoveToRight(speed);
            }
        }

        public void ToLeft() {
            if (transform.Px() - speed >= leftMin) {
                transform.MoveToLeft(speed);
            }
        }

        public void ToUp() {
            if (transform.Py() + speed <= upMax) {
                transform.MoveToUp(speed);
            }
        }

        public void ToDown() {
            if (transform.Py() - speed >= downMin) {
                transform.MoveToDown(speed);
            }
        }
    }

    static class MoveExtension {
        public static float Px(this Transform t) { return t.position.x; }
        public static float Py(this Transform t) { return t.position.y; }
        public static float Pz(this Transform t) { return t.position.z; }

        public static void MoveToRight(this Transform t, float d) {
            t.position = new Vector3(t.Px() + d, t.Py(), t.Pz());
        }
        public static void MoveToLeft(this Transform t, float d) {
            t.position = new Vector3(t.Px() - d, t.Py(), t.Pz());
        }
        public static void MoveToUp(this Transform t, float d) {
            t.position = new Vector3(t.Px(), t.Py() + d, t.Pz());
        }
        public static void MoveToDown(this Transform t, float d) {
            t.position = new Vector3(t.Px(), t.Py() - d, t.Pz());
        }
    }
}
