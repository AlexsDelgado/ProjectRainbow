using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//public enum BattleState{START, PLAYER, ENEMY, WIN, LOSE}

public class Combat : MonoBehaviour
{
    [SerializeField] private GameObject playerPF;
    [SerializeField] private GameObject enemyPF;
    private GameObject enemyGameObject;
    private GameObject playerGameObject;

    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform enemyPosition;

    private UnitData playerUnitData;
    private UnitData enemyUnitData;
    private Unit playerUnit;
    private Unit enemyUnit;


    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private UIManager UI_Instance;
    private BattleState state;
    private bool accion;


    private void Start()
    {
        state = BattleState.START;

        //enemyUnitData = GameManager.Instance.enemyData;
        //playerUnitData = GameManager.Instance.playerData;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        playerGameObject = Instantiate(playerPF, playerPosition);
        playerUnit = playerGameObject.GetComponent<Unit>();

        enemyGameObject = Instantiate(enemyPF, enemyPosition);
        enemyUnit = playerGameObject.GetComponent<Unit>();
        enemyUnit.setUnit(enemyUnitData);
        playerUnit.setUnit(playerUnitData);

        texto.text = "Prepare to fight against " + enemyUnit.unitName;
        UI_Instance.SetHUD(playerUnit);
        UI_Instance.SetHUD(enemyUnit);
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYER;
        PlayerTurn();
    }

    public void PlayerTurn()
    {
        texto.text = "Choose an Action:";
        accion = true;
    }

    public void Skill1Button()
    {
        if (state != BattleState.PLAYER || accion == false)
        {
            return;
        }

        accion = false;
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        bool isDead = enemyUnit.TakeDamage(15); //numero arbitrario
        UI_Instance.SetEnemyHP(enemyUnit.currentHP);
        texto.text = enemyUnit.unitName + "recibe 15 de daño";
        yield return new WaitForSeconds(1f);
        if (isDead)
        {
            state = BattleState.WIN;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.ENEMY;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EndBattle()
    {
        if (state == BattleState.WIN)
        {
            texto.text = "You Win";
            //codigo que vuelva a la anterior escena
            yield return new WaitForSeconds(2f);
            //GameManager.Instance.ReturnMainMenu(true);
        }
        else if (state == BattleState.LOSE)
        {
            texto.text = "You Lose";
            yield return new WaitForSeconds(2f);
            //GameManager.Instance.ReturnMainMenu(false);

        }

    }


    IEnumerator EnemyTurn()
    {
        texto.text = enemyUnit.unitName + " te inflinge " + enemyUnit.damage+" de daño";
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        UI_Instance.SetPlayerHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);
        if (isDead)
        {
            state = BattleState.LOSE;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.PLAYER;
            PlayerTurn();
        }
    }
    
}
