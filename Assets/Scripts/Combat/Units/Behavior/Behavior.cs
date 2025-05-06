using UnityEngine;

public abstract class Behavior
{
    protected readonly Transform transform;
    protected readonly AutoAttacker autoAttacker;
    protected readonly Animator animator;
    protected readonly UnitAttributes unitAttributes;

    protected Behavior(Transform transform, AutoAttacker autoAttacker, Animator animator, UnitAttributes unitAttributes)
    {
        this.transform = transform;
        this.autoAttacker = autoAttacker;
        this.animator = animator;
        this.unitAttributes = unitAttributes;
    }

    abstract public void RunBehavior();

    public void MoveTowardTarget()
    {
        this.StartWalking();
        Vector3 direction = (this.autoAttacker.target.position - this.transform.position).normalized;
        this.transform.position += this.unitAttributes.moveSpeed * Time.deltaTime * direction;
    }

    public void StartWalking()
    {
        this.animator.SetBool(AnimatorConstants.WALKING_PARAM, true);
    }

    public void StopWalking()
    {
        this.animator.SetBool(AnimatorConstants.WALKING_PARAM, false);
    }
}
