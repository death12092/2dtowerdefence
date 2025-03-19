using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class health : MonoBehaviour
{
    [SerializeField] private int hitpoints = 1;

    private bool isdestroyed = false;
    public void Takedamage(int dmg)
    {
        hitpoints -= dmg;

        if (hitpoints <= 0 && !isdestroyed)
        {
            spawner.onenemydestroy.Invoke();
            isdestroyed = true;
            Destroy(gameObject);
        }
    }
}