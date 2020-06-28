using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Opener : MonoBehaviour
{
    public BoxCollider2D target;

    private void Open()
    {
        target.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (this.gameObject.tag)
        {
            case "Blue":
                {
                    if (collision.tag == "Female")
                    {
                        Open();
                    }
                    break;
                }
            case "Red":
                {
                    if (collision.tag == "Male")
                    {
                        Open();
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
