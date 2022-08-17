using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadManager : MonoBehaviour
{
    public string filepath;

    public string downloadlink;

    public static DownloadManager instance;

    public static DownloadManager Instance 
    {
        get 
        {
            return instance;
        }
        private set {}
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        //filepath = Application.persistentDataPath;
        filepath = Application.dataPath;
    }
}
