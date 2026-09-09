using UnityEngine;

public class PlayerParticleManager : MonoBehaviour
{
    private ParticleSystem dodgeLeft;
    private ParticleSystem dodgeRight;

    void Start()
    {
        dodgeLeft = GameObject.Find(gameObject.name + Names.DODGE_LEFT).GetComponent<ParticleSystem>();
        dodgeRight = GameObject.Find(gameObject.name + Names.DODGE_RIGHT).GetComponent<ParticleSystem>();
    }

    public void ActivateDodgeLeft()
    {
        dodgeLeft.Play();
    }
    public void ActivateDodgeRight()
    {
        dodgeRight.Play();
    }
    public void StopDodgeLeft()
    {
        dodgeLeft.Stop();
    }
    public void StopDodgeRight()
    {
        dodgeRight.Stop();
    }
}
