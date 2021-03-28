using UnityEngine;
using UnityEngine.UI;

public class ChangePin : MonoBehaviour
{
    [SerializeField] private GameObject _addNewNoteGO;

    [SerializeField] private Transform _pinParent;
    [SerializeField] private GameObject _pinPrefab;

    [SerializeField] int _pinID;

    public void ChangePinOnClick()
    {
        if (_pinParent.transform.childCount > 0)
        {
            Destroy((GameObject)_pinParent.transform.GetChild(0).gameObject);
        }

        GameObject go = Instantiate(_pinPrefab,_pinParent);
        go.GetComponent<RawImage>().texture = this.GetComponent<Image>().sprite.texture;

        _addNewNoteGO.GetComponent<AddNewNoteController>().SelectedPinID = _pinID;
    }
}
