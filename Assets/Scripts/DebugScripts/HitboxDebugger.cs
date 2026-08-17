using System.Collections.Generic;
using UnityEngine;

public class HitboxDebugger : HitBoxDebuggerParent
{
    public Material hitboxMaterial;
    private List<GameObject> debugHitboxes;

    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
        debugHitboxes = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void GenerateVisualSphereHitbox(HitBox hitbox)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);//assume primitive is alwys radius 0.5


        sphere.transform.localScale = hitbox.GetRadius() * new Vector3(2f, 2f, 2f);

        sphere.transform.parent = gameObject.transform;
        sphere.transform.position = hitbox.GetPositiion(player);
        sphere.GetComponent<SphereCollider>().isTrigger = true;
        sphere.GetComponent<Renderer>().material = hitboxMaterial;
        debugHitboxes.Add(sphere);

    }

    public override void HideVisualHitbox()
    {
        base.HideVisualHitbox();
        foreach (GameObject sphere in debugHitboxes)
        {
            Destroy(sphere);
        }
        debugHitboxes.Clear();

    }



}
