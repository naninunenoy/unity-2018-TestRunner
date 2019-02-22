using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlugin {
    public interface ITranslationNotifier {
        event Action<TranslationType> OnTranslation;
        void StartSession();
        void StopSession();
    }

    public class NullTranslationNotifier : ITranslationNotifier {
        public event Action<TranslationType> OnTranslation = null;
        public void StartSession() { /* Do Nothing */ }
        public void StopSession() { /* Do Nothing */ }
    }
}
