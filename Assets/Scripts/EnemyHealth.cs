using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public bool IsDead { get; set; }

    public void TakeDamage(float damagePoints)
    {
        BroadcastMessage("OnDamageTaken");
        if(hitPoints > 0)
        {
            hitPoints -= damagePoints;
        }
        
        if(hitPoints < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        if (IsDead)
        {
            return;
        }

        IsDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
