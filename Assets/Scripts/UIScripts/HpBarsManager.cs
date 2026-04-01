using UnityEngine;
using UnityEngine.UIElements;

public class HpBarsManager : MonoBehaviour
{
    public FightManager manager;

    public UIDocument UIDoc;
    private Label ui_HealthLabelP1;
    private VisualElement ui_HealtBarMaskP1;
    private Label ui_HealthLabelP2;
    private VisualElement ui_HealtBarMaskP2;

    void Start()
    {
        //below are the queries searching the UI doc for all teh required elements
        ui_HealthLabelP1 = UIDoc.rootVisualElement.Q<Label>(UINames.LABEL_OF_PLAYER1);
        ui_HealtBarMaskP1 = UIDoc.rootVisualElement.Q<VisualElement>(UINames.HP_MASK_PLAYER1);

        ui_HealthLabelP2 = UIDoc.rootVisualElement.Q<Label>(UINames.LABEL_OF_PLAYER2);
        ui_HealtBarMaskP2 = UIDoc.rootVisualElement.Q<VisualElement>(UINames.HP_MASK_PLAYER2);
        Actions.HealthChanged += UpdateHealth;
    }

    private void UpdateHealth(Player playerHurt)
    {
        float healthRatio = (float)playerHurt.playerHealthManager.healthValue / playerHurt.playerHealthManager.maxHealthValue;
        float healthPercent = Mathf.Lerp(0, 100, healthRatio);//Sets the float to range 0-100 (%). This is is easy option
        //some other scenearios of graphics might require it more
        if (playerHurt.name == Names.PLAYER1)
        {
            ui_HealthLabelP1.text = $"{playerHurt.playerHealthManager.healthValue}/{playerHurt.playerHealthManager.maxHealthValue}";
            ui_HealtBarMaskP1.style.width = Length.Percent(healthPercent);
        }
        else if (playerHurt.name == Names.PLAYER2)
        {
            ui_HealthLabelP2.text = $"{playerHurt.playerHealthManager.healthValue}/{playerHurt.playerHealthManager.maxHealthValue}";
            ui_HealtBarMaskP2.style.width = Length.Percent(healthPercent);
        }
    }
}
