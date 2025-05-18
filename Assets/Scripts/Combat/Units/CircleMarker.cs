using UnityEngine;

public class CircleMarker : MonoBehaviour
{
    void Start()
    {
        UnitAttributes unitAttributes = GetComponentInParent<UnitAttributes>();
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && unitAttributes != null)
        {
            Color color = ColorMappings.GetUnitColorByType(unitAttributes.unitType);
            renderer.material.color = color;
        }
    }

    public void SetSelected()
    {
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void Deselect()
    {
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
