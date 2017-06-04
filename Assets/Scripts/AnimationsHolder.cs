using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Spine.Unity;


public class AnimationsHolder : MonoBehaviour
{
    [SerializeField]
    private List<SkeletonAnimation> _animations = new List<SkeletonAnimation>();
    [SerializeField]
    private Dictionary<string, SkeletonAnimation> _obj = new Dictionary<string, SkeletonAnimation>();
    // Use this for initialization
    void Start ()
    {
        //SkeletonAnimations added to list and sorted on name 
        _animations = GetComponentsInChildren<SkeletonAnimation>().OrderBy(go => go.name).ToList();
        //Add SkeletonAnimation to Dictionary and give it own name to it
        _obj.Add("Arm_L",_animations[0]);
        _obj.Add("Arm_R",_animations[1]);
        _obj.Add("Body", _animations[2]);
        _obj.Add("Head", _animations[3]); 
    }

    public float ShoulderPos()
    {
        float Y = 0;
        Y =_obj["Arm_L"].skeleton.FindBone("shouler").WorldY;
        return Y;
    }

    public void ChangeAnimation(string anim)
    {
        _obj["Body"].AnimationName = anim;
        _obj["Head"].AnimationName = anim;
    }

    public void GunRotate(float angle)
    {
        _obj["Arm_L"].skeleton.FindBone("shouler").Rotation = angle;
        _obj["Arm_R"].skeleton.FindBone("shouler").Rotation = angle;
    }

    public void PlayerRotate(bool rot)
    {
        if (rot)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void GunPos(Vector2 a)
    {
        a = new Vector2(_obj["Arm_R"].skeleton.FindBone("shoulder").x, _obj["Arm_R"].skeleton.FindBone("shoulder").y);
    }
}
