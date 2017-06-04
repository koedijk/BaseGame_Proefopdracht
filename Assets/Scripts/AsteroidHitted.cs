using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHitted : MonoBehaviour
{

    private SpawnAsteroid _spawnAsteroid;
	// Use this for initialization
	void Awake ()
	{
	    _spawnAsteroid = GameObject.FindGameObjectWithTag("AsteroidControl").GetComponent<SpawnAsteroid>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll);
        if (coll.collider.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            _spawnAsteroid.PlayAudio();
            Destroy(gameObject);
        }
    }
}
