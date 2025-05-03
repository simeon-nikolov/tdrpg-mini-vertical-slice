using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public int maxHealth = 100;
    private int currentHealth;
    private HealthBarUI healthBarUI;
    private GameObject healthBarGameObject;

    void Start()
    {
        currentHealth = maxHealth;
        healthBarGameObject = Instantiate(healthBarPrefab);
        healthBarUI = healthBarGameObject.GetComponent<HealthBarUI>();
        healthBarUI.target = transform;
        healthBarUI.SetHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarUI.SetHealth(currentHealth, maxHealth);
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        Destroy(gameObject);
        Destroy(healthBarGameObject);
    }
}
