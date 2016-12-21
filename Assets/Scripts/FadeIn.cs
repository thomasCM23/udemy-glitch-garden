using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeTime = 3f;
    private Image fadeImage;
    private Color currentColor;
    // Use this for initialization
    void Start()
    {
        currentColor = Color.black;
        fadeImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeTime)
        {
            float alphaChange = Time.deltaTime / fadeTime;
            currentColor.a -= alphaChange;
            fadeImage.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
