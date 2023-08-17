using TMPro;
using UnityEngine.UI;

public class UIManeger : Singleton<UIManeger>
{
    public Image hpBar;
    public TMP_Text attackPower;
    public TMP_Text jumpPower;

    private void Update()
    {
        hpBar.fillAmount = (float)GameManeger.Instance.player.healthCS.currentHP /
            GameManeger.Instance.player.healthCS.maxHp;
        attackPower.text = GameManeger.Instance.player.healthCS.damage.ToString();
        jumpPower.text = GameManeger.Instance.player.jumpingPower.ToString();
    }
}
