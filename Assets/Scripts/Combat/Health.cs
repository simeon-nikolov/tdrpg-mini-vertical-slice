using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Image fillImage;
    public GameObject healthBarGO;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void LateUpdate()
    {
        this.healthBarGO.transform.rotation = Quaternion.Euler(45, 270, 0);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        this.SetHealthBar(currentHealth);
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            this.Die();
        }
    }

    public void SetHealthBar(float current)
    {
        this.fillImage.fillAmount = current / this.maxHealth;
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        Destroy(this.gameObject);
    }
}
