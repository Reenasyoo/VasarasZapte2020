using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Lever : MonoBehaviour
{

    public BoxCollider2D target;

    private void Open()
    {
        target.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Open();
    }
}
