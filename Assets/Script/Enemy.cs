using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collision();
    }
    protected virtual void Collision()
    {
        //override
    }
}
