using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class plot : MonoBehaviour
{
    [Header("references")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hovercolor;

    private GameObject tower;
    private Color startcolor;
    private void Start()
    {
        startcolor = sr.color;
    }

    private void OnMouseEnter()
    {
        Debug.Log("hover");
        sr.color = hovercolor;
    }
    private void OnMouseExit()
    {
        Debug.Log("no hover");
        sr.color = startcolor;
    }
    private void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("no tower");
            return;
        }

        Debug.Log("tower");
        GameObject towertobuild = buildmanager.main.getselectedtower();
        tower = Instantiate(towertobuild, transform.position, quaternion.identity);
    }
}
