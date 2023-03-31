using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace KayBarhoum
{

public class Coin : MonoBehaviour
{

        public float coinMoveSpeed = 1.0f; //yaxis movement
        public float coinMovementHeight = 1.0f; // max height y axis
        public float destroyDelay = 1.0f; // delay before coin object is destoryed

        private Vector2 startPosition; //coin start pos

        public AudioClip coinHitSound; //sound whn coin hit
        private AudioSource audioSource; //audiosource component for playing sound

        private bool isMoving = true; // whether the coin is currently moving or not

  
    void Start()
    {
            startPosition = transform.position;
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(coinHitSound);

            Destroy(gameObject, destroyDelay);
 
    }

   
    void Update()
    {
            if (isMoving)
            {
                transform.position = new Vector2(startPosition.x, transform.position.y + coinMoveSpeed * Time.deltaTime);

                if (transform.position.y >= startPosition.y + coinMovementHeight)
                {
                    isMoving = false;
                }
            }
    }
}

}