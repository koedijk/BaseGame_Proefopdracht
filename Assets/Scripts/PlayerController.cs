using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private Transform graphics;
    [SerializeField]
    private SkeletonAnimation[] skeletonAnimations;
    private Rigidbody2D rigid;

    private float x;

    void Awake()
    {
        graphics = transform;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        if (x > 0.2)
        {
            graphics.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if(x < 0.2)
        {
            graphics.localRotation = Quaternion.Euler(0,180,0);
        }
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(x,rigid.velocity.y);
    }

}
