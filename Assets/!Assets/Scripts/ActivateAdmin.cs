using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateAdmin : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private TMP_Text _countdownText;
    [SerializeField] private float _timeToDisplayAdminPanel = 3.0f;
    [SerializeField] private CanvasGroup _adminPanel;

    [SerializeField] private GameObject _OSKAdmin;

    private bool isRacePressed = false;
    private float countingTime = 0.0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        countingTime = 0.0f;
        isRacePressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _countdownText.text = "";
        countingTime = 0.0f;
        isRacePressed = false;
    }

    void Update()
    {

        if (isRacePressed)
        {
            countingTime += Time.deltaTime;

            if (countingTime >= _timeToDisplayAdminPanel)
            {
                countingTime = 0.0f;
                _adminPanel.DOFade(1.0f,1.0f);
                _adminPanel.blocksRaycasts = true;
                _adminPanel.interactable = true;
            }

            _countdownText.text = countingTime.ToString();
        }
    }



}
