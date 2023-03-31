using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KayBarhoum
{
    public class Enemy : MonoBehaviour
    {

        public float moveSpeed = 2.0f; // the speed enemy moves at
        public float moveDistance = 3.0f; // the distance the enemy moves before turning around
        public bool isFacingRight = true; //whether enemy is initially faxcing right
        private bool isAtEdge = false; // whether the enemy is at the edge 

        public Animator animator; //animation component
        public AudioClip enemyDeathAudio; // the audio clip to play when the enemy dies
        public float deathDelay = 2.0f; // delay before destorying enemy prefab

        private Vector2 startingPosition;


        // Start is called before the first frame update
        private void Start()
        {
            startingPosition = transform.position;
        }


        private void Update()
        {
            //calculate the direction the enemy should move
            float direction = isFacingRight ? 1.0f : -1.0f;

            //move enemy in current direction
            transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

            // Chech if enemy at edge of platform
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f);
            if (hit.collider == null)
            {
                isAtEdge = true;
            }

            else
            {
                isAtEdge = false;
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // if enemy collides with something on its left or right, turn around
            if (collision.contacts[0].normal.x != 0)
            {
                isFacingRight = !isFacingRight;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // trigger the squashed animation and destroy the enemy
                animator.SetTrigger("Squashed");

                //play enemy death audio using PlayOneShot
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(enemyDeathAudio);

                //Destroy the enemy after delay
                Destroy(gameObject, deathDelay);

                //stop enemy from moving
                moveSpeed = 0.0f;
            }
        }
    }


}

