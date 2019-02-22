using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject {
    public class MovableObject : MonoBehaviour, IMovable {

        [SerializeField] [Range(0.0F, 2.0F)] float speed = 0.1F;
        public float Speed { set { speed = value; } get => speed; }

        void Start() {
            ResetPosition();
        }

        public void ResetPosition() {
            transform.position = Vector3.zero;
        }

        public void MovePosition(Vector3 position) {
            transform.position = position;
        }
    }
}
