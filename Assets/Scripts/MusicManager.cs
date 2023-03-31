using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KayBarhoum
{

    [System.Serializable]
    public class MusicTrack
    {
        public string trackName;
        public AudioClip audioClip;
    }
    public class MusicManager : MonoBehaviour
    {
        public List<MusicTrack> musicTracks;
        private AudioSource audioSource;
        private int currentTrackIndex;

        private void Awake()
        {

            audioSource = GetComponent<AudioSource>();
            currentTrackIndex = 0;

        }

        // Start is called before the first frame update
        void Start()
        {
            audioSource.clip = musicTracks[currentTrackIndex].audioClip;
            audioSource.Play();

        }

        public void PlayTrack(int trackIndex)
        {
            currentTrackIndex = trackIndex;
            audioSource.Stop();
            audioSource.clip = musicTracks[currentTrackIndex].audioClip;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }


}
