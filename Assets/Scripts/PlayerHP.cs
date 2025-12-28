using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public UIManager uiManager;
    public Text HPText;
    public Slider HPSlider;
    public int maxHP;

    private int HP;

    void Start()
    {
        UpdateHP(maxHP);
    }

    public void Damaged(int damage)
    {
        UpdateHP(HP - damage);
    }

    private void UpdateHP(int hp)
    {
        HP = hp;
        HPText.text = "HP : " + HP;
        HPSlider.value = (float)HP / maxHP;

        if (HP == 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
