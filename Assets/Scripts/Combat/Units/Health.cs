using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image fillImage;
    public GameObject healthBarGO;
    private UnitAttributes attributes;
    private int currentHealth;

    void Start()
    {
        this.attributes = GetComponent<UnitAttributes>();
        this.currentHealth = this.attributes.maxHealth;
    }

    void LateUpdate()
    {
        this.healthBarGO.transform.rotation = Quaternion.Euler(45, 270, 0);
    }

    public void TakeDamage(int damage)
    {
        this.currentHealth -= damage;
        this.SetHealthBar(this.currentHealth);
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining HP: {this.currentHealth}");

        if (this.currentHealth <= 0)
        {
            this.Die();
        }
    }

    public void SetHealthBar(float currentHealth)
    {
        this.fillImage.fillAmount = currentHealth / this.attributes.maxHealth;
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        Destroy(this.gameObject);
    }
}
