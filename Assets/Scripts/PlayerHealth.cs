using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damageHitPoints)
    {
        hitPoints -= damageHitPoints;
        if(hitPoints < 1)
        {
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log("Game over!!");
        }
    }

}
