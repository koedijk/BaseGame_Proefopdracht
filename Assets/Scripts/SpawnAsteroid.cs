using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    private const int _maxAsteroids = 5;
    private int _CurrentAsteroids = 0;
    private AudioSource _audioSource;
    private AudioClip _audioClip;

    [SerializeField]
    private GameObject _asteroidObj;
	// Use this for initialization
	void Awake ()
	{
	    _audioSource = GetComponent<AudioSource>();
	    _audioClip = Resources.Load("Audio/AsteroidSound")as AudioClip;
		_asteroidObj = Resources.Load("Prefabs/Asteroid") as GameObject;
	    StartCoroutine(RandomSpawn());
	}
	
	// Update is called once per frame
	void Start () {
	    if (_maxAsteroids < _CurrentAsteroids)
	    {
	        StartCoroutine(RandomSpawn());
	    }
	}

    void SpawnAst()
    {
        if (_maxAsteroids > _CurrentAsteroids)
        {
            Vector2 a = new Vector2(Random.Range(-7.2f, 7.2f), Random.Range(-2, 5.2f));
            Instantiate(_asteroidObj, a, Quaternion.identity);
            _CurrentAsteroids++;
            StartCoroutine(RandomSpawn());
        }
        else
        {
            StartCoroutine(RandomSpawn());
        }
    }

    IEnumerator RandomSpawn()
    {
        yield return new WaitForSeconds(Random.Range(1,3));
        SpawnAst();
    }

    public void PlayAudio()
    {
        _audioSource.PlayOneShot(_audioClip,0.2f);
    }
}
