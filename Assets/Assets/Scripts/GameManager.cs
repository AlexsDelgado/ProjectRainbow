using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //combat 
    [SerializeField] public GameObject PlayerPF;
    [SerializeField] public GameObject enemyPrefab = null;
    [SerializeField] public UnitData unitSO = null;
    [SerializeField] public UnitData playerData;
    [SerializeField] private UnitData[] enemySO;
    public Sprite defaultPlayer;
    public int newSkillCount = 0;
    public SkillData newSkill1;
    public SkillData newSkill2;
    public SkillData newSkill3;

    public int victoriesQuantity;
    public bool armCounter=false;
    public bool bodyCounter=false;
    public bool legCounter=false;


    public ToSaveData legSkill;
    public ToSaveData armSkill;
    public ToSaveData chestSkill;
    private PlayerData playerSaveData;
    

    //singleton
    private void Awake()
    {
        GameObject[] objs =GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        if (Instance != null && Instance!=this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;    
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    public void ReturnMainMenu(bool battle)
    {
        
        unitSO = null;
        if (battle)
        {
            string enemigo = enemyPrefab.GetComponent<Unit>().unitName;
            switch (enemigo)
            {
                case "Battle0":
                    SceneManager.LoadScene("SkillReward0"); 
                    break;
                case "Battle1":
                    SceneManager.LoadScene("SkillReward1"); 
                    break;
                case "Battle2":
                    SceneManager.LoadScene("SkillReward2"); 
                    break;
                case "Boss":
                    SceneManager.LoadScene("SkillReward3"); 
                    break;
            }
        }
        else
        {
            SceneManager.LoadScene("LevelSelector"); 
        }
        
    }

    public void SetEnemy(GameObject prefabEnemy)
    {
        enemyPrefab = prefabEnemy;
        unitSO = prefabEnemy.GetComponent<Unit>().unitData;
    }
    public void ColosseumStart()
    {
        SceneManager.LoadScene("Battle");
    }

    public void SaveCheckpoint()
    {
        legSkill.SkillName = playerSaveData.legSkillName;
        legSkill.SkillInfo = playerSaveData.legInfo;
        armSkill.SkillName = playerSaveData.armSkillName;
        armSkill.SkillInfo = playerSaveData.armInfo;
        chestSkill.SkillName = playerSaveData.chestSkillName;
        chestSkill.SkillInfo = playerSaveData.chestInfo;
    }

    public void LoadData()
    {
        PlayerData loadedData = SaveControl.LoadPlayerData();
        if (loadedData != null)
        {
            legSkill.SkillName = loadedData.legSkillName;
            legSkill.SkillInfo = loadedData.legInfo;
            armSkill.SkillName = loadedData.armSkillName;
            armSkill.SkillInfo = loadedData.armInfo;
            chestSkill.SkillName = loadedData.chestSkillName;
            chestSkill.SkillInfo = loadedData.chestInfo;
        }
    }
    public void SaveAndExit()
    {
        playerSaveData = new PlayerData
        {
            legSkillName = legSkill.SkillName,
            legInfo = legSkill.SkillInfo,
            armSkillName = armSkill.SkillName,
            armInfo = armSkill.SkillInfo,
            chestSkillName = chestSkill.SkillName,
            chestInfo = chestSkill.SkillInfo,
            victories = victoriesQuantity
        };
        SaveControl.SavePlayerData(playerSaveData);
    }

    public void SetPlayerDefaultStats()
    {
        playerData.unitLevel = 1;
        playerData.arm = "Punch";
        armSkill.SkillName = "Punch";
        playerData.leg = "Advanced footwork";
        legSkill.SkillName = "Advanced footwork";
        playerData.body = "Deep focus";
        chestSkill.SkillName = "Deep focus";
        playerData.baseDef = 10;
        playerData.baseMaxHp = 100;
        RestartSprite();
        Debug.Log("Set defaul values");
        
    }
    
    public void RestartSprite()
    {
        PlayerPF.GetComponent<SpriteRenderer>().sprite =defaultPlayer ;
    }
    
}
