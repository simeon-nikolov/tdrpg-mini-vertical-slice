using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    public float moveSpeed = 2f;

    private AutoAttacker autoAttacker;
    private Transform target;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        autoAttacker = GetComponent<AutoAttacker>();
    }

    private void Update()
    {
        if (autoAttacker == null || autoAttacker.target == null)
        {
            StopWalking();
            return;
        }

        target = autoAttacker.target;
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > autoAttacker.attackRange)
        {
            MoveTowardTarget(distance);
        }
        else
        {
            StopWalking();
        }
    }

    private void MoveTowardTarget(float distance)
    {
        StartWalking();
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += moveSpeed * Time.deltaTime * direction;
    }

    void StartWalking()
    {
        animator.SetBool(AnimatorConstants.WALKING_PARAM, true);
    }

    void StopWalking()
    {
        animator.SetBool(AnimatorConstants.WALKING_PARAM, false);
    }
}
