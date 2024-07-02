using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private CanvasManager Instance;
    [Header ("ScriptableObject")]
    [SerializeField] private ToSaveData data;
    [Header("GameObjects")]
    [SerializeField] private TMPro.TextMeshProUGUI skillId;
    [SerializeField] private Image skillImage;
    [SerializeField] private TMPro.TextMeshProUGUI skillInfo;

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

    private void Start()
    {
        skillId.text = data.SkillId.ToString();
        skillImage = data.SkillImage;
        skillInfo.text = data.SkillInfo;
    }
}
