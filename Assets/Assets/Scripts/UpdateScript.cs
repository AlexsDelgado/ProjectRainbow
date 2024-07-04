using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScript : MonoBehaviour
{
    public Sprite C_H_H;
    public Sprite H_C_H;
    public Sprite H_H_C;

    //previous +arm
    public Sprite P_C_H;
    public Sprite P_H_C;
    
    //previous + body
    public Sprite C_P_H;
    public Sprite H_P_C;
    
    //previous +legs
    public Sprite C_H_P;
    public Sprite H_C_P;
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
                
                case "C_P_H":
                    GameManager.Instance.PlayerPF.GetComponent<SpriteRenderer>().sprite = C_P_H;
                    break;
                
                case "H_P_C":
                    GameManager.Instance.PlayerPF.GetComponent<SpriteRenderer>().sprite = H_P_C;
                    break;
                
                case "C_H_P":
                    GameManager.Instance.PlayerPF.GetComponent<SpriteRenderer>().sprite = C_H_P;
                    break;
                
                case "P_C_H":
                    GameManager.Instance.PlayerPF.GetComponent<SpriteRenderer>().sprite = P_C_H;
                    break;
                case "P_H_C":
                    GameManager.Instance.PlayerPF.GetComponent<SpriteRenderer>().sprite = P_H_C;
                    break;
            }
    }
}
