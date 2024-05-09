using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Rewards : MonoBehaviour
{
   public GameObject arm;
   public GameObject leg;
   public GameObject body;

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

      newSkill = GameManager.Instance.newSkillCount;
   }

   public void ArmSelected()
   {
      newSkillGM(armData);
   }
   public void LegSelected()
   {
      newSkillGM(legData);
   }
   public void BodySelected()
   {
      newSkillGM(bodyData);
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

}
