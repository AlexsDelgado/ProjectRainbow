using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animaciones;
    [SerializeField] public UnitData unitData;
    public void Animation(String animation)
    {
        animaciones.SetTrigger(animation);
    }

}
