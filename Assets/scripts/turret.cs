using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class turret : MonoBehaviour
{

    [Header("references")]
    [SerializeField] private Transform rotationpoint;
    [SerializeField] private LayerMask enemymask;
    
    [Header("atribute")]
    [SerializeField] private float targetingrange = 5f;

    private Transform target;

    private void Update()
    {
        if (target == null)
        {
            findtarget();
            return;
        }
        rotatetawardstarget();
        if (!checktargetisinrange())
        {
            target = null;
        }
    }
        private void findtarget()
    { 
        Debug.Log("working");
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingrange, (Vector2)transform.position, 0f, enemymask);
        if (hits.Length > 0) { 
            target = hits[0].transform;
            
        }
    }

    private bool checktargetisinrange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingrange;
    }
    private void rotatetawardstarget()
    {
        Debug.Log("working2");
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetrotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        rotationpoint.rotation = targetrotation;
    }

    private void OnDrawGizmosSelected()
    {
        
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingrange);

    }

}
