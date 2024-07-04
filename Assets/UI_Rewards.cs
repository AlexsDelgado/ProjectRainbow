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

   [SerializeField] public SkillData armData;
   [SerializeField] public SkillData legData;
   [SerializeField] public SkillData bodyData;
   public int newSkill;

   public TextMeshProUGUI armSkill;
   public TextMeshProUGUI legSkill;
   public TextMeshProUGUI bodySkill;

   public TextMeshProUGUI armInfo;
   public TextMeshProUGUI legInfo;
   public TextMeshProUGUI bodyInfo;

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
      newSkillGM();
      //agrega funcionalidad al combate
      GameManager.Instance.playerData.arm = armData.name;
      //salvado
      GameManager.Instance.armSkill.SkillName = armData.name;
        GameManager.Instance.armSkill.SkillInfo = armData.info;
   }
   public void LegSelected()
   {
      newSkillGM();
      GameManager.Instance.playerData.leg = legData.name;
        GameManager.Instance.legSkill.SkillName = legData.name;
        GameManager.Instance.legSkill.SkillInfo = legData.info;
   }
   public void BodySelected()
   {
      newSkillGM();
      GameManager.Instance.playerData.body = bodyData.name;
        GameManager.Instance.chestSkill.SkillName = bodyData.name;
        GameManager.Instance.chestSkill.SkillInfo = bodyData.info;
   }
   public void newSkillGM()
   {
      
      // switch (newSkill)
      // {
      //    case 0:
      //       GameManager.Instance.newSkill1 = ability;
      //       break;
      //    case 1:
      //       GameManager.Instance.newSkill2 = ability;
      //       break;
      //    case 2:
      //       GameManager.Instance.newSkill3 = ability;
      //       break;
      // }

      GameManager.Instance.newSkillCount++;
        GameManager.Instance.victoriesQuantity += 1;
      SceneManager.LoadScene("LevelSelector");

   }

}
