using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    private AutoAttacker autoAttacker;
    private UnitAttributes unitAttributes;

    void Start()
    {
        this.unitAttributes = GetComponent<UnitAttributes>();
        this.autoAttacker = GetComponent<AutoAttacker>();
    }

    private void Update()
    {
        if (this.autoAttacker != null && this.autoAttacker.target == null)
        {
            this.FindTarget();
        }
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(this.unitAttributes.enemyTag.ToString());
        GameObject closestEnemy = null;
        float closestDistance = this.unitAttributes.attackRange;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            this.autoAttacker.target = closestEnemy.transform;
        }
    }
}
