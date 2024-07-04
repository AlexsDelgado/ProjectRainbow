using UnityEngine;
public class IconManager : MonoBehaviour
{
    [SerializeField] private GameObject stun;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject bleeding;
    [SerializeField] private GameObject phantom;
    [SerializeField] private GameObject attack;
    [SerializeField] private GameObject burn;

    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Transform e1;
    [SerializeField] private Transform e2;

    private int enemycounter = 0;
    private int playerCounter = 0;

    public void HideIconPlayer(string icon)
    {
        switch (icon)
        {
            case "stun":
                stun.SetActive(false); 
                break;
            case "shield":
                shield.SetActive(false);
                break;
            case "bleeding":
                bleeding.SetActive(false);
                break;
            case "phantom":
                phantom.SetActive(false);
                break;
            case "attack":
                attack.SetActive(false);
                break;
            case "burn":
                burn.SetActive(false);
                break;
            default:
                break;
        }
        playerCounter--;
    }
    public void HideIconEnemy(string icon)
    {
        switch (icon)
        {
            case "stun":
                stun.SetActive(false);
                break;
            case "shield":
                shield.SetActive(false);
                break;
            case "bleeding":
                bleeding.SetActive(false);
                break;
            case "phantom":
                phantom.SetActive(false);
                break;
            case "attack":
                attack.SetActive(false);
                break;
            case "burn":
                burn.SetActive(false);
                break;
            default:
                break;
        }
        enemycounter--;
    }

    public void ShowIconPlayer(string icon)
    {
        switch (icon)
        {
            case "stun":
                stun.SetActive(true);
                if (playerCounter == 0)
                {
                    stun.transform.position = p1.position;
                }
                else
                {
                    stun.transform.position = p2.position;
                }
                break;
            case "shield":
                shield.SetActive(true);
                if (playerCounter == 0)
                {
                    shield.transform.position = p1.position;
                }
                else
                {
                    shield.transform.position = p2.position;
                }
                break;
            case "bleeding":
                bleeding.SetActive(true);
                if (playerCounter == 0)
                {
                    bleeding.transform.position = p1.position;
                }
                else
                {
                    bleeding.transform.position = p2.position;
                }
                break;
            case "phantom":
                phantom.SetActive(true);
                if (playerCounter == 0)
                {
                    phantom.transform.position = p1.position;
                }
                else
                {
                    phantom.transform.position = p2.position;
                }
                break;
            case "attack":
                attack.SetActive(true);
                if (playerCounter == 0)
                {
                    attack.transform.position = p1.position;
                }
                else
                {
                    attack.transform.position = p2.position;
                }
                break;
            case "burn":
                burn.SetActive(true);
                if (playerCounter == 0)
                {
                    burn.transform.position = p1.position;
                }
                else
                {
                    burn.transform.position = p2.position;
                }
                break;
            default:
                break;
        }
        playerCounter++;
    }

    private void ShowIconEnemy(string icon)
    {
        switch (icon)
        {
            case "stun":
                stun.SetActive(true);
                if (enemycounter == 0)
                {
                    stun.transform.position = e1.position;
                }
                else
                {
                    stun.transform.position = e2.position;
                }
                break;
            case "shield":
                shield.SetActive(true);
                if (enemycounter == 0)
                {
                    shield.transform.position = e1.position;
                }
                else
                {
                    shield.transform.position = e2.position;
                }
                break;
            case "bleeding":
                bleeding.SetActive(true);
                if (enemycounter == 0)
                {
                    bleeding.transform.position = e1.position;
                }
                else
                {
                    bleeding.transform.position = e2.position;
                }
                break;
            case "phantom":
                phantom.SetActive(true);
                if (enemycounter == 0)
                {
                    phantom.transform.position = e1.position;
                }
                else
                {
                    phantom.transform.position = e2.position;
                }
                break;
            case "attack":
                attack.SetActive(true);
                if (enemycounter == 0)
                {
                    attack.transform.position = e1.position;
                }
                else
                {
                    attack.transform.position = e2.position;
                }
                break;
            case "burn":
                burn.SetActive(true);
                if (enemycounter == 0)
                {
                    burn.transform.position = e1.position;
                }
                else
                {
                    burn.transform.position = e2.position;
                }
                break;
            default:
                break;
        }
        enemycounter++;
    }
}
