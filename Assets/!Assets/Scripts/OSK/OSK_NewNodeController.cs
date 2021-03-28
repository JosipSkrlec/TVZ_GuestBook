using TMPro;
using UnityEngine;

namespace Keyboard
{
    public class OSK_NewNodeController : MonoBehaviour
    {        
        [SerializeField] private CanvasGroup _lowercaseLayer;
        [SerializeField] private CanvasGroup _uppercaseLayer;
        [SerializeField] private CanvasGroup _numbersLayer;

        [Space(15)]
        [SerializeField] private TMP_InputField _nodeUsernameInputField;
        [SerializeField] private TMP_InputField _nodeContentInputField;
        // input field representing currently selected Input Field
        private TMP_InputField _universalInputField;

        [Space(15)]
        [SerializeField] private TMP_Text _usernameLetterCounter;
        [SerializeField] private TMP_Text _contentLetterCounter;
        // text representing currently selected
        private TMP_Text _universalLetterTextIndicator;

        // private variables
        private CanvasGroup _currentLayer;
        private int _usernameMaxLetters;
        private int _contentMaxLetters;
        private int _universalMaxLetter;

        private void Start()
        {
            Setup();
        }
        public void Setup()
        {
            ShowCanvasGroup(_lowercaseLayer);
            HideCanvasGroup(_uppercaseLayer);
            HideCanvasGroup(_numbersLayer);

            _usernameMaxLetters = _nodeUsernameInputField.characterLimit;
            _contentMaxLetters = _nodeContentInputField.characterLimit;

            _nodeUsernameInputField.Select();
            _universalMaxLetter = _usernameMaxLetters;
            _universalLetterTextIndicator = _usernameLetterCounter;
            _universalInputField = _nodeUsernameInputField;

            _usernameLetterCounter.text = 0 + " / " + _usernameMaxLetters;
            _contentLetterCounter.text = 0 + " / " + _contentMaxLetters;

            _nodeUsernameInputField.text = "";
            _nodeContentInputField.text = "";

            // OLD
            //_nodeUsernameInputField.Focus();
        }

        internal void SpecialKeyPress(KeyCode code)
        {
            if (KeyCode.Delete == code)
            {
                string stringtmp = _universalInputField.text;
                if (stringtmp.Length > 0) // prevent of out ofrange exception
                {
                    var value = stringtmp.Substring(0, stringtmp.Length - 1);

                    _universalInputField.text = value;
                    _universalLetterTextIndicator.text = _universalInputField.text.Length + " / " + _universalMaxLetter;
                }
            }
            if (KeyCode.Space == code)
            {
                _universalInputField.text += " ";
                _universalLetterTextIndicator.text = _universalInputField.text.Length + " / " + _universalMaxLetter;
            }

            // OLD     
            //_nodeUsernameInputField.Execute(code);
        }

        public void KeyPress(string value)
        {
            if (_universalInputField.text.Length >= _universalMaxLetter)
            {
                return;
            }
            _universalInputField.text += value;
            _universalLetterTextIndicator.text = _universalInputField.text.Length + " / " + _universalMaxLetter;
            //_nodeUsernameInputField.Append(value);
        }

        public void SetInputFieldToSelected(TMP_InputField _inputField)
        {
            if (_inputField.name == "NoteUsernameInputField")
            {
                _nodeUsernameInputField.Select();
                _universalInputField = _nodeUsernameInputField;
                _universalMaxLetter = _usernameMaxLetters;
                _universalLetterTextIndicator = _usernameLetterCounter;
            }
            else if (_inputField.name == "NoteContentInputField")
            {      
                _nodeContentInputField.Select();
                _universalInputField = _nodeContentInputField;
                _universalMaxLetter = _contentMaxLetters;
                _universalLetterTextIndicator = _contentLetterCounter;
            }

        }

        // LAYERS METHODS
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
}// end of main class

