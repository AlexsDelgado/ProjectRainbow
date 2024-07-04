using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScript : MonoBehaviour
{
    public Sprite C_H_H;
    public Sprite H_C_H;
    public Sprite H_H_C;

    public void ChangeSprite(string id)
    {
        switch (id)
        {
            case "C_H_H":
                GameManager.Instance.PlayerPF.GetComponent<SpriteRenderer>().sprite = C_H_H;
                break;
            case "H_C_H":
                GameManager.Instance.PlayerPF.GetComponent<SpriteRenderer>().sprite = H_C_H;
                break;
            case "H_H_C":
                GameManager.Instance.PlayerPF.GetComponent<SpriteRenderer>().sprite = H_H_C;
                break;
        }
    }
}
