using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteDetails : MonoBehaviour
{
    private GameObject _nodeDetailParent;
    private CanvasGroup _nodeDetailParentCG;

    private void Start()
    {
        _nodeDetailParent = GameObject.Find("NodeDetailPanel");
        _nodeDetailParentCG = _nodeDetailParent.GetComponent<CanvasGroup>();

    }

    public void ShowNoteDetailsOnClick()
    {
        if (_nodeDetailParent.transform.childCount > 0)
        {
            Destroy((GameObject)_nodeDetailParent.transform.GetChild(0).gameObject);
        }

        _nodeDetailParentCG.DOFade(1.0f, 1.0f);
        _nodeDetailParentCG.blocksRaycasts = true;
        _nodeDetailParentCG.interactable = true;


        //GameObject go= Instantiate(this.gameObject, _nodeDetailParent.transform,true);

        //GameObject go = Instantiate(this.gameObject, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, _nodeDetailParent.transform);
        GameObject go = GameObject.Instantiate(this.gameObject, _nodeDetailParentCG.transform,false);
        //go.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        //go.transform.position = _nodeDetailParentCG.transform.parent.position;

        // disable all components inside of game object
        MonoBehaviour[] comps = go.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
        {
            c.enabled = false;
        }

        Transform textGOParent = go.transform.Find("Text");
        textGOParent.GetChild(0).GetComponent<TMP_Text>().fontSize = 10;
        textGOParent.GetChild(1).GetComponent<TMP_Text>().fontSize = 10;

        RectTransform rt = go.GetComponent<RectTransform>();
        rt.DOAnchorPos(new Vector2(530.0f,-300.0f),1.5f);
        rt.DOScale(new Vector3(3.0f, 3.0f, 1.0f), 1.5f);
    }

    public void HideNoteDetailsOnClick()
    {
        if (_nodeDetailParent.transform.childCount > 0)
        {
            Destroy((GameObject)_nodeDetailParent.transform.GetChild(0).gameObject);
        }
        _nodeDetailParentCG.DOFade(0.0f, 1.0f);
        _nodeDetailParentCG.blocksRaycasts = false;
        _nodeDetailParentCG.interactable = false;
    }
   
}
