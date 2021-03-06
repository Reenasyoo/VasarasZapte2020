﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (this.gameObject.tag)
        {
            case "Red":
                {
                    if (collision.tag == "Female") 
                    {   
                        Debug.Log("Male has entered blue's water");

                        GameManager.instance.ResetPlayerPos(collision.gameObject, "Female");
                    }
                    break;
                }
            case "Blue":
                {
                    if (collision.tag == "Male")
                    {
                        Debug.Log("Female has entered red's water");

                        GameManager.instance.ResetPlayerPos(collision.gameObject, "Male");
                    }
                    break;
                }
            default:
                {
                    break;
                }

        }
    }
}
