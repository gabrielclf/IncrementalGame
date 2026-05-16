using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonController : MonoBehaviour
{ //Metodo de controle para botoes da interface

    public static bool _gameIsPaused = false;

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void ApertarBotaoMudarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void ApertarBotaoFechar()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif        
        Application.Quit();
    }
}
