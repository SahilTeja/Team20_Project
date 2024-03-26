using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public bool DebugMode = false;
    public abstract void interact();
}
