using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
    [Range (-1f, 1.5f)]
    public float currentSpeed;
    private GameObject currentTarget;
    private Animator anim;
    public float seenEverySeconds;

    // Use this for initialization
    void Start ()
    {
        Rigidbody2D myrb = gameObject.AddComponent<Rigidbody2D>();
        myrb.isKinematic = true;
        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if(!currentTarget)
        {
            anim.SetBool("IsAttacking", false); 
        }
	}
    
    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void StrikeCurrentTarget(float damage)
    {
        
        if(currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if(health)
            {
                health.DealDamage(damage);
            }
        }

    }
    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
