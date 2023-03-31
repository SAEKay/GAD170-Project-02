using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KayBarhoum
{
    public class EnemySpawner : MonoBehaviour
    {

        public GameObject enemyPrefab; //the enemy prefab to spawn
        public float spawnChance = 0.5f; // the chance of spawning an enemy at each spawn point
        private List<GameObject> spawnPoints; //the collection of spwn points
        private List<GameObject> spawnedEnemies; // the collection of spawned enemies

        void Start()
        {
            spawnPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("EnemySpawnPoint"));
            spawnedEnemies = new List<GameObject>();

            foreach (GameObject spawnPoint in spawnPoints)
            {
                if (Random.value < spawnChance)
                {
                    GameObject enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                    spawnedEnemies.Add(enemy);
                }
            }

            Debug.Log("Spawned " + spawnedEnemies.Count + " enemies.");


        }
   
       
  
    }

}
