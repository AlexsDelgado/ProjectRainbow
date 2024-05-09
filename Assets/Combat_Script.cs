using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;

public enum BattleState{START, PLAYER, ENEMY, WIN, LOSE}

public class Combat_Script : MonoBehaviour
{
    
      [SerializeField] private GameObject playerPF;
    [SerializeField] private GameObject enemyPF;
    private GameObject enemyGameObject;
    private GameObject playerGameObject;

    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform enemyPosition;

    private UnitData playerUnitData;
    private UnitData enemyUnitData;
    [SerializeField] private Unit playerUnit;
    [SerializeField] private Unit enemyUnit;

    //ui
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private UIManager UI_Instance;
    [SerializeField] private TextMeshProUGUI nameArmSkill;
    [SerializeField] private TextMeshProUGUI nameLegSkill;
    [SerializeField] private TextMeshProUGUI nameBodySkill;
    private BattleState state;
    private bool accion;
    
    //combat skills changes
    private string ArmSkill;
    private string LegSkill;
    private string BodySkill;
    [SerializeField] private int adrenaline;
    private bool enemyIsDead =false;

    private int armSkillDmg = 0;
    private int armSkillAdrenaline = 0;
    private int legSkillDmg = 0;
    private int legSkillAdrenaline = 0;
    private int bodySkillDmg = 0;
    private int bodySkillAdrenaline = 0;

    private bool playerModifier;
    private bool enemyModifier;

    [SerializeField] private int playerShield;
    [SerializeField] private int enemyShield;
    


    private void Start()
    {
        state = BattleState.START;
         enemyUnitData = GameManager.Instance.unitSO;
         playerUnitData = GameManager.Instance.playerData;
         
         setupSkills();
        
        StartCoroutine(SetupBattle());

    }

    public void setupSkills()
    {
        ArmSkill = GameManager.Instance.playerData.arm;
        LegSkill = GameManager.Instance.playerData.leg;
        BodySkill = GameManager.Instance.playerData.body;

        switch (ArmSkill)
        {
            case "Punch":
                armSkillAdrenaline = 25;
                armSkillDmg = 25;
                break;
            case "Mechanical claws":
                armSkillAdrenaline = 25;
                armSkillDmg = 45;
                break;
        }

        switch (LegSkill)
        {
            case "Advanced footwork":
                legSkillAdrenaline = 40;
                legSkillDmg = 15;
                break;
            case "Offensive maneuvers":
                legSkillAdrenaline = 30;
                legSkillDmg = 0;
                break;
        }

        switch (BodySkill)
        {
            case "Deep focus":
                bodySkillAdrenaline = 50;
                bodySkillDmg = 0;
                break;
            case "Heavy duty armor":
                bodySkillDmg = 0;
                bodySkillAdrenaline = 15;
                break;
        }
        nameArmSkill.text = ArmSkill;
        nameLegSkill.text = LegSkill;
        nameBodySkill.text = BodySkill;



    }

    IEnumerator SetupBattle()
    {
        playerGameObject = Instantiate(playerPF, playerPosition);
        playerUnit = playerGameObject.GetComponent<Unit>();
        adrenaline = playerUnitData.adrenaline;

        enemyGameObject = Instantiate(enemyPF, enemyPosition);
        enemyUnit = enemyGameObject.GetComponent<Unit>();
        
        // enemyUnitData = enemyUnit.unitData;
        // playerUnitData = playerUnit.unitData;
        
        enemyUnit.setUnit(enemyUnitData);
        playerUnit.setUnit(playerUnitData);

        texto.text = "Preparate para enfrentarte a " + enemyUnit.unitName;
        UI_Instance.SetHUD(playerUnit);
        UI_Instance.SetHUD(enemyUnit);
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYER;
        PlayerTurn();
    }

    public void PlayerTurn()
    {
        texto.text = "Elige una accion:";
        accion = true;
        //can move
        //has modifier
    }

    public void Skill1Button()
    {
        if (state != BattleState.PLAYER || accion == false)
        {
            return;
        }

        accion = false;
        StartCoroutine(Skill1());
    }
    public void Skill2Button()
    {
        if (state != BattleState.PLAYER || accion == false)
        {
            return;
        }

        accion = false;
        StartCoroutine(Skill2());
    }
    public void Skill3Button()
    {
        if (state != BattleState.PLAYER || accion == false)
        {
            return;
        }

        accion = false;
        StartCoroutine(Skill3());
    }

    

    IEnumerator Attack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage); 
        UI_Instance.SetEnemyHP(enemyUnit.currentHP);
        texto.text = enemyUnit.unitName + " recibe "+ playerUnit.damage + " de daño";
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

    IEnumerator Skill1()
    {
        switch (ArmSkill)
        {
            case "Punch":
                //daño con skillDMG
                enemyIsDead = enemyUnit.TakeDamage(armSkillDmg);
                playerUnit.GetAdrenaline(armSkillAdrenaline);
                //actualizar hp enemigo
                UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                texto.text = ArmSkill+" deal "+armSkillDmg+" damage to " + enemyUnit.unitName;
                //texto.text = "Skill name gives you 50 adrenaline // buff comment";
                break;
            case "Mechanical claws":
                if (playerUnit.currentAdrenaline < 100)
                {
                    enemyIsDead = enemyUnit.TakeDamage(armSkillDmg);
                    playerUnit.GetAdrenaline(armSkillAdrenaline);
                    UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                    //UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                    texto.text = ArmSkill+" deal 25 damage to " + enemyUnit.unitName;
                }
                else
                {
                    //ulti Mecha Shredder
                }
                break;
        }
        yield return new WaitForSeconds(1f);
        if (enemyIsDead)
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
    IEnumerator Skill2()
    {
            switch (LegSkill)
            {
                case "Advanced footwork":
                    enemyIsDead = enemyUnit.TakeDamage(legSkillDmg);
                    playerUnit.GetAdrenaline(legSkillAdrenaline);
                    UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                    UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                    texto.text = LegSkill+" deal "+legSkillDmg+" damage to " + enemyUnit.unitName;
                    
                    //modifier applier
                   
                    break;
                case "Offensive maneuvers":
                    if (playerUnit.currentAdrenaline < 100)
                    {
                        //ulti charge
                    }
                    break;
            }
        yield return new WaitForSeconds(1f);
        if (enemyIsDead)
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
    IEnumerator Skill3()
    {
        switch (BodySkill)
        {
            case "Deep focus":
                playerUnit.GetAdrenaline(bodySkillAdrenaline);
                UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                texto.text = BodySkill+" boost "+bodySkillAdrenaline+" adrenaline to " + playerUnit.unitName;
                break;
            case "Heavy duty armor":
                if (playerUnit.currentAdrenaline < 100)
                {
                    playerUnit.GetAdrenaline(bodySkillAdrenaline);
                    UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                    //UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                    texto.text = BodySkill+" boost "+bodySkillAdrenaline+" adrenaline to " + playerUnit.unitName;
                    
                    //shield buff applier
                    playerShield += 75;
                    UI_Instance.SetPlayerShield(playerShield);
                    

                }
                else
                {
                    //ulti Mechanical Bulwark
                }
                break;
        }
        
        yield return new WaitForSeconds(1f);
        if (enemyIsDead)
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
            texto.text = "ganaste";
            //codigo que vuelva a la anterior escena
            yield return new WaitForSeconds(2f);
            GameManager.Instance.ReturnMainMenu(true);
        }
        else if (state == BattleState.LOSE)
        {
            texto.text = "perdiste";
            yield return new WaitForSeconds(2f);
            GameManager.Instance.ReturnMainMenu(false);

        }

    }


    IEnumerator EnemyTurn()
    {
       
        int dmgFinal = enemyUnit.damage - playerShield;
        playerShield -= enemyUnit.damage;
        if (dmgFinal < 0)
        {
            dmgFinal = 0;
        }
        texto.text = enemyUnit.unitName + " deals " + dmgFinal+" damage";
        bool isDead = playerUnit.TakeDamage(dmgFinal);
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
