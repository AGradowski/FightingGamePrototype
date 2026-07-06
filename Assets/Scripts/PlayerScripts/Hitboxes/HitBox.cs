using UnityEngine;

[System.Serializable]
public class HitBox
{
    public Vector3 origin; //possibly add more hurtboxes, for better customization
    bool sphereToggle;
    public Vector3 hitboxSize = Vector3.one;
    public float radius = 0.5f;


}
