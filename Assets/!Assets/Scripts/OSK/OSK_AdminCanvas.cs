using DG.Tweening;
using TMPro;
using UnityEngine;

// ADMIN PASSWORD IS = Admin123
public class OSK_AdminCanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup _lowercaseLayer;
    [SerializeField] private CanvasGroup _uppercaseLayer;
    [SerializeField] private CanvasGroup _numbersLayer;

    [Space(15)]
    [SerializeField] private TMP_InputField _adminTextInput;

    private CanvasGroup _currentLayer;

    [SerializeField] private CanvasGroup _adminCanvas;

    public void Setup()
    {
        ShowCanvasGroup(_lowercaseLayer);
        HideCanvasGroup(_uppercaseLayer);
        HideCanvasGroup(_numbersLayer);

        _adminTextInput.Select();
    }


    internal void SpecialKeyPress(KeyCode code)
    {
        if (KeyCode.Delete == code)
        {
            string stringtmp = _adminTextInput.text;
            if (stringtmp.Length > 0) // prevent of out ofrange exception
            {
                var value = stringtmp.Substring(0, stringtmp.Length - 1);
            }
        }
        if (KeyCode.Space == code)
        {
            _adminTextInput.text += " ";

        }
    }


    public void KeyPress(string value)
    {
        if (_adminTextInput.text.Length >= 10)
        {
            return;
        }
        _adminTextInput.text += value;
    }

    public void TextInputChanged()
    {
        string strTmp = _adminTextInput.text;
        Debug.Log(_adminTextInput.text + " " + strTmp);
        if (strTmp == "admin")
        {

            _adminCanvas.DOFade(0.0f, 1.0f);
            _adminCanvas.blocksRaycasts = false;
            _adminCanvas.interactable = false;           

            MainController.Instance.SetAdminAuthorization(true);
            MainController.Instance.SetUpNotes();

        }

    }

    public void CloseAdmin()
    {
        _adminCanvas.DOFade(0.0f, 1.0f);
        _adminCanvas.blocksRaycasts = false;
        _adminCanvas.interactable = false;
    }


    // LAYERS METHODS
    public void ShowLowercase()
    {
        ShowLayer(_lowercaseLayer);
    }
    public void ShowUppercase()
    {
        ShowLayer(_uppercaseLayer);
    }
    public void ShowNumbers()
    {
        ShowLayer(_numbersLayer);
    }
    private void ShowLayer(CanvasGroup layer)
    {
        HideCanvasGroup(_currentLayer);
        ShowCanvasGroup(layer);
    }
    private void HideCanvasGroup(CanvasGroup canvas)
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
    private void ShowCanvasGroup(CanvasGroup canvas)
    {
        _currentLayer = canvas;
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }


}

