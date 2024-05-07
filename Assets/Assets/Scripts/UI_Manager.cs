using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerLevel;
    public Slider playerHpSlider;


    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyLevel;
    public Slider enemyHpSlider;

    public TextMeshProUGUI currentHPUI;
    public TextMeshProUGUI maxHPUI;
    public GameObject buttonDV;

    //public CombatManager CM_manager;

    private void Awake()
    {
        // CM_manager.updateHPEnemy += SetEnemyHP;
        // CM_manager.updateHPPlayer += SetPlayerHP;
    }

    public void SetHUD(Unit unit)
    {
        if (unit.isPlayer)
        {
            playerName.text = unit.unitName;
            //playerLevel.text = "Lvl " + unit.unitLevel;
            playerHpSlider.maxValue = unit.currentHP;
            playerHpSlider.value = unit.currentHP;
            maxHPUI.text = playerHpSlider.value.ToString();
            currentHPUI.text = playerHpSlider.value.ToString();
        }
        else
        {
            enemyName.text = unit.unitName;
            enemyLevel.text = unit.unitLevel.ToString();
            enemyHpSlider.maxValue = unit.currentHP;
            enemyHpSlider.value = unit.currentHP; 
        }
     
    }

    public void SetEnemyHP(int hp)
    {
        enemyHpSlider.value = hp;
    }
    public void SetPlayerHP(int hp)
    {
        playerHpSlider.value = hp;
        currentHPUI.text = playerHpSlider.value.ToString();
    }
}
