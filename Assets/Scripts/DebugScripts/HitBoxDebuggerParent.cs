using UnityEngine;
using System.Collections.Generic;

public class HitBoxDebuggerParent : MonoBehaviour
{
    //TODO - create a child for debug and non debugg use (with emmpty functions etc.), this class to work as interface

    //public AttackDataObject attack;
    //public SphereCollider scollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        player = GetComponent<Player>();


        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);//assume primitive is alwys radius 0.5


        sphere.transform.localScale = attack.radius * new Vector3(2f, 2f, 2f);
        sphere.transform.parent = gameObject.transform;
        sphere.transform.localPosition = attack.origin;
        sphere.GetComponent<SphereCollider>().isTrigger = true;
        sphere.GetComponent<Renderer>().material = hitbox;
    
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        sphere.transform.parent = null;

        sphere.transform.localScale = attack.radius * new Vector3(2f, 2f, 2f);
        sphere.transform.parent = gameObject.transform;
        //sphere.transform.localScale = scollider.transform.localScale;
        sphere.transform.localPosition = attack.origin;
        sphere.GetComponent<SphereCollider>().isTrigger = true;
        sphere.GetComponent<Renderer>().material = hitbox;
        //   collider.center = gameObject.transform.position + attack.origin;
        // collider.radius = attack.radius;
        */

    }

    public virtual void GenerateVisualHitbox(AttackDataObject activeAttack)
    {

    }

    public virtual void HideVisualHitbox()
    {

    }

}
