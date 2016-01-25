using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbilityButton1 : MonoBehaviour
{
    public GameObject ship;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ship.GetComponent<Ship>().getAbility1IsActive())
        {
            GetComponent<TextMesh>().text = ((int)ship.GetComponent<Ship>().f_Ability1Duration - (int)ship.GetComponent<Ship>().getAbility1()).ToString();
            GetComponent<TextMesh>().color = new Color(1, 0, 0);
            this.GetComponent<Button>().interactable = false;
        }
        else if (!ship.GetComponent<Ship>().getAbility1IsActive() && ship.GetComponent<Ship>().getAbility1() < ship.GetComponent<Ship>().f_Ability1Recharge)
        {
            GetComponent<TextMesh>().text = ((int)ship.GetComponent<Ship>().f_Ability1Recharge - (int)ship.GetComponent<Ship>().getAbility1()).ToString();
            GetComponent<TextMesh>().color = new Color(1, 1, 1);
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<TextMesh>().text = "";
            this.GetComponent<Button>().interactable = true;
        }
    }
}
