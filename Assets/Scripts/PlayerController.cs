using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private Transform graphics;
    private AnimationsHolder _animHolder;
    private LookAtMouse _mouse;
    private Rigidbody2D rigid;
    private float x;

    void Awake()
    {
        _animHolder = GetComponent<AnimationsHolder>();
        _mouse = GetComponent<LookAtMouse>();
        graphics = transform;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        if (Input.GetButton("Horizontal"))
        {
            _animHolder.ChangeAnimation("Run");
        }
        else
        {
            _animHolder.ChangeAnimation("Idle");
        }
        if (x > 0.3)
        {
            _animHolder.PlayerRotate(false);
        }
        else if (x < -0.3)
        {
            _animHolder.PlayerRotate(true);
            
        }
        _animHolder.GunRotate(_mouse.Angle);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(x,rigid.velocity.y);
    }
}
