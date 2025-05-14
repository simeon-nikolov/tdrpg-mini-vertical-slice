using UnityEngine;

public class HeroTargetController : MonoBehaviour
{
    private Camera mainCamera;
    private AutoAttacker selectedHero;

    void Start()
    {
        this.mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var clickedUnit = hit.collider.GetComponent<UnitAttributes>();
                if (clickedUnit != null)
                {
                    if (clickedUnit.unitTag == UnitTags.Hero)
                    {
                        selectedHero = clickedUnit.GetComponent<AutoAttacker>();
                    }
                    else if (clickedUnit.unitTag == UnitTags.Enemy && this.selectedHero != null)
                    {
                        this.selectedHero.SetTarget(hit.transform);
                        this.selectedHero = null;
                    }
                }
            }
        }
    }
}
