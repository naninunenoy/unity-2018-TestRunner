using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject {
    public class SampleScene : MonoBehaviour {
        [SerializeField] SceneObject obj = default;

        private MyPlugin.ITranslationNotifier translationNotifier;

        void Start() {
            translationNotifier = gameObject.AddComponent<MyPlugin.UnityKeyDownTranslationNotifier>();
            translationNotifier.OnTranslation += OnReceiveTransition;
            translationNotifier?.StartSession();
        }

        void OnDestroy() {
            translationNotifier.OnTranslation -= OnReceiveTransition;
            translationNotifier?.StopSession();
        }

        void OnReceiveTransition(MyPlugin.TranslationType translation) {
            switch (translation) {
            case MyPlugin.TranslationType.Right:
                obj?.ToRight();
                break;
            case MyPlugin.TranslationType.Left:
                obj?.ToLeft();
                break;
            case MyPlugin.TranslationType.Up:
                obj?.ToUp();
                break;
            case MyPlugin.TranslationType.Down:
                obj?.ToDown();
                break;
            default:
                // Do Nothing
                break;
            }
        }
    }
}