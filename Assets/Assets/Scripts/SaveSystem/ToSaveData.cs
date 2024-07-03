using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SaveData", menuName = "SaveData")]
public class ToSaveData : ScriptableObject
{
    [SerializeField] private int skillId;
    [SerializeField] private string skillName;
    [SerializeField] private string skillInfo;
    [SerializeField] private Image skillImage;

    public int SkillId => skillId;
    public string SkillName => skillName;
    public string SkillInfo => skillInfo;
    public Image SkillImage => skillImage;

}
