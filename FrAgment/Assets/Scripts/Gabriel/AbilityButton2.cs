using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbilityButton2 : MonoBehaviour
{
    public GameObject ship;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ship.GetComponent<Ship>().getAbility2IsActive())
        {
            GetComponent<TextMesh>().text = ((int)ship.GetComponent<Ship>().f_Ability2Duration - (int)ship.GetComponent<Ship>().getAbility2()).ToString();
            GetComponent<TextMesh>().color = new Color(1, 0, 0);
            this.GetComponent<Button>().interactable = false;
        }
        else if (!ship.GetComponent<Ship>().getAbility2IsActive() && ship.GetComponent<Ship>().getAbility2() < ship.GetComponent<Ship>().f_Ability2Recharge)
        {
            GetComponent<TextMesh>().text = ((int)ship.GetComponent<Ship>().f_Ability2Recharge - (int)ship.GetComponent<Ship>().getAbility2()).ToString();
            GetComponent<TextMesh>().color = new Color(1, 1, 1);
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
        }
    }
}
