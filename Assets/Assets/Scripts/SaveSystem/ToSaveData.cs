using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SaveData", menuName = "SaveData")]
public class ToSaveData : ScriptableObject
{
    public int SkillId;
    public string SkillInfo;
    public Image SkillImage;
}
