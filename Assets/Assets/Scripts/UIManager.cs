using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    //public TextMeshProUGUI playerLevel;
    public Slider playerHpSlider;


    public TextMeshProUGUI enemyName;
    //public TextMeshProUGUI enemyLevel;
    public Slider enemyHpSlider;

    public TextMeshProUGUI currentHPUI;
    public TextMeshProUGUI maxHPUI;

    public Slider playerShield;
    public Slider playerAdrenaline;

    public Slider enemyShield;
    
   
   


    public void SetHUD(Unit unit)
    {
        if (unit.isPlayer)
        {
            playerName.text = unit.unitName;
            //playerLevel.text = "Lvl " + unit.unitLevel;
            playerHpSlider.maxValue = unit.maxHP;
            playerHpSlider.value = unit.maxHP;
            maxHPUI.text = playerHpSlider.value.ToString();
            currentHPUI.text = playerHpSlider.value.ToString();
        }
        else
        {
            enemyName.text = unit.unitName;
            //enemyLevel.text = unit.unitLevel.ToString();
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

    public void SetPlayerAdrenaline(int adrenaline)
    {
        playerAdrenaline.value = adrenaline;
    }

    public void SetPlayerShield(int shield)
    {
        playerShield.value = shield;
    }
        


    
    
    
}
