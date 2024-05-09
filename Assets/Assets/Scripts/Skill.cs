using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillData SkillData;

    public string name;
    public string info;
    public string type;
    
    private void Start()
    {
        name = SkillData.name;
        info = SkillData.info;
        type = SkillData.type;
    }
}
