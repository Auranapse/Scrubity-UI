using UnityEngine;
using System.Collections;

public class G_Fading_End : MonoBehaviour
{
    SpriteRenderer sprite;
    Color colour;
    public float FadeSpeed;
    public GameObject GlobalFunctions;

    // Use this for initialization
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        colour = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalFunctions.GetComponent<GameRuntimeHandler>().GAME_STATE == GameRuntimeHandler.GAME_STATES.DEATH)
        {
            if (colour.a > 0)
            {

                colour.a -= FadeSpeed * Time.deltaTime;
                sprite.color = colour;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
