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
        [SerializeField] private OSK_NewNodeController _osk;
        [SerializeField] private OSK_AdminCanvas _osk1;

        [SerializeField] private KeyCode _code;

        public void OnPointerUp(PointerEventData eventData)
        {
            _osk1?.SpecialKeyPress((UnityEngine.KeyCode)_code);
            _osk?.SpecialKeyPress(_code);

        }
    }
}
