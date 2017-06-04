using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private Transform graphics;
    private AnimationsHolder _animHolder;
    private AudioSource _audioSource;
    private AudioClip _audioClip;
    private LookAtMouse _mouse;
    private Rigidbody2D rigid;
    private float x;

    void Awake()
    {
        _animHolder = GetComponent<AnimationsHolder>();
        _mouse = GetComponent<LookAtMouse>();
        graphics = transform;
        rigid = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _audioClip = Resources.Load("Audio/Footstep") as AudioClip;
        _audioSource.clip = _audioClip;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        if (Input.GetButton("Horizontal"))
        {
            _animHolder.ChangeAnimation("Run");
            if(!_audioSource.isPlaying)
            _audioSource.PlayOneShot(_audioClip);
        }
        else
        {
            _animHolder.ChangeAnimation("Idle");
        }
        _animHolder.GunRotate(_mouse.Angle);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(x,rigid.velocity.y);
    }
}
