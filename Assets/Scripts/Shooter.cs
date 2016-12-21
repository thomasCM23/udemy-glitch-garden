using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject gun;
    private GameObject projectileParent;
    private Animator anim;
    private AttackerSpawner myLaneSpawner;
    void Start()
    {
        anim = GameObject.FindObjectOfType<Animator>();
        SetMyLaneSpaner();
        projectileParent = GameObject.Find("Projectile");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectile");
        }
    }
    void Update()
    {
        if (IsAttackerAheadInLane())
        {
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }
    }
    void SetMyLaneSpaner()
    {
        foreach(AttackerSpawner i in GameObject.FindObjectsOfType<AttackerSpawner>())
        {
            if(i.transform.position.y == transform.position.y )
            {
                myLaneSpawner = i;
            }
        }
    }
    bool IsAttackerAheadInLane()
    {
        if(myLaneSpawner.transform.childCount > 0)
        {
            foreach(Transform i in myLaneSpawner.transform)
            {
                if(i.position.x > transform.position.x)
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }
    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
