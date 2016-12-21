using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;
	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(gameObject);

	}
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }
	
	// Update is called once per frame
	void OnLevelWasLoaded (int level)
    {
        AudioClip clipToPlay = levelMusicChangeArray[level];
        if(clipToPlay)
        {
            audioSource.clip = clipToPlay;
            audioSource.loop = true;
            audioSource.Play();
        }
	}
    public void ChangeVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume;
    }
}
