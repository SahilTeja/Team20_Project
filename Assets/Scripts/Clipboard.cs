using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour
{

    private GameObject selection;
    private bool copyMode = true;

    public void Copy(GameObject obj)
    {
        selection = obj;
    }

    public GameObject Paste()
    {
        return selection;
    }

    public bool isCopy()
    {
        return copyMode;
    }

    public void setCopy(bool b)
    {
        copyMode = b;
    }
}
