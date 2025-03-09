using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class enemymovement : MonoBehaviour
{
    [Header("references")]
    [SerializeField] private Rigidbody2D rb;

    [Header("attributes")]
    [SerializeField] private float movespeed = 2f;

    private Transform target;
    private int pathindex = 0;

    public float Movespeed { get => movespeed; set => movespeed = value; }

    private void Start()
    {

        target = levelmanager.main.path[pathindex];

    }
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f){
            pathindex++;
            

                if (pathindex == levelmanager.main.path.Length)
                {
                spawner.onenemydestroy.Invoke();
                Destroy(gameObject);
                return;
                }
            else
            {
                target = levelmanager.main.path[pathindex];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - this.transform.position).normalized;

        rb.velocity = direction * movespeed;

    }
}
