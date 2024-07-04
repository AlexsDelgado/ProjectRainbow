using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
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

    private int armFinalDmg;
    private int legFinalDmg;
    private int bodyFinalDmg;

    private int armUltimateDmg;
    private int legUltimateDmg;
    private int bodyUltimateDmg;

    private int armUltimateDmgFinal;

    private int cyber_Count;
    private int corrosive_Count;
    private int nigthmare_Count;

    public int nightmare_HealthModifier = 10;
    public int cyber_HealthModifier = 7;
    public int corrosive_HealthModifier = 5;
    private int totalHealthModifier=0;

    private bool playerModifier;
    private bool enemyModifier;
    public int modifierID=0;
    private bool dmg0;
    private bool dmgNormal;
    private bool dmgMinus;
    private bool dmgBoost;
    private bool canMove = true;


    private string enemySkill1;
    private string enemySkill2;
    private string enemySkill3;
    

    [SerializeField] private int playerShield;
    [SerializeField] private int enemyShield;
    


    private void Start()
    {
        enemyPF = GameManager.Instance.enemyPrefab;
        
        state = BattleState.START;
         enemyUnitData = GameManager.Instance.unitSO;
         playerUnitData = GameManager.Instance.playerData;
         canMove = true;
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
                armUltimateDmg = 65;
                cyber_Count++;
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
                cyber_Count++;
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
                cyber_Count++;
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
        totalHealthModifier = corrosive_HealthModifier * corrosive_Count +nigthmare_Count*nightmare_HealthModifier+cyber_Count*cyber_HealthModifier;
        playerUnit.maxHP = playerUnitData.baseMaxHp - totalHealthModifier;
        texto.text = "Preparate para enfrentarte a " + enemyUnit.unitName;
        UI_Instance.SetHUD(playerUnit);
        UI_Instance.SetHUD(enemyUnit);
        modifierID = 0;
        enemyModifier = false;
        playerModifier = false;
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYER;
        PlayerTurn();
    }

    public void ApllyModifierPlayer()
    {
        switch (modifierID)
        {
            //damage default
            case 0:
                //playerUnit.damage = playerUnitData.baseDamage;
                //dmgNormal = true;
                //dmgBoost = false;

                armFinalDmg = armSkillDmg;
                legFinalDmg = legSkillDmg;
                bodyFinalDmg = bodySkillDmg;
                armUltimateDmgFinal = armUltimateDmg;
                
                
                break;
            case 1:
                armFinalDmg = armSkillDmg+15;
                legFinalDmg = legSkillDmg+15;
                bodyFinalDmg = bodySkillDmg+15;
                armUltimateDmgFinal = armUltimateDmg +15;
                Debug.Log("more damage");
                break;
            case 3:
                //double dmg
                
                
                armFinalDmg = armSkillDmg*2;
                legFinalDmg = legSkillDmg*2;
                bodyFinalDmg = bodySkillDmg*2;
                armUltimateDmgFinal = armUltimateDmg * 2;
                Debug.Log("double damage");
                // //playerUnit.damage = playerUnitData.baseDamage * 2;
                // dmgBoost = true;
                // dmgNormal = false;
                break;
            
        }

        playerModifier = false;
    }
    public void ApllyModifierEnemy()
    {
        switch (modifierID)
        {
            //damage default
            case 0:
                //enemyUnit.damage = enemyUnitData.baseDamage;
                dmgBoost = false;
                dmgNormal = true;
                dmg0 = false;
                canMove = true;
                Debug.Log("enemy damage normal");
                break;
            case 1:
                //enemyUnit.damage = enemyUnit.damage-10;
                dmgBoost = false;
                dmgNormal = false;
                dmg0 = false;
                dmgMinus = true;
                canMove = true;
                Debug.Log("enemy does less damage");
                break;
            case 2://damage 0
                dmgBoost = false;
                dmgNormal = false;
                dmg0 = true;
                dmgMinus = false;
                canMove = true;
                Debug.Log("enemy damage 0");
                break;
            case 3://skip turn
                dmgBoost = false;
                dmgNormal = false;
                dmg0 = true;
                dmgMinus = false;
                canMove = false;
                Debug.Log("enemy can't move");
                break;
        }
    }
    
    public void PlayerTurn()
    {
        texto.text = "Elige una accion:";
        accion = true;
        //can move
        if (playerModifier == true)
        {
            Debug.Log("modificacion al jugador");
            ApllyModifierPlayer();
        }
        else
        {
            armFinalDmg = armSkillDmg;
            legFinalDmg = legSkillDmg;
            bodyFinalDmg = bodySkillDmg;
            armUltimateDmgFinal = armUltimateDmg;

        }
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
                enemyIsDead = enemyUnit.TakeDamage(armFinalDmg);
                playerUnit.GetAdrenaline(armSkillAdrenaline);
                //actualizar hp enemigo
                UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                texto.text = ArmSkill+" deal "+armFinalDmg+" damage to " + enemyUnit.unitName;
                //texto.text = "Skill name gives you 50 adrenaline // buff comment";
                playerModifier = false;
                modifierID = 0;
                break;
            case "Mechanical claws":
                if (playerUnit.currentAdrenaline < 100)
                {
                    enemyIsDead = enemyUnit.TakeDamage(armFinalDmg);
                    playerUnit.GetAdrenaline(armSkillAdrenaline);
                    UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                    UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                    texto.text = ArmSkill+" deal "+armFinalDmg +" to "+enemyUnit.unitName;
                    playerModifier = false;
                    modifierID = 0;
                }
                else
                {
                    //ulti Mecha Shredder
                    enemyIsDead = enemyUnit.TakeDamage(armUltimateDmgFinal);
                    UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                    texto.text = "Mecha Shredder"+" deal"+armUltimateDmgFinal + "  to " + enemyUnit.unitName;
                    playerModifier = false;
                    playerUnit.ResetAdrenaline();
                    UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                    modifierID = 0;
                }
                break;
        }
        yield return new WaitForSeconds(2f);
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
                    enemyIsDead = enemyUnit.TakeDamage(legFinalDmg);
                    playerUnit.GetAdrenaline(legSkillAdrenaline);
                    UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                    UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                    texto.text = LegSkill+" deal "+legFinalDmg+" damage to " + enemyUnit.unitName;
                    playerModifier = false;
                    modifierID = 0;
                    //modifier applier
                   
                    break;
                case "Offensive maneuvers":
                    if (playerUnit.currentAdrenaline < 100)
                    {
                        playerUnit.GetAdrenaline(legSkillAdrenaline);
                        //attack buff
                        UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                        UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                        texto.text = LegSkill+" boost "+legSkillAdrenaline+" adrenaline, damage amplified";
                        modifierID = 1;
                        playerModifier = true;
                        
                    }
                    else
                    {
                        //ulti charge
                        enemyModifier = true;
                        modifierID = 3;
                        playerModifier = true;
                        texto.text = "Charge: Skip enemy turn, 2x damage buff";
                        playerUnit.ResetAdrenaline();
                        UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                        
                    }
                    break;
            }
        yield return new WaitForSeconds(2f);
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
                texto.text = BodySkill+" boost "+bodySkillAdrenaline+" adrenaline";
                playerModifier = false;
                break;
            case "Heavy duty armor":
                if (playerUnit.currentAdrenaline < 100)
                {
                    playerUnit.GetAdrenaline(bodySkillAdrenaline);
                    UI_Instance.SetEnemyHP(enemyUnit.currentHP);
                    UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                    texto.text = BodySkill+" boost "+bodySkillAdrenaline+" adrenaline";
                    
                    //shield buff applier
                    enemyModifier = true;
                    modifierID = 1;
                    playerShield += 75;
                    playerModifier = false;
                    UI_Instance.SetPlayerShield(playerShield);
                }
                else
                {
                    //ulti Mechanical Bulwark
                    enemyModifier = true;
                    modifierID = 2;
                    texto.text = "Mechanical Bulwark: Don't take any damage next turn";
                    playerUnit.ResetAdrenaline();
                    UI_Instance.SetPlayerAdrenaline(playerUnit.currentAdrenaline);
                    playerModifier = false;
                    
                }
                break;
        }
        
        yield return new WaitForSeconds(2f);
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
        //tiene modificacdores
        if (enemyModifier == true)
        {
            ApllyModifierEnemy();
            Debug.Log("enemy modifier");

        }
        // si no tiene stun
        if (canMove == true)
        {
            bool isDead = false;
            isDead = IA_EnemyLv1();
            //funcion dificultad 1
            // int dmgFinal = enemyUnitData.baseDamage;
            // if (dmg0)
            // {
            //     dmgFinal = 0;
            //     Debug.Log("Dont take any damage");
            // }
            //
            // if (dmgMinus)
            // {
            //     dmgFinal = dmgFinal - 10;
            //     Debug.Log("reduced damage");
            // }
            //
            // if (dmgNormal)
            // {
            //     dmgFinal = enemyUnitData.baseDamage;
            //     
            // }
            //
            // if (playerShield != 0)
            // {
            //     int auxShield = playerShield;
            //     playerShield = playerShield - dmgFinal;
            //     dmgFinal = dmgFinal - auxShield;
            //     //playerShield = playerShield-dmgFinal;
            //     //playerShield = playerShield-dmgFinal;
            //     if (dmgFinal < 0)
            //     {
            //         dmgFinal = 0;
            //     }
            //     UI_Instance.SetPlayerShield(playerShield);
            // }
            //
            //
            // texto.text = enemyUnit.unitName + " deals " + dmgFinal+" damage";
            // bool isDead = playerUnit.TakeDamage(dmgFinal);
            // UI_Instance.SetPlayerHP(playerUnit.currentHP);
            //
            //
            yield return new WaitForSeconds(2f);
            if (isDead)
            {
                state = BattleState.LOSE;
                StartCoroutine(EndBattle());
            }
            else
            {
                state = BattleState.PLAYER;
                enemyModifier = false;
                PlayerTurn();
            } 
            yield return new WaitForSeconds(2f);
            if (isDead)
            {
                state = BattleState.LOSE;
                StartCoroutine(EndBattle());
            }
            else
            {
                state = BattleState.PLAYER;
                enemyModifier = false;
                PlayerTurn();
            } 
            
        }
        //si tiene stun cambia de turno
        else
        {
            state = BattleState.PLAYER;
            texto.text = enemyUnit.name+" can't move";
            enemyModifier = false;
            PlayerTurn();
        } 
       
    }

    public bool IA_EnemyLv1()
    {
        
        string enemigo = enemyUnit.unitName;
        bool aux =false;
        
        switch (enemigo)
        {
            case "Battle0":
               aux = Battle0_Lv1();
                break;
            case "Battle1":
                Battle1_Lv1();
                break;
            case "Battle2":
                
                break;
            case "Boss":
                break;
        }

        return aux;
    }

    public bool Battle0_Lv1()
    {

        int dmgFinal = enemyUnitData.baseDamage;
        if (dmg0)
        {
            dmgFinal = 0;
        Debug.Log("Dont take any damage");
        }

        if (dmgMinus)
        {
            dmgFinal = dmgFinal - 10;
        Debug.Log("reduced damage");
        }

        if (dmgNormal)
        {
            dmgFinal = enemyUnitData.baseDamage;

        }

        if (playerShield != 0)
        {
            int auxShield = playerShield;
            playerShield = playerShield - dmgFinal;
            dmgFinal = dmgFinal - auxShield;
            //playerShield = playerShield-dmgFinal;
            //playerShield = playerShield-dmgFinal;
            if (dmgFinal < 0)
            {
                dmgFinal = 0;
            }
            UI_Instance.SetPlayerShield(playerShield);
        }
        
        texto.text = enemyUnit.unitName + " deals " + dmgFinal+" damage";
        bool isDead = playerUnit.TakeDamage(dmgFinal);
        UI_Instance.SetPlayerHP(playerUnit.currentHP);

        return isDead;
    }
    public void Battle1_Lv1()
    {
        
    }
    public void Battle2_Lv1()
    {
        
    }

}
