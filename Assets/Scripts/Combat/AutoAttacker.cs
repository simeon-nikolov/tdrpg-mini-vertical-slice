using UnityEngine;

public class AutoAttacker : MonoBehaviour
{
    public float attackInterval = 2f;
    public int attackDamage = 10;
    public Transform target;

    private float attackTimer;

    void Update()
    {
        if (target == null) return;

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            attackTimer = 0f;
            Attack();
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
