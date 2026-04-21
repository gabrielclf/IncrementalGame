using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public string _cenaACarregar;

    public void ApertarBotaoIniciar()
    {
        SceneManager.LoadScene(_cenaACarregar);
    }

    public void ApertarBotaoOpcoes()
    {
        
    }

    public void ApertarBotaoFechar()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif        
        Application.Quit();
    }
}
