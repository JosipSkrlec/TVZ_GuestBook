using DG.Tweening;
using Keyboard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance;
        
    [SerializeField] private float _spawnDelay;
    [SerializeField] private bool _showNotesAscending;

    [SerializeField] private SQLManipulator _SqlManipulator;

    [SerializeField] private GameObject _notePrefab;
    [SerializeField] private Transform _notePrefabContainer;


    private List<Note> notesFromDatabase;
    private List<GameObject> notesFromDatabaseGO;

    [SerializeField] private CanvasGroup _addNewNoteCanvas;

    [SerializeField] private GameObject _OSK;

    protected bool _isAuthorizedLikeAdmin = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        notesFromDatabaseGO = new List<GameObject>();

        SetUpNotes();
    }

    public void SetUpNotes()
    {
        _spawnDelay = 0.15f;

        if (notesFromDatabase != null)
        {
            foreach (Transform go in _notePrefabContainer)
            {
                Destroy(go.gameObject);
            }
            notesFromDatabase.Clear();
        }


        _SqlManipulator.SaveNotesToList();
        notesFromDatabase = _SqlManipulator.GetNotes();

        // show notes in Ascending mode A-Z
        if (_showNotesAscending)
        {
            foreach (Note note in notesFromDatabase)
            {
                StartCoroutine(SpawnNoteWithDelay(_spawnDelay,note.id, note.Username, note.Content, note.PinID));
                _spawnDelay += 0.15f;
            }
        }
        // show Notes in Descending mode Ž-A
        else
        {
            Note note;
            for (int x = notesFromDatabase.Count - 1; x != -1; x--)
            {
                note = notesFromDatabase[x];
                StartCoroutine(SpawnNoteWithDelay(_spawnDelay,note.id, note.Username, note.Content, note.PinID));
                _spawnDelay += 0.15f;
            }
        }
    }
    IEnumerator SpawnNoteWithDelay(float seconds,int ID, string username, string content, int pinIndicator)
    {
        yield return new WaitForSeconds(seconds);

        GameObject noteGO = Instantiate(_notePrefab, _notePrefabContainer);

        if (_isAuthorizedLikeAdmin)
        {
            noteGO.transform.GetChild(noteGO.transform.childCount - 1).gameObject.SetActive(true);
        }

        NoteItem noteItem = noteGO.GetComponent<NoteItem>();

        noteItem.SetupNote(ID,username, content, pinIndicator, true);

        notesFromDatabaseGO.Add(noteGO);

    }
    public void ShowNewNoteCanvas()
    {
        _OSK.GetComponent<OSK_NewNodeController>().Setup();

        _addNewNoteCanvas.DOFade(1.0f, 1.0f);
        _addNewNoteCanvas.interactable = true;
        _addNewNoteCanvas.blocksRaycasts = true;

    }

    public void SetAdminAuthorization(bool AuthorizationFlag)
    {
        _isAuthorizedLikeAdmin = AuthorizationFlag;
    }

}


