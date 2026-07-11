using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO check if animation can be played

    }

    //add animation buffer - message queue - priority queue? For the counters, bursts etc? Or should I handle it by states?

    //for now, just play what is required

    public void PlayAnimation(string animationName)
    {
        int animationHash = Animator.StringToHash(animationName);
        Debug.Log("Trying to play " + animationName);
        player.animator.Play(animationHash);//might be better and more controllable than triggers
        //TOD
    }

    //public void QueueAnimation()
    //public void GetAnimationTime()
    //public void CancelAnimation()

}
