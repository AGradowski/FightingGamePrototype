using UnityEngine;
using System.Collections.Generic;

public class HitBoxDebuggerParent : MonoBehaviour
{
    //TODO - create a child for debug and non debugg use (with emmpty functions etc.), this class to work as interface

    public AttackDataObject attack;
    //public SphereCollider scollider;
    public Material hitbox;
    GameObject sphere;
    Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();

        // scollider = gameObject.AddComponent<SphereCollider>();
        /// Physics.OverlapSphere(player.transform.position + attack.origin, attack.radius, player.targetCollisionLayer);
        //Object.
        //scollider.center = attack.origin;
        //scollider.radius = attack.radius;


        //scollider.isTrigger = true;

        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);//assume primitive is alwys radius 0.5


        sphere.transform.localScale = attack.radius * new Vector3(2f, 2f, 2f);
        sphere.transform.parent = gameObject.transform;
        //sphere.transform.localScale = scollider.transform.localScale;
        sphere.transform.localPosition = attack.origin;
        sphere.GetComponent<SphereCollider>().isTrigger = true;
        sphere.GetComponent<Renderer>().material = hitbox;
        //scollider.material = new Material(Shader.Find("Specular"));
    }

    // Update is called once per frame
    void Update()
    {

        sphere.transform.parent = null;

        sphere.transform.localScale = attack.radius * new Vector3(2f, 2f, 2f);
        sphere.transform.parent = gameObject.transform;
        //sphere.transform.localScale = scollider.transform.localScale;
        sphere.transform.localPosition = attack.origin;
        sphere.GetComponent<SphereCollider>().isTrigger = true;
        sphere.GetComponent<Renderer>().material = hitbox;
        //   collider.center = gameObject.transform.position + attack.origin;
        // collider.radius = attack.radius;

    }
}
