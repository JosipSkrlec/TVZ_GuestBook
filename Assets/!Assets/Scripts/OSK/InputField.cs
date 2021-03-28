using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Keyboard
{
    public class InputField : MonoBehaviour
    {
        private TMP_Text _text;
        [SerializeField] private GameObject _caretPrefab;
        private GameObject _caretInstance;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _caretInstance = Instantiate(_caretPrefab, transform.parent);
        }

        public void Focus()
        {
            StartCoroutine(Blink());
        }

        public void UnFocus()
        {
            StopAllCoroutines();
            _caretInstance.SetActive(false);
        }

        private IEnumerator Blink()
        {
            while (true)
            {
                yield return new WaitForSeconds(.5f);
                if(_text.textInfo.characterCount > 0)
                {
                    var x = _text.textInfo.characterInfo[_text.textInfo.characterCount - 1].bottomRight.x;
                    var y = transform.localPosition.y - transform.GetComponent<RectTransform>().rect.height;
                    _caretInstance.transform.localPosition = new Vector2(x, y);
                    _caretInstance.SetActive(true);
                }
                yield return new WaitForSeconds(.5f);
                _caretInstance.SetActive(false);
            }
        }

        public void Append(string value)
        {
            _text.text += value;
            _caretInstance.SetActive(false);
        }

        internal void Execute(KeyCode code)
        {
            if (code == KeyCode.Delete && _text.text.Length > 0)
                _text.text = _text.text.Remove(_text.text.Length - 1);
            else if (code == KeyCode.Space)
                _text.text += " ";
            else if (code == KeyCode.Enter){
                //Focus next input field
            }
            _caretInstance.SetActive(false);
        }
    }
}

