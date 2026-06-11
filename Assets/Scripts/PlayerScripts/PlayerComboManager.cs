using UnityEngine;

public class PlayerComboManager : MonoBehaviour
{
    private int comboMeter = 0;

    private Player player;

    public void Awake()
    {
        player = GetComponent<Player>();
        Debug.Log("Got player");
        Actions.PlayerRecoveredAfterHits += resetCounter;

    }
    public void addHit()
    {
        comboMeter += 1;
        //Actions.ComboChanged(player);
        Debug.Log(player.name + " combo: " + comboMeter.ToString());

    }
    public int getComboMeter()
    {
        return comboMeter;
    }

    public void resetCounter(Player recoveredPlayer)
    {
        if (player.name != recoveredPlayer.name)
        {
            comboMeter = 0;
        }
    }
}
