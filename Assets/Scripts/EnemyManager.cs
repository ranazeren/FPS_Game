using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int EnemyHealth = 200;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
     public void EnemyTakeDamage(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;

        if (EnemyHealth <= 0)
        {
            EnemyDeath();

        }

    }
    void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
