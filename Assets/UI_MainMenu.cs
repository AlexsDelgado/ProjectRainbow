using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject fightMenu1;
    public GameObject fightMenu2;
    public GameObject playerMenu1;
    public GameObject playerMenu2;
    public GameObject combatMap;
    public GameObject playerStats;

    //FightMenuButtons
    public Button combat0;
    public Button combat1;
    public Button combat2;

    public GameObject pfEnemy0;
    public GameObject pfEnemy1;
    public GameObject pfEnemy2;

    //playerMenuSkills
    public GameObject armsButton;
    public GameObject bodyButton;
    public GameObject legsButton;

    public GameObject skillContainer;
    public GameObject armSkills;
    public GameObject bodySkills;
    public GameObject legSkills;



    // public GameObject armSkill1;
    // public GameObject armSkill1Info;
    //
    // public GameObject armSkill2;
    // public GameObject armSkill2Info;
    //
    // public GameObject armSkill3;
    // public GameObject armSkill3Info;
    //
    // public GameObject bodySkill1;
    // public GameObject bodySkill1Info;
    //
    // public GameObject bodySkill2;
    // public GameObject bodySkill2Info;
    //
    // public GameObject bodySkill3;
    // public GameObject bodySkill3Info;
    //
    // public GameObject legSkill1;
    // public GameObject legSkill1Info;
    // public GameObject legSkill2;
    // public GameObject legSkill2Info;
    // public GameObject legSkill3;
    // public GameObject legSkill3Info;
    //
    // public GameObject armDisabled;
    // public GameObject legDisabled;
    // public GameObject bodyDisabled;

    public void setStartSkills()
    {
        if (GameManager.Instance.newSkillCount == 0)
        {
            //armDisabled.SetActive(true);
            //bodyDisabled.SetActive(true);
            //legDisabled.SetActive(true);
        }
        else
        {
            switch (GameManager.Instance.newSkillCount)
            {
                case 1:
                    checkSkills(GameManager.Instance.newSkill1);
                    break;
                case 2:
                    checkSkills(GameManager.Instance.newSkill1);
                    checkSkills(GameManager.Instance.newSkill2);
                    break;
                case 3:
                    checkSkills(GameManager.Instance.newSkill1);
                    checkSkills(GameManager.Instance.newSkill2);
                    checkSkills(GameManager.Instance.newSkill3);
                    break;
            }
        }
    }

    public void checkSkills(SkillData skilldata)
    {
        // string aux = skilldata.type;
        // switch (aux)
        // {
        //     case "Arm":
        //         // armDisabled.SetActive(false);
        //         // armSkill2.SetActive(true);
        //         break;
        //     case "Leg":
        //         // legDisabled.SetActive(false);
        //         // legSkill2.SetActive(true);
        //         break;
        //     case "Body":
        //         // bodyDisabled.SetActive(false);
        //         // bodySkill2.SetActive(true);
        //         break;
        // }
    }

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
        setStartSkills();
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
        // armSkill1Info.SetActive(false);
        // armSkill2Info.SetActive(false);
        // armSkill3Info.SetActive(false);
        // bodySkill1Info.SetActive(false);
        // bodySkill2Info.SetActive(false);
        // bodySkill3Info.SetActive(false);
        // legSkill1Info.SetActive(false);
        // legSkill2Info.SetActive(false);
        // legSkill3Info.SetActive(false);
    }
    public void ArmSkill1()
    {
        CloseAllInfo();
        // armSkill1Info.SetActive(true);
    }
    public void ArmSkill2()
    {
        CloseAllInfo();
        // armSkill2Info.SetActive(true);
    }
    public void ArmSkill3()
    {
        CloseAllInfo();
        // armSkill3Info.SetActive(true);
    }
    public void BodySkill1()
    {
        CloseAllInfo();
        // bodySkill1Info.SetActive(true);
    }
    public void BodySkill2()
    {
        CloseAllInfo();
        // bodySkill2Info.SetActive(true);
    }
    public void BodySkill3()
    {
        CloseAllInfo();
        // bodySkill3Info.SetActive(true);
    }

    public void LegSkill1()
    {
        CloseAllInfo();
        // legSkill1Info.SetActive(true);
    }
    public void LegSkill2()
    {
        CloseAllInfo();
        // legSkill2Info.SetActive(true);
    }

    public void LegSkill3()
    {
        CloseAllInfo();
        // legSkill3Info.SetActive(true);
    }

    public void SelectSkillArm(string skillName)
    {
        GameManager.Instance.playerData.arm = skillName;
    }
    public void SelectSkillBody(string skillName)
    {
        GameManager.Instance.playerData.body = skillName;
    }
    public void SelectSkillLeg(string skillName)
    {
        GameManager.Instance.playerData.leg = skillName;
    }



    //Menu para seleccion de enemigos
    private void Start()
    {
        combat0.onClick.AddListener(setEnemy0);
        combat1.onClick.AddListener(setEnemy1);
        combat2.onClick.AddListener(setEnemy2);
        setStartSkills();
        playerStats.SetActive(false);
    }

    private void setEnemy0()
    {
        GameManager.Instance.SetEnemy(pfEnemy0);
        GameManager.Instance.ColosseumStart();
    }
    private void setEnemy1()
    {

        if (GameManager.Instance.tutorial == true)
        {
            GameManager.Instance.SetEnemy(pfEnemy1);
            GameManager.Instance.ColosseumStart();
        }
        else
        {
            Debug.Log("Try again after win combat 0");
        }


    }
    private void setEnemy2()
    {

        if (GameManager.Instance.tutorial == true)
        {
            GameManager.Instance.SetEnemy(pfEnemy2);
            GameManager.Instance.ColosseumStart();
        }
        else
        {
            Debug.Log("Try again after win combat 0");
        }

    }

    public void BackToMainMenu()
    {
        GameManager.Instance.SaveAndExit();
        SceneManager.LoadScene("MainMenu");
    }
}
