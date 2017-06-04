using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
   
    private Vector2 _mousePos;
    public Vector2 _MousePos {
        get { return _mousePos; }
        set { }
    }



    private Vector2 playerPos;
    private Vector2 target;
    public bool LookLeft;
    private float angle;
    public float Angle
    {
        get { return angle; }
        set { angle = value; }
    }
    private AnimationsHolder _animHolder;
    private float _gunOffset = -23; 


    void Awake()
    {
        _animHolder = GetComponent<AnimationsHolder>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = transform.position;
        playerPos.y = playerPos.y + _animHolder.ShoulderPos();
        LookRotate(playerPos, _mousePos);
        _animHolder.PlayerRotate(LookLeft);
    }

    bool LookRotate(Vector2 a, Vector2 b)
    {
        if (b.x < a.x)
        {
            LookLeft = true;
            angle = _gunOffset + Mathf.Atan2(b.y - a.y, a.x - b.x) * 180 / Mathf.PI;

        }
        else if (b.x > a.x)
        {
            LookLeft = false;
            angle = _gunOffset + Mathf.Atan2(b.y - a.y, b.x - a.x) * 180 / Mathf.PI;
        }
        return LookLeft;
    }

    public float GunAngle()
    {
        Vector2 a = playerPos;
        Vector2 b = _mousePos;
        if (LookLeft)
        {
            angle = _gunOffset + Mathf.Atan2(b.y - a.y, b.x - a.x) * 180 / Mathf.PI;
        }
        else
        {
            angle = _gunOffset + Mathf.Atan2(b.y - a.y, b.x - a.x) * 180 / Mathf.PI;
        }
        return angle;
    }
}
