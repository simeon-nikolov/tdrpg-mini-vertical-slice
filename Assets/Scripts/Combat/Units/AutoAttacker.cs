using UnityEngine;

public class AutoAttacker : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    private UnitAttributes unitAttributes;
    private bool isAttackAnimationTriggered = false;

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

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private bool ShouldTriggerAttackAnimation(float attackInterval)
    {
        return !this.isAttackAnimationTriggered && attackInterval - this.attackTimer < 0.2;
    }

    void TickAutoAttack()
    {
        this.attackTimer += Time.deltaTime;
        float attackInterval = this.unitAttributes.attackInterval;

        if (this.ShouldTriggerAttackAnimation(attackInterval))
        {
            this.isAttackAnimationTriggered = true;
            this.animator.SetTrigger(AnimatorConstants.ATTACK_TRIGGER);
        }

        if (this.attackTimer >= attackInterval)
        {
            this.attackTimer = 0f;
            this.isAttackAnimationTriggered = false;
            this.Attack();
        }
    }

    void Attack()
    {
        Health enemyHealth = this.target.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(this.unitAttributes.attackDamage);
        }
    }
}
