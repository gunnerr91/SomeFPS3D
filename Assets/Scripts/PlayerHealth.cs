using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damageHitPoints)
    {
        hitPoints -= damageHitPoints;
        if(hitPoints < 1)
        {
            Debug.Log("Game over!!");
        }
    }

}
