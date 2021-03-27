using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Keyboard
{
    public class HR_OSK_Controller : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _lowercaseLayer;
        [SerializeField] private CanvasGroup _uppercaseLayer;
        [SerializeField] private CanvasGroup _numbersLayer;
        private CanvasGroup _currentLayer;
        [SerializeField] private InputField _inputField;

        private void Start()
        {
            ShowCanvasGroup(_lowercaseLayer);
            HideCanvasGroup(_uppercaseLayer);
            HideCanvasGroup(_numbersLayer);
            _inputField.Focus();
        }

        internal void SpecialKeyPress(KeyCode code)
        {
            _inputField.Execute(code);
        }

        public void KeyPress(string value)
        {
            _inputField.Append(value);
        }

        public void ShowLowercase()
        {
            ShowLayer(_lowercaseLayer);
        }

        public void ShowUppercase()
        {
            ShowLayer(_uppercaseLayer);
        }

        public void ShowNumbers()
        {
            ShowLayer(_numbersLayer);
        }

        private void ShowLayer(CanvasGroup layer)
        {
            HideCanvasGroup(_currentLayer);
            ShowCanvasGroup(layer);
        }

        private void HideCanvasGroup(CanvasGroup canvas)
        {
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
        }

        private void ShowCanvasGroup(CanvasGroup canvas)
        {
            _currentLayer = canvas;
            canvas.alpha = 1;
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        }
    }
}

