using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using System.IO;
using TMPro;


/// <summary>
/// This class is the manager of the system.
/// it allow us to open XMLs files and read them.
/// </summary>
public class LanguageManager : MonoBehaviour {

    //Those variables must be marked with "HideInInspector" due we want to dinamically show-hide them, this work is managed by "LanguageManagerEditor.cs".
    //Those variables contains the XML files as TextAssets. Those XMLs must be present in the "GAMEPROJECT_Data" when we build a project.
    [Header("Languages")]
    public static LanguageManager instance; //For the singleton pattern.

    public LanguageReader langReader { get; private set; } //We must have a LanguageReader inside our class to "strip the flesh off" of the XML.
    
    public string currentLanguage = "English"; //This variable will contain as a string the current language that we've selected

    public delegate void LanguageChange();
    public static event LanguageChange OnLanguageChange;

    /// <summary>
    /// Singleton pattern
    /// At the start, by default we set the English language, the XML file took depends with the bool "isLocal"
    /// </summary>
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            OpenLocalXML(currentLanguage);
        } else {
            DestroyImmediate(gameObject);
        }
    }

    private void Start() {
        SelectLanguage("English");
    }

    /// <summary>
    /// This function allow us to open a XML file stored on the computer, in the GAMENAME_Data folder created by the unity build.
    /// </summary>
    public void OpenLocalXML(string language) {
        //We're opening a file, so we reset all the states of this script
        langReader = null;
        currentLanguage = null;

        //Switch for the "Language" (as parameter), foreach language present in the game we have a different name file, but the location of those is the same.
        //Despite from the Web opening, here we instantiate the LanguageReader instantaniely, because the file must be not loaded from the web cause we've got it on the hard-disk.
        switch (language) {
            case "English":
                langReader = new LanguageReader(Resources.Load("Lang/ENG") as TextAsset, "English");
                break;
            case "Espanol":
                langReader = new LanguageReader(Resources.Load("Lang/ESP") as TextAsset, "Espanol");
                break;
            case "German":
                langReader = new LanguageReader(Resources.Load("Lang/GER") as TextAsset, "German");
                break;
            case "French":
                langReader = new LanguageReader(Resources.Load("Lang/FRA") as TextAsset, "French");
                break;
            case "Portuguese":
                langReader = new LanguageReader(Resources.Load("Lang/POR") as TextAsset, "Portuguese");
                break;
            case "Chinese":
                langReader = new LanguageReader(Resources.Load("Lang/CHI") as TextAsset, "Chinese");
                break;
            case "Italian":
                langReader = new LanguageReader(Resources.Load("Lang/ITA") as TextAsset, "Italian");
                break;
            case "Russian":
                langReader = new LanguageReader(Resources.Load("Lang/RUS") as TextAsset, "Russian");
                break;
            default:
#if UNITY_EDITOR
                Debug.LogWarning("This language doesn't exist: " + language);
#endif
                langReader = new LanguageReader(Resources.Load("Lang/ENG") as TextAsset, "English");
                break;
        }

        currentLanguage = language;
        if (OnLanguageChange != null) {
            OnLanguageChange();
        }
    }

    /// <summary>
    /// This function will allow us to change the language of the game.
    /// </summary>
    public void SelectLanguage(string language) {
        if (language != currentLanguage) { //If we are not selecting the same language we have right now
            OpenLocalXML(language); //we open locally
        }

    }

    public void SetLanguage(TMP_Dropdown dropdown) 
    {
        Debug.Log(dropdown.options[dropdown.value].text);
        switch(dropdown.options[dropdown.value].text) 
        {
            case "En":
                SelectLanguage("English");
                break;
            case "Ru":
                SelectLanguage("Russian");
                break;
            default:
                SelectLanguage("English");
                break;
        }
        Debug.Log(langReader);
    }
}
