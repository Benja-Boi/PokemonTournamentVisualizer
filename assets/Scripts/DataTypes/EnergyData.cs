using UnityEngine;

namespace DataTypes
{
    [CreateAssetMenu(fileName = "EnergyData", menuName = "Other/EnergyData", order = 1)]
    public class EnergyData : ScriptableObject
    {
        public Sprite sprite;
        public Color primaryColor;
        public Color secondaryColor;
        public new string name;
    }
}
