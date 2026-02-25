using System.Collections; 
using UnityEngine;

public class enemiespawn : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    public GameObject[] enemiesPrefab;
    //public Transform spawnPosition; 
    //public Transform spawnPosition2;
    public Transform[] spawnPoints; 
    public int enemiesToSpawn = 5; 

void Awake()
{
    _boxCollider = GetComponent<BoxCollider2D>();
}

    IEnumerator SpawnEnemies()
    { 
        for (int i = 0; i < enemiesToSpawn; i++) //(Transform item in spawnPoints)
        { 
            //Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length)], item.position, Quaternion.identity);
        //}
        foreach (Transform item in spawnPoints)
        {            
            Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length)], item.position, Quaternion.identity);
        }
        yield return new WaitForSeconds (0.5f); 
    }
}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        { 
            _boxCollider.enabled = false;
            StartCoroutine(SpawnEnemies());
        }
    }
}





    //{
        //boxCollider=GetComponent(enemiesPrefab, spawnPosition.position, Quaternion.identity);
    //}

    //void OntriggerEnter2D(Collider2D collision)
    //{
        //if (collision.gameObject.CompareTag("Player"))
        //{
            //SpawnEnemies();
        //}  
