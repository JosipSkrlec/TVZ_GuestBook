using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _noteUsernameTitle;
    [SerializeField] private TMP_Text _noteContent;
    [SerializeField] private RawImage _pinImage;

    [SerializeField] private Vector2 _randomRotation;

    [SerializeField] private Texture2D[] Pins;
    private Sequence mySequence;

    //this.gameObject.GetComponent<RectTransform>().DOShakeAnchorPos(0.15f, 5.0f, 2, 10.0f, false, false);
    private void Awake()
    {
         mySequence = DOTween.Sequence();
        this.gameObject.GetComponent<RectTransform>().DOScale(1.4f,0.1f);
        mySequence.Append(_pinImage.transform.DOScale(1.7f, 0.15f));
        this.gameObject.GetComponent<RectTransform>().DOScale(1.0f, 0.25f);
        mySequence.Append(_pinImage.transform.DOScale(1.0f, 0.15f)).SetDelay(0.15f);       
        mySequence.Pause();

    }

    private void OnEnable()
    {
        mySequence.Play();

    }

    public void SetupNote(string noteUsername, string noteContent,int pinIndicator, bool randomSpawn)
    {
        _noteUsernameTitle.text = noteUsername;
        _noteContent.text = noteContent;

        if (_randomRotation.x ==0 && _randomRotation.y ==0) {

            _randomRotation.x = -5.0f;
            _randomRotation.y = -5.0f;
        }

        if (randomSpawn)
        {
            float randomNumber = Random.Range(_randomRotation.x, _randomRotation.y);

            this.gameObject.transform.eulerAngles = new Vector3(0.0f,0.0f, randomNumber);
        }

        if (pinIndicator < Pins.Length)
        {
            _pinImage.texture = Pins[pinIndicator];
        }
        else{
            int maxPinsTextures = Pins.Length;
            int randomNumberForPin = Random.Range(0,maxPinsTextures);
            _pinImage.texture = Pins[randomNumberForPin];
        }


    }




}
