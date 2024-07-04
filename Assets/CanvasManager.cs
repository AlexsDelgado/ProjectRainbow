using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    private CanvasManager Instance;
    [Header ("ScriptableObject")]
    [SerializeField] private ToSaveData chestData;
    [SerializeField] private ToSaveData armsData;
    [SerializeField] private ToSaveData legsData;
    [Header("Chest")]
    [SerializeField] private TextMeshProUGUI chestSkillName;
    [SerializeField] private TextMeshProUGUI chestSkillInfo;
    //[SerializeField] private Image chestSkillImage;
    [Header("Arms")]
    [SerializeField] private TextMeshProUGUI armsSkillInfo;
    [SerializeField] private TextMeshProUGUI armsSkillName;
    //[SerializeField] private Image armsSkillImage;
    [Header("Legs")]
    [SerializeField] private TextMeshProUGUI legsSkillInfo;
    [SerializeField] private TextMeshProUGUI legsSkillName;
    //[SerializeField] private Image legsSkillImage;


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
        LoadFromScriptable();
    }

    private void LoadFromScriptable()
    {
        chestSkillName.text = chestData.SkillName.ToString();
        chestSkillInfo.text = chestData.SkillInfo.ToString();
        armsSkillName.text = armsData.SkillName.ToString();
        armsSkillInfo.text = armsData.SkillInfo.ToString();
        legsSkillName.text = legsData.SkillName.ToString();
        legsSkillInfo.text = legsData.SkillInfo.ToString();
    }
}
