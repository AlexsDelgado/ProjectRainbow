using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject fightMenu1;
    public GameObject fightMenu2;
    public GameObject playerMenu1;
    public GameObject playerMenu2;
    public GameObject combatMap;
    public GameObject playerStats;
    
    
    
    public void fightMenuActive()
    {
        fightMenu1.SetActive(false);
        fightMenu2.SetActive(false);
        playerMenu1.SetActive(false);
        playerMenu2.SetActive(true);
        combatMap.SetActive(true);
        playerStats.SetActive(false);
    }
    public void playerMenuActive()
    {
        fightMenu1.SetActive(false);
        fightMenu2.SetActive(true);
        playerMenu1.SetActive(false);
        playerMenu2.SetActive(false);
        combatMap.SetActive(false);
        playerStats.SetActive(true);
    }
    
    
}
