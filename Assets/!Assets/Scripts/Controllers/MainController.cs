using DG.Tweening;
using Keyboard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] private SQLManipulator _SqlManipulator;

    [SerializeField] private GameObject _notePrefab;
    [SerializeField] private Transform _notePrefabContainer;

    [SerializeField] private float _spawnDelay = 0.15f;

    private List<Note> notesFromDatabase;

    [SerializeField] private CanvasGroup _addNewNoteCanvas;

    [SerializeField] private GameObject _OSK;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        SetUpNotes();
    }

    public void SetUpNotes()
    {
        notesFromDatabase = _SqlManipulator.GetNotes();

        foreach (Note note in notesFromDatabase)
        {
            StartCoroutine(SpawnDelay(_spawnDelay, note.Username, note.Content,note.PinID));
            _spawnDelay += 0.15f;
        }
    }
    IEnumerator SpawnDelay(float seconds,string username, string content, int pinIndicator)
    {
        yield return new WaitForSeconds(seconds);

        GameObject noteGO = Instantiate(_notePrefab, _notePrefabContainer);

        NoteItem noteItem = noteGO.GetComponent<NoteItem>();

        noteItem.SetupNote(username, content, pinIndicator, true);

    }
    public void ShowNewNoteCanvas()
    {
        _OSK.GetComponent<OSK_NewNodeController>().Setup();
        _addNewNoteCanvas.DOFade(1.0f,1.5f).OnComplete(() => {
            _addNewNoteCanvas.interactable = true;
            _addNewNoteCanvas.blocksRaycasts = true;
        });

    }
}


