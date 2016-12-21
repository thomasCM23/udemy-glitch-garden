using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start ()
    {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update ()
    {
        musicPlayer.ChangeVolume(volumeSlider.value);
	}
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("Start");
    }
    public void SetDefaults()
    {
        volumeSlider.value = .8f;
        difficultySlider.value = 2f;
    }
}
