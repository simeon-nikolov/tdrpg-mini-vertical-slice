using UnityEngine;

public class AutoAttacker : MonoBehaviour
{
    public float attackInterval = 2f;
    public int attackDamage = 10;
    public float attackRange = 1.5f;
    public Transform target;

    private float attackTimer;

    void Update()
    {
        if (target == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= attackRange)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackInterval)
            {
                attackTimer = 0f;
                Attack();
            }
        }
        else
        {
            attackTimer = 0f;
        }
    }

    void Attack()
    {
        Health enemyHealth = target.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
    }
}
