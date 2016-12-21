using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject DefenderParent;
    private StarDisplay starDisplay;
    // Use this for initialization
    void Start ()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        DefenderParent = GameObject.Find("Defender");
        if(!DefenderParent)
        {
            DefenderParent = new GameObject("Defender");
        }
	
	}

    void OnMouseDown()
    {
        Vector2 FlooredPos = SnapToGrid(CalculateWorldPointOfMouseClick());
        if (ButtonScript.selectedDefender)
        {
            if (starDisplay.UseStars(ButtonScript.selectedDefender.GetComponent<Defender>().StarCost) == StarDisplay.Status.SUCCESS) {
                GameObject newDef = Instantiate(ButtonScript.selectedDefender, FlooredPos, Quaternion.identity) as GameObject;
                newDef.transform.parent = DefenderParent.transform;
            }
        }
        
    }
    Vector2 SnapToGrid(Vector2 worldPos)
    {
        float x = Mathf.Round(worldPos.x);
        float y = Mathf.Round(worldPos.y);
        return new Vector2(x, y);
    }
    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;
        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }
}
