using UnityEngine;

public class Collector : MonoBehaviour
{
    private int _crystals;

    public void AddCrystal()
    {
        _crystals++;
        Debug.Log($"Кристаллов собрано: {_crystals}");
    }
}