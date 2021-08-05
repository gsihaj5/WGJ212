using System;
using UnityEngine;
using Object = System.Object;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}