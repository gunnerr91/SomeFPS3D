using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damagePoints)
    {
        if(hitPoints > 0)
        {
            hitPoints -= damagePoints;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
