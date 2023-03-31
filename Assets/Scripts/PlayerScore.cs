using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KayBarhoum
{
    public class PlayerScore : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public int startingScore = 0;

        private int currentScore;
        private string scoreKey = "Score";

        
        void Start()
        {
            
            if (PlayerPrefs.HasKey(scoreKey))
            {
                currentScore = PlayerPrefs.GetInt(scoreKey);
            }
            else
            {
                currentScore = startingScore;
                PlayerPrefs.SetInt(scoreKey, currentScore);
            }

            
        }

        public void CoinCollected()
        {
            currentScore++;
             
            PlayerPrefs.SetInt(scoreKey, currentScore);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void UpdateScoretext()
        {
            scoreText.text = ": " + currentScore.ToString();
        }


      

    }
    


}
