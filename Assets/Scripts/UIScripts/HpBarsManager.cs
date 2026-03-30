using UnityEngine;
using UnityEngine.UIElements;

public class HpBarsManager : MonoBehaviour
{

    public FightManager manager;//possibly add teh search function
    //public Player player1;
    //public Player player2;
    public UIDocument UIDoc;
    private Label m_HealthLabelP1;
    private Label m_HealthLabelP2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Actions.HealthChanged += UpdateHealth;

        m_HealthLabelP1 = UIDoc.rootVisualElement.Q<Label>("HealthLabel1");
        m_HealthLabelP2 = UIDoc.rootVisualElement.Q<Label>("HealthLabel2");



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateHealth(Player playerHurt)
    {
        if (playerHurt.name == Names.PLAYER1)
        {
            m_HealthLabelP1.text = $"{playerHurt.playerHealthManager.healthValue}/{playerHurt.playerHealthManager.maxHealthValue}";
        }
        else if (playerHurt.name == Names.PLAYER2)
        {
            m_HealthLabelP2.text = $"{playerHurt.playerHealthManager.healthValue}/{playerHurt.playerHealthManager.maxHealthValue}";
        }
    }
}
