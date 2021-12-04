using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    protected bool isOpen;
    public bool IsOpen { get => isOpen; }


    public abstract void Open();
    public abstract void Close();
}