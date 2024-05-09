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

    }

    private void setPlayerDefaultStats()
    {
        playerData.unitLevel = 1;
        playerData.baseDamage = 15;
        playerData.baseDef = 10;
        playerData.baseMaxHp = 100;
        
    }

 

    public void ReturnMainMenu(bool battle)
    {
        SceneManager.LoadScene("MainMenu");
        unitSO = null;
        if (battle)
        {
            //reward menu
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
