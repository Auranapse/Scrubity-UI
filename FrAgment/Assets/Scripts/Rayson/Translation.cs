﻿using UnityEngine;
using System.Collections;

public class Translation : MonoBehaviour
{

    public Vector3 EndPos;
    public float Movement_Speed;
    public float StartAnimation;

    private RectTransform Entity;
    private Vector3 LerpValue;
    private float Timer;

    public Vector3 InitialPos;

    // Use this for initialization
    void Start()
    {
        Entity = this.GetComponent<RectTransform>();
        InitialPos = Entity.position;
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > StartAnimation)
        {
            LerpValue.Set(Mathf.Lerp(Entity.localPosition.x, EndPos.x, Movement_Speed * Time.deltaTime),
                          Mathf.Lerp(Entity.localPosition.y, EndPos.y, Movement_Speed * Time.deltaTime),
                          Entity.localPosition.z);

            Entity.localPosition = LerpValue;
        }
    }
}
