using UnityEngine;

/// <summary>
/// Init Script(poziva se jednom na pocetku i postavlja neke osnovne opcije aplikacije)
/// </summary>
public class AppSettings : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1080, 1920, true, 60);
        //Screen.fullScreen = false;
    }
}
