using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool isPlayer;
    public string unitName;
    public int unitLevel;

    public int damage;
    public int defense;
    public int maxHP;
    
    public int currentHP;
    public int currentAdrenaline;
    [SerializeField] public UnitData unitData;
    public void setUnit(UnitData unitData)
    {
        unitName = unitData.unitName;
        unitLevel = unitData.unitLevel;
        
        
        //subir stats digimon
        defense = unitData.baseDef * unitLevel;
        currentHP = unitData.baseMaxHp * unitLevel;
        damage = unitData.baseDamage * unitLevel;
    }
    public bool TakeDamage(int dmg)
    {
        //this.GetComponent<Animator>().SetTrigger("Dmg");
        dmg = dmg - defense;
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetAdrenaline(int adrenalineBoost)
    {
        currentAdrenaline += adrenalineBoost;
        if (currentAdrenaline > 100)
        {
            currentAdrenaline = 100;
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
