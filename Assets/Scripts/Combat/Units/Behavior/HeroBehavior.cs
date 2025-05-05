using UnityEngine;

public class HeroBehavior : Behavior
{
    public HeroBehavior(Transform transform, AutoAttacker autoAttacker, Animator animator, UnitAttributes unitAttributes)
        : base(transform, autoAttacker, animator, unitAttributes) { }

    public override void RunBehavior()
    {
        if (this.autoAttacker == null || this.autoAttacker.target == null)
        {
            this.StopWalking();
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
}
