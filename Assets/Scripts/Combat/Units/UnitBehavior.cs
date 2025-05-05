using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    private AutoAttacker autoAttacker;
    private Animator animator;
    private UnitAttributes unitAttributes;
    private Behavior behavior;

    private void Start()
    {
        this.unitAttributes = GetComponent<UnitAttributes>();
        this.animator = GetComponent<Animator>();
        this.autoAttacker = GetComponent<AutoAttacker>();
        this.behavior = GetBehaviorByUnitType();
    }

    private void Update()
    {
        this.behavior.RunBehavior();
    }

    private Behavior GetBehaviorByUnitType()
    {
        if (this.unitAttributes.unitTag == UnitTags.Enemy)
        {
            return new EnemyBehavior(this.transform, this.autoAttacker, this.animator, this.unitAttributes);
        }

        return new HeroBehavior(this.transform, this.autoAttacker, this.animator, this.unitAttributes);
    }


}
