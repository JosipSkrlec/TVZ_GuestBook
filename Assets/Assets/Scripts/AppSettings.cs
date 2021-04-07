using UnityEngine;

/// <summary>
/// Init Script(poziva se jednom na pocetku i postavlja neke osnovne opcije aplikacije)
/// </summary>
public class AppSettings : MonoBehaviour
{
    private void Awake()
    {
<<<<<<< HEAD:Assets/Assets/Scripts/AppSettings.cs
        Screen.SetResolution(1080, 1920, true, 60);
        //Screen.fullScreen = false;
=======

        //Set screen size for Standalone
//#if UNITY_STANDALONE
//        Screen.SetResolution(1080, 1920, true);
//        Screen.fullScreen = true;
//#endif


>>>>>>> 273b009a721912bbd9dd69b50fee0ce14625162f:Assets/!Assets/Scripts/AppSettings.cs
    }

}
