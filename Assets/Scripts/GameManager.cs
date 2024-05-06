using System;
using System.Collections;
using System.Collections.Generic;
using Observer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //combat 
    [SerializeField] private GameObject PlayerPF;
    [SerializeField] public GameObject enemyPrefab = null;
    [SerializeField] public UnitData unitSO = null;
    [SerializeField] public UnitData playerDigimon;
    [SerializeField] private UnitData[] enemySO;
    
    //currency
    [SerializeField] public int EXP = 0;
    [SerializeField] public int Gold = 0;
    //cost
    [SerializeField] public int costLevelUp;
    [SerializeField] public int costTrainning;
    [SerializeField] public int costPlugin;
    //enable Digievolution
    [SerializeField] public bool DV = false;
    
    //digimon level
    [SerializeField] public int ColoWins = 0;
    
   
    //evento de que se gasto puntos de exp
    //evento de que se gasto gold
    
    
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
        costTrainning = 5;
        costPlugin = 5;
        costLevelUp = 2;
    }

    private void setPlayerDefaultStats()
    {
        playerDigimon.unitLevel = 1;
        playerDigimon.baseDamage = 10;
        playerDigimon.baseDef = 5;
        playerDigimon.baseMaxHp = 35;
        playerDigimon.wisdom = 5;
    }

 

    public void returnMainIsland(bool battle)
    {
        SceneManager.LoadScene("Main Scene");
        unitSO = null;
        if (battle)
        {
            ColoWins++;
        }
        AudioManager.Instance.PlayMusicLobby();
    }

    public void SetEnemyColosseum(GameObject prefabEnemy)
    {
        enemyPrefab = prefabEnemy;
        unitSO = prefabEnemy.GetComponent<Enemy>().unitData;
    }
    public void ColosseumStart()
    {
        SceneManager.LoadScene("BattleScene");
    }

    public int costePlugin()
    {
        costPlugin = costPlugin * 2;
        return costPlugin;
    }

    public int costeTrainning()
    {
        costTrainning = costTrainning * 2;
        return costTrainning;
    }

    public int costeLvlUp()
    {
        costLevelUp = costLevelUp * 2;
        return costLevelUp;
    }

}
