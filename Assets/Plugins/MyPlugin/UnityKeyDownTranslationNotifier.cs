using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlugin {
    public class UnityKeyDownTranslationNotifier : MonoBehaviour, ITranslationNotifier {
        public event Action<TranslationType> OnTranslation = delegate { };

        private bool hasSession = false;

        void Update() {
            if (!hasSession) {
                return;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                OnTranslation.Invoke(TranslationType.Right);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                OnTranslation.Invoke(TranslationType.Left);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                OnTranslation.Invoke(TranslationType.Up);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                OnTranslation.Invoke(TranslationType.Down);
            }
        }

        public void StartSession() {
            hasSession = true;
        }

        public void StopSession() {
            hasSession = false;
        }
    }
}
