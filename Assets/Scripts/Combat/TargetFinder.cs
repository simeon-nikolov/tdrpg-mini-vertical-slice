using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    public string enemyTag = "Enemy";

    private AutoAttacker autoAttacker;

    void Start()
    {
        autoAttacker = GetComponent<AutoAttacker>();

        if (autoAttacker != null)
        {
            FindTarget();
        }
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            autoAttacker.target = closestEnemy.transform;
        }
    }
}
