using System;
using System.Collections;
using System.Collections.Generic;
using MyPlugin;
using UnityEngine;

namespace MyProject.Tests.PlayMode {
    public class PlayModeTestTranlationNotifier : ITranslationNotifier {
        public event Action<TranslationType> OnTranslation = delegate { };

        public void StartSession() { /* Do Nothing*/ }
        public void StopSession() { /* Do Nothing*/ }

        public void MoveRight() { OnTranslation.Invoke(TranslationType.Right); }
        public void MoveLeft() { OnTranslation.Invoke(TranslationType.Left); }
        public void MoveUp() { OnTranslation.Invoke(TranslationType.Up); }
        public void MoveDown() { OnTranslation.Invoke(TranslationType.Down); }
    }
}
