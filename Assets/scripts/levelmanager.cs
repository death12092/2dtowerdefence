using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public levelmanager main;

    public Transform start;
    public transform[] path;

    private void Awake()
    {
        main = this
    }
}
