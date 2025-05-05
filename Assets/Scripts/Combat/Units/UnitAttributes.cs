using UnityEngine;

public class UnitAttributes : MonoBehaviour
{
    public UnitTypes unitType;
    public UnitTags unitTag;
    public UnitTags enemyTag;
    public float attackRange = 1.5f;
    public float attackInterval = 2f;
    public int attackDamage = 10;
    public int maxHealth = 100;
    public float moveSpeed = 2f;
    public bool isMeleeRange;
}
