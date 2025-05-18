using UnityEngine;

public static class ColorMappings
{
    public readonly static Color DarkGreen = new(0, 0.6f, 0);

    public static Color GetUnitColorByType(UnitTypes unitType)
    {
        switch (unitType)
        {
            case UnitTypes.Fighter:
                return Color.red;
            case UnitTypes.Knight:
                return Color.blue;
            case UnitTypes.Archer:
                return Color.yellow;
            case UnitTypes.Healer:
                return DarkGreen;
            case UnitTypes.Wizard:
                return Color.magenta;
            default:
                return Color.white;

        }
    }
}
