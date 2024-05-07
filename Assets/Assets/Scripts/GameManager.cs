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
        playerData.baseDamage = 10;
        playerData.baseDef = 5;
        playerData.baseMaxHp = 35;
        playerData.wisdom = 5;
    }

 

    public void returnMainIsland(bool battle)
    {
        SceneManager.LoadScene("Main Scene");
        unitSO = null;
        if (battle)
        {
            //ColoWins++;
        }
        //AudioManager.Instance.PlayMusicLobby();
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
