using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    public float moveSpeed = 2f;

    private AutoAttacker autoAttacker;
    private Animator animator;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.autoAttacker = GetComponent<AutoAttacker>();
    }

    private void Update()
    {
        if (this.autoAttacker == null || this.autoAttacker.target == null)
        {
            this.StopWalking();
            return;
        }

        float distance = Vector3.Distance(this.transform.position, this.autoAttacker.target.position);

        if (distance > this.autoAttacker.attackRange)
        {
            this.MoveTowardTarget(distance);
        }
        else
        {
            this.StopWalking();
        }
    }

    private void MoveTowardTarget(float distance)
    {
        this.StartWalking();
        Vector3 direction = (this.autoAttacker.target.position - this.transform.position).normalized;
        this.transform.position += this.moveSpeed * Time.deltaTime * direction;
    }

    void StartWalking()
    {
        this.animator.SetBool(AnimatorConstants.WALKING_PARAM, true);
    }

    void StopWalking()
    {
        this.animator.SetBool(AnimatorConstants.WALKING_PARAM, false);
    }
}
