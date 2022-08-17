using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UIDownloadMode : MonoBehaviour
{
    bool isLoading = false;

    string filepath;

    string downloadlink;

    private void Start() {
        StartDownload();
    }

    public void StartDownload() 
    {
        filepath = DownloadManager.Instance.filepath;
        downloadlink = DownloadManager.Instance.downloadlink;
    }

    private void Update() {
        if (!AdsManager.Instance.isPlay && !isLoading) StartCoroutine("DownloadFromResources");
    }

    void OnDisable() 
    {
        isLoading = false;
    }

    //just for check download
    public IEnumerator DownloadFromResources() 
    {
        isLoading = true;
        yield return null;
        Debug.Log("start download");

        var db = Resources.Load<TextAsset>("Modes/dragonmounts/example");

        byte[] data = db.bytes;

        //System.IO.File.WriteAllBytes(filepath, data);

        //System.IO.Path.Combine(filepath, "example.txt");
    }

    public IEnumerator DownloadFromURL()
    {
        Debug.Log("start download");

        //Download
            UnityWebRequest dlreq = new UnityWebRequest(downloadlink);
            dlreq.downloadHandler = new DownloadHandlerFile(filepath);
 
 
            UnityWebRequestAsyncOperation op = dlreq.SendWebRequest();
 
            while (!op.isDone)
            {
                //here you can see download progress
                Debug.Log(dlreq.downloadedBytes / 1000 + "KB");
 
            yield return null;
            }
 
            if (dlreq.isNetworkError || dlreq.isHttpError)
            {
                Debug.Log(dlreq.error);
            }
            else
            {
                Debug.Log("download success");
            }
 
            dlreq.Dispose();
 
            yield return null;
    }
}
