using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlugin {
    public enum TranslationType { None = 0, Right, Left, Up, Down }

    public static class TranslationTypeEx {
        public static Vector3 ToUnitVector(this TranslationType type) {
            switch (type) {
            case TranslationType.Right:
                return Vector3.right;
            case TranslationType.Left:
                return Vector3.left;
            case TranslationType.Up:
                return Vector3.up;
            case TranslationType.Down:
                return Vector3.down;
            default:
                return Vector3.zero;
            }
        }
    }
}
