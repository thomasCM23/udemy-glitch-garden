using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float totalHealth = 100f;
     
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DealDamage(float damage)
    {
        totalHealth -= damage;
        if(totalHealth <= 0)
        {
            DestroyObjectHealth();
        }
    }
    public void DestroyObjectHealth()
    {
        Destroy(gameObject);
    }
}
