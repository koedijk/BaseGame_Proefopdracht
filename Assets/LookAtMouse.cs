using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private AnimationsHolder _animHolder;
    private Vector3 _mouseWorldPosition;

    private float angle;

    public float Angle {
        get { return angle; }
        set {angle = value; }
    }

    // Use this for initialization
	void Start ()
	{
	    _animHolder = GetComponent<AnimationsHolder>();
	    _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
	    _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	    angle = AngleBetweenPoints(transform.position,_mouseWorldPosition);
	}

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
