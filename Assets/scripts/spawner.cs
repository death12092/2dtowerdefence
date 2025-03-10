using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class spawner : MonoBehaviour
{
    [Header("references")]
    [SerializeField] private GameObject[] enemyprefabs;

    
    [Header("attributes")]
    [SerializeField] private int baseenemies = 8;
    [SerializeField] private float enemiespersec = 0.5f;
    [SerializeField] private float timebetweenwaves = 5f;
    [SerializeField] private float scalingfactor = 0.75f;
    
    [Header("events")]
    public static UnityEvent onenemydestroy = new UnityEvent();

    private int currentwave = 1;
    private float timesincelastspawn;
    private int enemiesalive;
    private int enemieslefttospawn;
    private bool isspawning = false;

    private void Awake()
    {
        onenemydestroy.AddListener(enemydestroyed);
    }

    private void Start()
    {
        StartCoroutine(Getstartwave());
    }

    private void Update()
    {
        if (!isspawning) {
            return; 
        }
        timesincelastspawn = Time.deltaTime;
        
        if (timesincelastspawn >= (1f / enemiespersec) && enemieslefttospawn > 0)
        {
            
            spawnenemy();
            enemieslefttospawn--;
            enemiesalive++;
            timesincelastspawn = 0f;

        }

        if (enemiesalive ==0 && enemieslefttospawn == 0)
        {
            endwave();
        }
    }

    private void endwave()
    {
        isspawning = false;
        timesincelastspawn = 0f;
        currentwave++;
        StartCoroutine(Getstartwave());
    }

    private void spawnenemy()
    {
        Debug.Log("works");
        GameObject prefabtospawn = enemyprefabs[0];
        Instantiate(prefabtospawn, levelmanager.main.start.position, Quaternion.identity);
    }

    private void enemydestroyed()
    {
        enemiesalive--;
    }

    private IEnumerable Getstartwave()
    {
        yield return new WaitForSeconds(timebetweenwaves);

        isspawning = true;
        enemieslefttospawn = enemiesperwave();

    }

    private int enemiesperwave()
    {
        return Mathf.RoundToInt(baseenemies * Mathf.Pow(currentwave,scalingfactor));
    }
}
