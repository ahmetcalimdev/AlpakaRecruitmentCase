using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerConfig", menuName = "Player/Player Config")]
public class PlayerConfig : ScriptableObject
{
    public int playerMoney;
    public bool isAuraSkillActive;
    public float maxPlayerHealth = 1000f;

}
