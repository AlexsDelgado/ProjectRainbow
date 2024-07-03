using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //combat 
    [SerializeField] private GameObject PlayerPF;
    [SerializeField] public GameObject enemyPrefab = null;
    [SerializeField] public UnitData unitSO = null;
    [SerializeField] public UnitData playerData;
    [SerializeField] private UnitData[] enemySO;

    
    public bool tutorial = false;
    public int newSkillCount = 0;
    public SkillData newSkill1;
    public SkillData newSkill2;
    public SkillData newSkill3;
    
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
    
   //set default game stats
    private void Start()
    {
        setPlayerDefaultStats();
        newSkillCount = 0;

    }

    private void setPlayerDefaultStats()
    {
        playerData.unitLevel = 1;
        playerData.arm = "Punch";
        playerData.leg = "Advanced footwork";
        playerData.body = "Deep focus";
        playerData.baseDef = 10;
        playerData.baseMaxHp = 100;
        
    }

 

    public void ReturnMainMenu(bool battle)
    {
        
        unitSO = null;
        if (battle)
        {
            SceneManager.LoadScene("SkillReward0");
            tutorial = true;
            
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
    

}
