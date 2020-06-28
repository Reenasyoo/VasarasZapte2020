using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D)]
public class Water : MonoBehaviour
{
    public BoxCollider2D kolis;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (this.gameObject.tag)
        {
            case "Blue":
                {
                    if (collision.tag == "Male") 
                    {   
                        Debug.Log("Male has entered blue's water");

                        GameManager.instance.ResetPlayerPos(kolis.gameObject, "Male");
                    }
                    break;
                }
            case "Red":
                {
                    if (collision.tag == "Female")
                    {
                        Debug.Log("Female has entered red's water");

                        GameManager.instance.ResetPlayerPos(kolis.gameObject, "Female");
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
