using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private MonoBehaviour _playerController;  // скрипт контроллера, любой из пяти

    private bool _isPaused;
    private CursorLockMode _savedCursorMode;  // каким был курсор до паузы

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        _isPaused = true;
        _panel.SetActive(true);
        Time.timeScale = 0f;                     // игровое время останавливается
        _playerController.enabled = false;       // контроллер перестает реагировать на ввод
        _savedCursorMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;  // курсор виден, по кнопкам можно кликать
    }

    public void Resume()
    {
        _isPaused = false;
        _panel.SetActive(false);
        Time.timeScale = 1f;
        _playerController.enabled = true;
        Cursor.lockState = _savedCursorMode;
    }

    public void Restart()
    {
        Time.timeScale = 1f;  // иначе новая сцена загрузится замороженной
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}