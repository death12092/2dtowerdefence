using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class enemymovement : MonoBehaviour
{
    [header("references")]
    [serializefield] private ridgidbody2D rb;

    [header("attributes")]
    [serializefield] private float movespeed = 2f;

    private transform target;
    private int pathindex = 0;

    public float Movespeed { get => movespeed; set => movespeed = value; }

    private void Start()
    {

        target = levelmanager.main.path[pathindex];

    }
    private void Update()
    {
        if (vector2.distance(target.position, transform.postion) <= 0.1f{
            pathindex++;
            

                if (pathindex == levelmanager.main.path.length)
            {
                destroy(gameobject);
                return
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
