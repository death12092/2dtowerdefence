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
        sr.color = hovercolor;
    }
    private void OnMouseExit()
    {
        sr.color = startcolor;
    }
    private void OnMouseDown()
    {
        if (tower != null)
        {
            return;
        }

        GameObject towertobuild = buildmanager.main.getselectedtower();
        tower = Insantiate(towertobuild, transform.position, quaternion.identity);
    }
}
