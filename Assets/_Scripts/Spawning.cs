using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Spawning : MonoBehaviour
{
    [SerializeField]private GameObject targetParent;
    private float timeRemaining;
    [Header("Spawning")]
    
    private int xPos;
    private int yPos;
    public float spawnRate;
    public bool gamePlaying {get; private set;}
    private bool isSpawning = false;
    public float spawnTime;
    private float displayCount;
    void Start()
    {
        spawnRate = 3.0f;
    }
    private void Update() {
        if (!isSpawning)
        {
            
            //StartCoroutine(Spawn());
            isSpawning = true;
        }
    }
    // IEnumerator SpawnEnemies(){
    //     // float pos_Y = Random.Range(min_Y, max_Y);
    //     // Vector3 temp = transform.position;
    //     // temp.y = pos_Y;
    //     // yield return new WaitForSeconds(timer);
    //     // if(Random.Range(0, 2) > 0){
    //     //     Instantiate(asteroid_Prefabs[Random.Range(0, asteroid_Prefabs.Length)],
    //     //     temp, Quaternion.identity);
    //     // }else{
    //     //     //Instantiate(enemyPrefabs, temp, Quaternion.Euler(0f, 0f, 90f));
    //     // }

    //     // Invoke("SpawnEnemies", timer);
        
        
    //     // Instantiate(asteroid_Prefabs[Random.Range(0, asteroid_Prefabs.Length)], 
    //     // temp,Quaternion.identity);
        
        

        
    // }
}
