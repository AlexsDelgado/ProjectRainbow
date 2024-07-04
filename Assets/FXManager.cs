using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager Instance;
    [SerializeField] private Animator player;
    [SerializeField] private Animator enemy;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    public void PlayPlayerAnimation(string trigger)
    {
        player.SetTrigger(trigger);
    }
    public void PlayEnemyAnimation(string trigger)
    {
        enemy.SetTrigger(trigger);
    }
}
