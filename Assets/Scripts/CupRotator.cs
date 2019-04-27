﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupRotator : MonoBehaviour
{
    private bool cursorHits = false;
    private bool cupFlipped = false;
    float speed = -0.01f;

    public Camera camera;

    //variables for casting the ray
    float rayLength = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        if (Physics.Raycast(cursorRay, out hit, rayLength))
        {
            Debug.Log("in cup flip");
            if (hit.collider.gameObject.name == "CupCollider" && hit.collider.isTrigger)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Debug.Log("Cup was clicked");
                    cursorHits = true;
                }
            }
        }

        if (cursorHits && !cupFlipped)
        {
            transform.Rotate(new Vector3(transform.localPosition.x, 0), 180f);
            cupFlipped = true;
            cursorHits = false;
        }
        
        if (cursorHits && cupFlipped)
        {
            transform.Rotate(new Vector3(transform.localPosition.x, 0), -180f);
            cupFlipped = false;
            cursorHits = false;
        }
    }
}
