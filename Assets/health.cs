using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class health : MonoBehaviour
{
    [SerializeField] private int hitpoints = 1;

    public void Takedamage(int dmg)
    {
        hitpoints -= dmg;

        if (hitpoints <= 0)
        {
            spawner.onenemydestroy.Invoke();
            Destroy(gameObject);
        }
    }
}