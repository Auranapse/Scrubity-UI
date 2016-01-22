using UnityEngine;
using System.Collections;

public class TouchCursor : MonoBehaviour
{
    Vector3 v3_InitInputPos;
    bool renderButton;

    // Use this for initialization
    void Start()
    {
        v3_InitInputPos.Set(0, 0, 0);
        renderButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputPosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            v3_InitInputPos = inputPosition;

            renderButton = true;

            this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, 10));

        }

        if (Input.GetMouseButtonUp(0))
        {
            renderButton = false;
        }

        if (renderButton)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        }
    }
}
