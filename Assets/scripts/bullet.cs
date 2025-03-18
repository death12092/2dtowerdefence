using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    private Transform target;
    [Header("references")]
    [SerializeField] private Rigidbody2D rb;
    
    
    [Header("attributes")]
    [SerializeField] private float bulletspeed = 5f;
    [SerializeField] private int bulletdamage = 1;
    public void settarget(Transform _target)
    {
        target = _target;

    }
    
    
    
    private void FixedUpdate()
    {
        if(!target) return;
        Vector2 direction = (target.position - transform.position).normalized;
        
        rb.velocity = direction * bulletspeed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<health>().Takedamage(bulletdamage);
        Destroy(gameObject);
    }


}
