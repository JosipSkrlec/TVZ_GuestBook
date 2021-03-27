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
        [SerializeField] private TMP_Text _inputTarget;

        private void Start()
        {
            ShowCanvasGroup(_lowercaseLayer);
            HideCanvasGroup(_uppercaseLayer);
            HideCanvasGroup(_numbersLayer);
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

