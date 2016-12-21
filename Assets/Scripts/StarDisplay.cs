using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StarDisplay : MonoBehaviour {

    int totalStars = 100;
    Text text;
    public enum Status {SUCCESS, FAILURE}
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        UpdateDisplay();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddStars(int amount)
    {
        totalStars += amount;
        UpdateDisplay();
    }
    public Status UseStars(int amount)
    {
        if (totalStars >= amount)
        {
            totalStars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
    private void UpdateDisplay()
    {
        text.text = totalStars.ToString();
    }
}
