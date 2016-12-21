using UnityEngine;
using System.Collections;

public class Gravestone : MonoBehaviour {
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Attacker>())
        {
            anim.SetTrigger("UnderAttackTrigger");
        }
    }
}
