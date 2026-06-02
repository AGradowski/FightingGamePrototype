using UnityEngine;

public class PlayerComboManager : MonoBehaviour
{
    private int comboMeter = 0;
    public void addHit()
    {
        comboMeter += 1;
    }
    public int getComboMeter()
    {
        return comboMeter;
    }

    //TODO add event when combo meter changes
}
