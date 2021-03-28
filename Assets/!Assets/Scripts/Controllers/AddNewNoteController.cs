using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddNewNoteController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _addNewNoteCG;
    [Space(15)]
    [SerializeField] private TMP_InputField _usernameInputText;
    [SerializeField] private TMP_InputField _contentInputText;

    private string _noteUsername;
    private string _noteContent;

    private int _pinId;
    private int _fontId;

    public void CloseAddNewNodeCanvas()
    {
        _addNewNoteCG.DOFade(0.0f,1.5f).OnComplete(() =>
        {
            _addNewNoteCG.interactable = false;
            _addNewNoteCG.blocksRaycasts = false;
        });
    }

    public void AddNewNodeToDb()
    {
        if (InputIsNull() == true)
        {
            return;
        }
        else
        {
            _noteUsername = _usernameInputText.text;
            _noteContent = _contentInputText.text;


        }
    }

    private bool InputIsNull()
    {
        string username = _usernameInputText.text;
        string content = _contentInputText.text;

        if (string.IsNullOrEmpty(username))
        {
            return false;
        }
        else if (string.IsNullOrEmpty(content))
        {
            return false;
        }
        else
        {
            return true;
        }

    }

}
