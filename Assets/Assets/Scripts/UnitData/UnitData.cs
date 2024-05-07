
using UnityEngine;
[CreateAssetMenu(fileName = "UnitData",menuName = "Unit Data")]
public class UnitData : ScriptableObject
{
    public bool isPlayer = false;
    public string unitName = "defaultValue";
    public int unitLevel=1;

    public int baseDamage = 1;
    public int baseDef = 5;
    public int baseMaxHp = 30;

    public int wisdom = 5;
    public int reward = 5;
}
