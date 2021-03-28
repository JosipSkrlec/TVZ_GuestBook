﻿using DG.Tweening;
using TMPro;
using UnityEngine;

public class AddNewNoteController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _addNewNoteCG;
    [Space(15)]
    [SerializeField] private TMP_InputField _usernameInputText;
    [SerializeField] private TMP_InputField _contentInputText;

    [SerializeField] private MainController _mainController;

    private int _selectedPinID;
    public int SelectedPinID { get => _selectedPinID; set => _selectedPinID = value; }

    private string _noteUsername;
    private string _noteContent;

    private int _pinId;
    private int _fontId;

    private void Awake()
    {
        _pinId = 1;
        _fontId = 1;
    }


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
            Debug.Log("Adding new note to DB");
            _noteUsername = _usernameInputText.text;
            _noteContent = _contentInputText.text;

            _addNewNoteCG.DOFade(0.0f,1.5f).OnComplete(()=> {
                _addNewNoteCG.blocksRaycasts = false;
                _addNewNoteCG.interactable = true;
            });

            SQLManipulator.Instance.InsertNote(_noteUsername,_noteContent, _pinId, 1);

            _mainController.SetUpNotes();
        }
    }

    private bool InputIsNull()
    {
        string username = _usernameInputText.text;
        string content = _contentInputText.text;

        if (string.IsNullOrEmpty(username))
        {
            return true;
        }
        else if (string.IsNullOrEmpty(content))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
