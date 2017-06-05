using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const int speed = 5;
    private Rigidbody2D rigid;

    // Use this for initialization
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = transform.right * speed;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider)
        {
            Destroy(gameObject);
        }
    }
}
