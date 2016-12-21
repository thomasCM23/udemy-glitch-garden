using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
    private SpriteRenderer sr;
    private ButtonScript[] buttonArray;
    public static GameObject selectedDefender;
    public GameObject defenderPrefab;
    private Text CostText;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        buttonArray = GameObject.FindObjectsOfType<ButtonScript>();
        CostText = GetComponentInChildren<Text>();

        CostText.text = defenderPrefab.GetComponent<Defender>().StarCost.ToString();
    }

    void OnMouseDown()
    {
        foreach (ButtonScript i in buttonArray)
        {
            i.GetComponent<SpriteRenderer>().color = Color.black;
        }
        sr.color = Color.cyan;
        selectedDefender = defenderPrefab;
    }
}
