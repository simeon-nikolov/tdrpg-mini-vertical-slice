using UnityEngine;

public class EnemyBehavior : Behavior
{
    public EnemyBehavior(Transform transform, AutoAttacker autoAttacker, Animator animator, UnitAttributes unitAttributes)
        : base(transform, autoAttacker, animator, unitAttributes) { }

    public override void RunBehavior()
    {
        if (this.autoAttacker == null || this.autoAttacker.target == null)
        {
            if (this.IsMeleeRange())
            {

                this.MoveRight();
            }
            return;
        }

        float distance = Vector3.Distance(this.transform.position, this.autoAttacker.target.position);

        if (distance > this.unitAttributes.attackRange)
        {
            this.MoveTowardTarget();
        }
        else
        {
            this.StopWalking();
        }
    }

    private bool IsMeleeRange()
    {
        var unitType = this.unitAttributes.unitType;
        return unitType == UnitTypes.Fighter || unitType == UnitTypes.Knight;
    }

    private void MoveRight()
    {
        this.StartWalking();
        var direction = new Vector3(0, 0, 1);
        this.transform.position += this.unitAttributes.moveSpeed * Time.deltaTime * direction;
    }
}
