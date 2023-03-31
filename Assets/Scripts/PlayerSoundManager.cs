using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace KayBarhoum
{
    public class PlayerSoundManager : MonoBehaviour
    {
        public List <AudioClip> soundEffects = new List<AudioClip>();

        private AudioSource audioSource;
        
       private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayerSoundEffect (int index)
        {
            if(index < 0 || index >+soundEffects.Count)
            {
                Debug.LogWarning("Sound effect index out of range" + index);
                return;
            }
            audioSource.clip = soundEffects[index];
            audioSource.Play();
        }

        public void PlayerJumpSound ()
        {
            PlayerSoundEffect(0);
        }
        
        public void PlayerDeathSound()
        {
            PlayerSoundEffect(1);
        }
    }

}
