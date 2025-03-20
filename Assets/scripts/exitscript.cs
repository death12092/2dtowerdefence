using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitscript : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("exit");
        Application.Quit();
    }
     
}
