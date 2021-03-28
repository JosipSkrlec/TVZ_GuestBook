using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Keyboard
{

    public class CharacterButton : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private OSK_NewNodeController _osk;
        private string _character = "";

        private void Awake()
        {
            _character = gameObject.GetComponentInChildren<TMP_Text>()?.text;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _osk.KeyPress(_character);
        }
    }
}

