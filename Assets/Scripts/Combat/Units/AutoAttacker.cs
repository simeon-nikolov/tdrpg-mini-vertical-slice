using UnityEngine;

public class AutoAttacker : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    private UnitAttributes unitAttributes;

    private float attackTimer = 1.9f;

    private void Start()
    {
        this.unitAttributes = GetComponent<UnitAttributes>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (this.target == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= this.unitAttributes.attackRange)
        {
            this.TickAutoAttack();
        }
        else
        {
            //attackTimer = 1.9f;
        }
    }

    void TickAutoAttack()
    {
        this.attackTimer += Time.deltaTime;

        if (this.attackTimer >= this.unitAttributes.attackInterval)
        {
            this.attackTimer = 0f;
            this.Attack();
        }
    }

    void Attack()
    {
        Health enemyHealth = this.target.GetComponent<Health>();
        if (enemyHealth != null)
        {
            this.animator.SetTrigger(AnimatorConstants.ATTACK_TRIGGER);
            enemyHealth.TakeDamage(this.unitAttributes.attackDamage);
        }
    }
}
