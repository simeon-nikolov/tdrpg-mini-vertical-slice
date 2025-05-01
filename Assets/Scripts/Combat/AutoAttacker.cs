using UnityEngine;

public class AutoAttacker : MonoBehaviour
{
    public float attackInterval = 2f;
    public int attackDamage = 10;
    public float attackRange = 1.5f;
    public Transform target;
    private Animator animator;

    private float attackTimer = 1.9f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= attackRange)
        {
            TickAutoAttack();
        }
        else
        {
            //attackTimer = 1.9f;
        }
    }

    void TickAutoAttack()
    {
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
            animator.SetTrigger(AnimatorConstants.ATTACK_TRIGGER);
            enemyHealth.TakeDamage(attackDamage);
        }
    }
}
