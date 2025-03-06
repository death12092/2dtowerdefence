using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public static levelmanager main;

    public Transform start;
    public Transform[] path;

    private void Awake()
    {
        main = this;
    }
}
