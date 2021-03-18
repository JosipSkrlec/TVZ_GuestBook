using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartingSceneController : MonoBehaviour
{
    [SerializeField] private SQLManipulator _manipulator;

    [SerializeField] private GameObject _notePrefab;
    [SerializeField] private Transform _notePrefabContainer;

    [SerializeField] private float _spawnDelay = 0.1f;

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
            _spawnDelay += 0.1f;
            StartCoroutine(SpawnDelay(_spawnDelay, note.Username, note.Content));
        }


    }

    IEnumerator SpawnDelay(float seconds,string username, string content)
    {
        yield return new WaitForSeconds(seconds);

        GameObject noteGO = Instantiate(_notePrefab, _notePrefabContainer);

        NoteItem noteItem = noteGO.GetComponent<NoteItem>();

        noteItem.SetupNote(username, content, true);

    }


}


