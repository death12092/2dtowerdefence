using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class enemymovement : MonoBehaviour
{
    [Header("references")]
    [SerializeField] private ridgidbody2D rb;

    [Header("attributes")]
    [SerializeField] private float movespeed = 2f;

    private Transform target;
    private int pathindex = 0;

    public float Movespeed { get => movespeed; set => movespeed = value; }

    private void Start()
    {

        Target = levelmanager.main.path[pathindex];

    }
    private void Update()
    {
        if (Vector2.Distance(Target.position, transform.postion) <= 0.1f){
            pathindex++;
            

                if (pathindex == levelmanager.main.path.length)
                {
                destroy(gameobject);
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
        vector2 direction = (target.postion - transform.postion).normalized;

        rb.velocity = direction * movespeed;

    }
}
