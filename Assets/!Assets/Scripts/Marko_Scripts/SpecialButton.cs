﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Keyboard
{
    public enum KeyCode
    {
        Delete,
        Space,
        Enter
    }

    public class SpecialButton : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private HR_OSK_Controller _osk;
        [SerializeField] private KeyCode _code;
        public void OnPointerUp(PointerEventData eventData)
        {
            _osk.SpecialKeyPress(_code);
        }
    }
}
