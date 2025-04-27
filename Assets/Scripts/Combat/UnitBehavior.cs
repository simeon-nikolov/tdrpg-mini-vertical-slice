using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    public float moveSpeed = 2f;

    private AutoAttacker autoAttacker;
    private Transform target;

    private void Start()
    {
        autoAttacker = GetComponent<AutoAttacker>();
    }

    private void Update()
    {
        if (autoAttacker == null)
            return;

        target = autoAttacker.target;

        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > autoAttacker.attackRange)
        {
            // Move toward the target
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += moveSpeed * Time.deltaTime * direction;
        }
    }
}
