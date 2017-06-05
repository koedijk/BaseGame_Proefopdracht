using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    private LookAtMouse _mouse; 
    private AnimationsHolder _animationsHolder;

    private GameObject _player;
    private GameObject _MuzzleObj;
    private GameObject _ShoulderObj;
    private GameObject _bullet;
    private AudioSource _audioSource;
    private AudioClip _clip;

    private float _cooldown = 0.2f;
    private bool _canshoot = true;

    private Vector2 _muzzle;
    private Vector2 _shoulder;

    // Use this for initialization
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _MuzzleObj = GameObject.FindGameObjectWithTag("Muzzle");
        _ShoulderObj = GameObject.FindGameObjectWithTag("Shoulder");
        _bullet = Resources.Load("Prefabs/Plasma_Bullet")as GameObject;
        _animationsHolder = _player.GetComponent<AnimationsHolder>();
        _mouse = _player.GetComponent<LookAtMouse>();
        _audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        _clip = Resources.Load("Audio/Gunsound") as AudioClip;

    }

    // Update is called once per frame
	void Update ()
	{
	    _ShoulderObj.transform.position = new Vector2(_player.transform.position.x,_ShoulderObj.transform.position.y);
	    _ShoulderObj.transform.LookAt(_mouse._MousePos);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (_canshoot == true)
        {
            _canshoot = false;
            Vector3 pos = new Vector3(_MuzzleObj.transform.position.x, _MuzzleObj.transform.position.y);
            GameObject a = Instantiate(_bullet, pos, Quaternion.identity);
            if (_mouse.LookLeft == true)
            {
                Quaternion rot = new Quaternion(0, 0, -transform.rotation.w, transform.rotation.x);
                a.transform.rotation = rot;
            }
            else if (_mouse.LookLeft == false)
            {
                Quaternion rot = new Quaternion(0, 0, -transform.rotation.x, transform.rotation.w);
                a.transform.rotation = rot;
            }
            _audioSource.clip = _clip;
            _audioSource.Play();
            StartCoroutine(WaitForCooldown());

        }
    }

    IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(_cooldown);
        _canshoot = true;
    }
}
