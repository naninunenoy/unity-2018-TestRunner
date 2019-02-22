using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject {
    public class SampleScene : MonoBehaviour {

        [SerializeField] float rectRangeRight = 6.0F;
        [SerializeField] float rectRangeLeft = -6.0F;
        [SerializeField] float rectRangeTop = 4.5F;
        [SerializeField] float rectRangeBottom = -4.5F;
        [SerializeField] MovableObject obj = default;

        private MyPlugin.ITranslationNotifier translationNotifier;

        void Start() {
            translationNotifier = gameObject.AddComponent<MyPlugin.UnityKeyDownTranslationNotifier>();
            if (translationNotifier != null) {
                translationNotifier.OnTranslation += OnReceiveTransition;
                translationNotifier.StartSession();
            }
        }

        void OnDestroy() {
            if (translationNotifier != null) {
                translationNotifier.OnTranslation -= OnReceiveTransition;
                translationNotifier.StopSession();
            }
        }

        void OnReceiveTransition(MyPlugin.TranslationType translation) {
            if (translation != MyPlugin.TranslationType.None) {
                obj?.MovePosition(translation.GetSafeNextPosition(obj.transform.position, obj.Speed, GetLimit(translation)));
            }
        }

        float GetLimit(MyPlugin.TranslationType direction) {
            switch (direction) {
            case MyPlugin.TranslationType.Right: return rectRangeRight;
            case MyPlugin.TranslationType.Left: return rectRangeLeft;
            case MyPlugin.TranslationType.Up: return rectRangeTop;
            case MyPlugin.TranslationType.Down: return rectRangeBottom;
            default: return float.MaxValue;
            }
        }
    }

    public static class TranslationTypeEx {
        private static bool IsVirticalMove(this MyPlugin.TranslationType type) {
            return type == MyPlugin.TranslationType.Up || type == MyPlugin.TranslationType.Down;
        }

        private static bool IsPositiveMove(this MyPlugin.TranslationType type) {
            return type == MyPlugin.TranslationType.Up || type == MyPlugin.TranslationType.Right;
        }

        public static Vector3 GetSafeNextPosition(this MyPlugin.TranslationType direction, Vector3 currentPos, float unit, float limit) {
            if (direction == MyPlugin.TranslationType.None) {
                return Vector3.zero;
            }
            var current = direction.IsVirticalMove() ? currentPos.y : currentPos.x;
            var next = direction.IsPositiveMove() ? current + unit : current - unit;
            var isOver = direction.IsPositiveMove() ? next > limit : next < limit;
            if (isOver) {
                return direction.IsVirticalMove() ? new Vector3(currentPos.x, limit, currentPos.z) : new Vector3(limit, currentPos.y, currentPos.z);
            }
            return direction.IsVirticalMove() ? new Vector3(currentPos.x, next, currentPos.z) : new Vector3(next, currentPos.y, currentPos.z);
        }
    }
}
