using UnityEngine;

public class PlayerComboManager : MonoBehaviour
{
    private int comboMeter = 0;

    private Player player;

    public void Start()
    {
        player = GetComponent<Player>();
        Actions.PlayerRecoveredAfterHits += resetCounter;

    }
    public void addHit()
    {
        comboMeter += 1;
        Actions.ComboChanged(player);
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
