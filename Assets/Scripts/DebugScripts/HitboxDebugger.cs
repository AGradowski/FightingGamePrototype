using UnityEngine;

public class HitboxDebugger : HitBoxDebuggerParent
{
    private AttackDataObject attack;
    //public SphereCollider scollider;
    public Material hitbox;
    [HideInInspector] GameObject sphere;

    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //GenerateVisualHitbox(attack);

        // scollider = gameObject.AddComponent<SphereCollider>();
        /// Physics.OverlapSphere(player.transform.position + attack.origin, attack.radius, player.targetCollisionLayer);
        //Object.
        //scollider.center = attack.origin;
        //scollider.radius = attack.radius;


        //scollider.isTrigger = true;


        //scollider.material = new Material(Shader.Find("Specular"));
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        /* sphere.transform.parent = null;

         sphere.transform.localScale = attack.radius * new Vector3(2f, 2f, 2f);
         sphere.transform.parent = gameObject.transform;
         //sphere.transform.localScale = scollider.transform.localScale;
         sphere.transform.localPosition = attack.origin;
         sphere.GetComponent<SphereCollider>().isTrigger = true;
         sphere.GetComponent<Renderer>().material = hitbox;
         //   collider.center = gameObject.transform.position + attack.origin;
         // collider.radius = attack.radius;*/

    }

    public override void GenerateVisualHitbox(AttackDataObject activeAttack)
    {

        base.GenerateVisualHitbox(activeAttack);
        attack = activeAttack;
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);//assume primitive is alwys radius 0.5


        sphere.transform.localScale = attack.radius * new Vector3(2f, 2f, 2f);

        //Physics.OverlapSphere(player.transform.position + attack.origin, attack.radius, player.targetCollisionLayer);
        sphere.transform.parent = gameObject.transform;
        //sphere.transform.localScale = scollider.transform.localScale;
        sphere.transform.position = player.transform.position + attack.origin;
        sphere.GetComponent<SphereCollider>().isTrigger = true;
        sphere.GetComponent<Renderer>().material = hitbox;




        /* sphere.transform.localScale = attack.radius * new Vector3(2f, 2f, 2f);
         sphere.transform.parent = gameObject.transform;
         sphere.transform.localPosition = attack.origin;
         sphere.GetComponent<SphereCollider>().isTrigger = true;
         sphere.GetComponent<Renderer>().material = hitbox;*/
    }

    public override void HideVisualHitbox()
    {
        base.HideVisualHitbox();
        attack = null;
        Destroy(sphere);

    }



}
