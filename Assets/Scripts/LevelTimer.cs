using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;

    void Update()
    {
        // Секунды с момента загрузки сцены, округленные до целого числа
        _timerText.text = Time.timeSinceLevelLoad.ToString("0");
    }
}