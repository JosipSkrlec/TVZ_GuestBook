using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartingSceneController : MonoBehaviour
{
    [SerializeField] private SQLManipulator _manipulator;
    
    [SerializeField] private GameObject _notePrefab;
    [SerializeField] private Transform _notePrefabContainer;


    private List<Note> notesFromDatabase;

    private void Start()
    {
        SetUpNotes();

    }

    public void SetUpNotes()
    {
        notesFromDatabase = _manipulator.GetNotes();

        foreach (Note note in notesFromDatabase)
        {
            Debug.Log(note.id);

            GameObject noteGO = Instantiate(_notePrefab,_notePrefabContainer);

            TMP_Text noteContentText = noteGO.transform.Find("NoteContentText").GetComponent<TMP_Text>();
            noteContentText.text = note.Content;

            TMP_Text noteUsernameText = noteGO.transform.Find("NoteUsernameText").GetComponent<TMP_Text>();
            noteUsernameText.text = note.Username;

        }


    }


}
