using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinAnimation : MonoBehaviour
{
    [SerializeField] private RawImage _pinImage;

    private Sequence mySequence;

    private void Awake()
    {
        mySequence = DOTween.Sequence();
        mySequence.Append(_pinImage.transform.DOScale(1.7f, 0.0f));
        mySequence.Append(_pinImage.transform.DOScale(1.0f, 0.15f));
        mySequence.Pause();

    }

    private void OnEnable()
    {
        mySequence.Play();
    }
}
