using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject {
    public interface IMovable {
        void MovePosition(Vector3 position);
        float Speed { set; get; }
    }
}