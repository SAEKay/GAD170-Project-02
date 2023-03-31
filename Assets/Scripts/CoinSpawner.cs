using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KayBarhoum
{


    public class CoinSpawner : MonoBehaviour
    {


        public GameObject coinPrefab;
        public float yOffset = 0.5f;
        public int maxCoins = 3;

        private int coinsSpawned = 0; 
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player") && coinsSpawned < maxCoins)
            {
                Vector2 spawnPosition = (Vector2)transform.position + new Vector2(0f, yOffset);
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

                GameObject playerObject = GameObject.FindWithTag("Player");
                if (playerObject != null)
                {
                    PlayerScore playerScore = playerObject.GetComponent<PlayerScore>();
                    if(playerScore != null)
                    {
                        playerScore.CoinCollected();
                    }
                }

                coinsSpawned++;
                if (coinsSpawned >= maxCoins)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        
    }
}

