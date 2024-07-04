using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SaveData", menuName = "SaveData")]
public class ToSaveData : ScriptableObject
{
    public string SkillName;
    public string SkillInfo;
    public Image SkillImage;
}
