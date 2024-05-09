using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject fightMenu1;
    public GameObject fightMenu2;
    public GameObject playerMenu1;
    public GameObject playerMenu2;
    public GameObject combatMap;
    public GameObject playerStats;
    
    //playerMenuSkills
    public GameObject armsButton;
    public GameObject bodyButton;
    public GameObject legsButton;

    public GameObject skillContainer;
    public GameObject armSkills;
    public GameObject bodySkills;
    public GameObject legSkills;

    
    
    public GameObject armSkill1;
    public GameObject armSkill1Info;
    
    public GameObject armSkill2;
    public GameObject armSkill2Info;
    
    public GameObject armSkill3;
    public GameObject armSkill3Info;
    
    public GameObject bodySkill1;
    public GameObject bodySkill1Info;
    
    public GameObject bodySkill2;
    public GameObject bodySkill2Info;
    
    public GameObject bodySkill3;
    public GameObject bodySkill3Info;

    public GameObject legSkill1;
    public GameObject legSkill1Info;
    public GameObject legSkill2;
    public GameObject legSkill2Info;
    public GameObject legSkill3;
    public GameObject legSkill3Info;


    public void fightMenuActive()
    {
        fightMenu1.SetActive(false);
        fightMenu2.SetActive(false);
        playerMenu1.SetActive(false);
        playerMenu2.SetActive(true);
        combatMap.SetActive(true);
        playerStats.SetActive(false);
        CloseSkillsMenu();
    }
    public void playerMenuActive()
    {
        //main menu buttons
        fightMenu1.SetActive(false);
        fightMenu2.SetActive(true);
        playerMenu1.SetActive(false);
        playerMenu2.SetActive(false);
        combatMap.SetActive(false);
        //skills selection buttons
        CloseSkillsMenu();
        playerStats.SetActive(true);
        armsButton.SetActive(true);
        legsButton.SetActive(true);
        bodyButton.SetActive(true);
    }

    public void OffButtons()
    {
        armsButton.SetActive(false);
        legsButton.SetActive(false);
        bodyButton.SetActive(false);
    }

    public void ArmMenu()
    {
        
        OffButtons();
        skillContainer.SetActive(true);
        armSkills.SetActive(true);
    }
    public void BodyMenu()
    {
        OffButtons();
        skillContainer.SetActive(true);
        bodySkills.SetActive(true);
    }
    public void LegMenu()
    {
        
        OffButtons();
        skillContainer.SetActive(true);
        legSkills.SetActive(true);
    }


    public void CloseSkillsMenu()
    {
        skillContainer.SetActive(false);
        OffButtons();
        legSkills.SetActive(false);
        bodySkills.SetActive(false);
        armSkills.SetActive(false);
    }

    public void ReturnPlayerMenu()
    {
       CloseAllInfo(); 
       CloseSkillsMenu();
       armsButton.SetActive(true);
       bodyButton.SetActive(true);
       legsButton.SetActive(true);
    }

    public void CloseAllInfo()
    {
        armSkill1Info.SetActive(false);
        armSkill2Info.SetActive(false);
        armSkill3Info.SetActive(false);
        bodySkill1Info.SetActive(false);
        bodySkill2Info.SetActive(false);
        bodySkill3Info.SetActive(false);
        legSkill1Info.SetActive(false);
        legSkill2Info.SetActive(false);
        legSkill3Info.SetActive(false);
    }
    public void ArmSkill1()
    {
        CloseAllInfo();
        armSkill1Info.SetActive(true);
        
    }
    public void ArmSkill2()
    {
        CloseAllInfo();
        armSkill2Info.SetActive(true);
        
    }
    public void ArmSkill3()
    {
        CloseAllInfo();
        armSkill3Info.SetActive(true);
        
    }
    public void BodySkill1()
    {
        CloseAllInfo();
        bodySkill1Info.SetActive(true);
        
    }
    public void BodySkill2()
    {
        CloseAllInfo();
        bodySkill2Info.SetActive(true);
        
    }
    public void BodySkill3()
    {
        CloseAllInfo();
        bodySkill3Info.SetActive(true);
        
    }
    
    public void LegSkill1()
    {
        CloseAllInfo();
        legSkill1Info.SetActive(true);
        
    }
    public void LegSkill2()
    {
        CloseAllInfo();
        legSkill2Info.SetActive(true);
        
    }

    public void LegSkill3()
    {
        CloseAllInfo();
        legSkill3Info.SetActive(true);
        
    }

    public void SelectSkill(string type, string skillName)
    {
        switch (type)
        {
            case "arm":
                GameManager.Instance.playerData.arm = skillName;
                break;
            case "body":
                GameManager.Instance.playerData.body = skillName;
                break;
            case "leg":
                GameManager.Instance.playerData.leg = skillName;
                break;
            default:
                Debug.Log("Skill type invalid");
                break;
        }
    }


    
}
