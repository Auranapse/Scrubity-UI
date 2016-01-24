using UnityEngine;
using System.Collections;

public class G_Fading : MonoBehaviour
{
    SpriteRenderer sprite;
    Color colour;
    public float startFade;
    public float FadeSpeed;
    float timer;

    // Use this for initialization
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        colour = sprite.color;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (colour.a > 0)
        {
            if (timer > startFade)
            {
                colour.a -= FadeSpeed * Time.deltaTime;
                sprite.color = colour;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
