using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour {

    public float totalTime = 100;
    Slider timer;
    private AudioSource au;
    private bool isEndOfLevel = false;
    private LevelManager lvlman;
    private GameObject winLabel;
	// Use this for initialization
	void Start () {
        timer = GetComponent<Slider>();
        au = GetComponent<AudioSource>();
        lvlman = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("YouWin");
        if(!winLabel)
        {
            Debug.LogWarning("No win label");
        }
        winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer.value = Time.timeSinceLevelLoad / totalTime;
        if(Time.timeSinceLevelLoad >= totalTime && !isEndOfLevel)
        {
            au.Play();
            winLabel.SetActive(true);
            foreach(GameObject i in GameObject.FindGameObjectsWithTag("DestroyOnWin"))
            {
                Destroy(i);
            }

            Invoke("LoadNextLevel", au.clip.length);

            isEndOfLevel = true;
        }
	}
    void LoadNextLevel()
    {
        print("Loading Next Level");
        lvlman.LoadNextLevel();
    }
}
