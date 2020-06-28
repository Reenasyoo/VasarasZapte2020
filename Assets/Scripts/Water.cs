using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Water : MonoBehaviour
{
    public BoxCollider2D kolis;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (this.gameObject.tag)
        {
            case "Blue":
                {
                    if (collision.tag == "Male") 
                    {
                    
                    }
                    break;
                }
            case "Red":
                {
                    if (collision.tag == "Female")
                    {
                        
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
