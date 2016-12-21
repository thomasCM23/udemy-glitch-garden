using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {
    public GameObject[] AttackerPrefab;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update ()
    {
	    foreach(GameObject i in AttackerPrefab)
        {
            if(IsTimeToSpawn(i))
            {
                Spawn(i);
            }
        }
	}
    bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker a = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = a.seenEverySeconds;
        float spawnPerSecond = 1 / meanSpawnDelay;
        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawnrate caped by framerate");
        }
        float threshold = spawnPerSecond * Time.deltaTime / 5;
        return Random.value < threshold;
       
    }
    void Spawn(GameObject attacker)
    {
        GameObject myAttacker = Instantiate(attacker) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }
}
