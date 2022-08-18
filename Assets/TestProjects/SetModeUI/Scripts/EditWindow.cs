using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditWindow : MonoBehaviour
{
    void Start() {
        Load();
    }
    void OnEnable() {
        Open();
    }
    void OnDisable() {
        Close();
    }
    public virtual void Load() {}
    public virtual void Open() {}
    public virtual void Close() {}
}
