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
        if (this.IsLeftMouseButtonClicked())
        {
            Ray ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var clickedUnit = hit.collider.GetComponent<UnitAttributes>();
                if (clickedUnit != null)
                {
                    if (clickedUnit.unitTag == UnitTags.Hero)
                    {
                        this.DeselectHero();
                        this.SelectHero(clickedUnit);
                    }
                    else if (clickedUnit.unitTag == UnitTags.Enemy && this.selectedHero != null)
                    {
                        this.selectedHero.SetTarget(hit.transform);
                    }
                }
            }
        }
    }

    private bool IsLeftMouseButtonClicked()
    {
        return Input.GetMouseButtonDown(0);
    }

    private void SelectHero(UnitAttributes clickedUnit)
    {
        this.selectedHero = clickedUnit.GetComponent<AutoAttacker>();

        if (this.selectedHero != null)
        {
            CircleMarker circleMarker = this.selectedHero.GetComponentInChildren<CircleMarker>();

            if (circleMarker)
            {
                circleMarker.SetSelected();
            }
        }
    }

    private void DeselectHero()
    {
        if (this.selectedHero != null)
        {
            CircleMarker circleMarker = this.selectedHero.GetComponentInChildren<CircleMarker>();

            if (circleMarker)
            {
                circleMarker.Deselect();
            }
        }
    }
}
