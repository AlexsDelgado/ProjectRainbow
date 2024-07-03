using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Rewards : MonoBehaviour
{
   public GameObject arm;
   public GameObject leg;
   public GameObject body;

   public TextMeshProUGUI armSkill;
   public TextMeshProUGUI legSkill;
   public TextMeshProUGUI bodySkill;

   public TextMeshProUGUI armInfo;
   public TextMeshProUGUI legInfo;
   public TextMeshProUGUI bodyInfo;

   [SerializeField] public SkillData armData;
   [SerializeField] public SkillData legData;
   [SerializeField] public SkillData bodyData;
   
   
   public int newSkill;


   private void Start()
   {
      
      arm.GetComponent<Button>().onClick.AddListener(ArmSelected);
      leg.GetComponent<Button>().onClick.AddListener(LegSelected);
      body.GetComponent<Button>().onClick.AddListener(BodySelected);
      //
      // armData = arm.GetComponent<SkillData>();
      // legData = leg.GetComponent<SkillData>();
      // bodyData = body.GetComponent<SkillData>();

      armInfo.text = armData.info;
      legInfo.text = legData.info;
      bodyInfo.text = bodyData.info;

      armSkill.text = armData.name;
      legSkill.text = legData.name;
      bodySkill.text = bodyData.name;
      
      
      newSkill = GameManager.Instance.newSkillCount;
   }

   
   
   public void ArmSelected()
   {
      GameManager.Instance.playerData.arm = armData.name;
      ReturnMenu();
      //newSkillGM(armData);
   }
   public void LegSelected()
   {
      //newSkillGM(legData);
      GameManager.Instance.playerData.leg = legData.name;
      ReturnMenu();
   }
   public void BodySelected()
   {
      //newSkillGM(bodyData);
      GameManager.Instance.playerData.body = bodyData.name;
      ReturnMenu();
   }
   public void newSkillGM(SkillData ability)
   {
      
      switch (newSkill)
      {
         case 0:
            GameManager.Instance.newSkill1 = ability;
            break;
         case 1:
            GameManager.Instance.newSkill2 = ability;
            break;
         case 2:
            GameManager.Instance.newSkill3 = ability;
            break;
      }

      GameManager.Instance.newSkillCount++;
      GameManager.Instance.tutorial = true;
      SceneManager.LoadScene("MainMenu");

   }

   public void ReturnMenu()
   {
      SceneManager.LoadScene("MainMenu");
   }

}
