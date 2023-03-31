using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering;
using Unity.PlasticSCM.Editor.WebApi;

namespace KayBarhoum
{

    public class PlayerLives : MonoBehaviour
    {
        public int startingLives = 3; // Number of player lives at start
        public TextMeshProUGUI livesText; //TextMeshProUGUI object for displaying lives
        public GameObject gameOverUI; // key for playersprefs

        private int currentLives; //current lives player has
        private string livesKey = "Lives"; //Key for player prefs


        
        void Start()
        {
            //load current lives from the player pregs or set to the starting live if not found
            if (PlayerPrefs.HasKey(livesKey))
            {
                currentLives = PlayerPrefs.GetInt(livesKey); 
            }
            else
            {
                currentLives = startingLives;
                PlayerPrefs.SetInt(livesKey, currentLives);
            }

            UpdateLivesText(); //update text to show current lives

        }

        
        void Update()
        {
            // if the game is over and the player hits space, reload the game
            if(gameOverUI.activeSelf && Input.GetKeyDown(KeyCode.Space))
            {
                // reload the scene
                Time.timeScale = 1f; //unpause game by setting time scale to 1
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }

        public void LoseALife()
        {
            currentLives--; //Decrease current lives by 1
            gameOverUI.SetActive(true);

            //Delete the playerprefs data for the lives key reset lives to staerting value
            PlayerPrefs.DeleteAll();
        }

        void UpdateLivesText()
        {
            livesText.text = "x " + currentLives;
        }
    }

   

}

