using UnityEngine;

public class HitboxDebugger : HitBoxDebuggerParent
{
    private AttackDataObject attack;
    public Material hitbox;
    [HideInInspector] GameObject sphere;

    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void GenerateVisualHitbox(AttackDataObject activeAttack)
    {

        base.GenerateVisualHitbox(activeAttack);
        attack = activeAttack;
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);//assume primitive is alwys radius 0.5
        sphere.transform.localScale = attack.radius * new Vector3(2f, 2f, 2f);
        sphere.transform.parent = gameObject.transform;
        sphere.transform.position = player.transform.position + attack.origin;
        sphere.GetComponent<SphereCollider>().isTrigger = true;
        sphere.GetComponent<Renderer>().material = hitbox;
    }

    public override void HideVisualHitbox()
    {
        base.HideVisualHitbox();
        attack = null;
        Destroy(sphere);

    }



}
