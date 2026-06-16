using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    // Não destruir objetos ao passar de cena para cena
    private static GameObject[] objetosPersistentes = new GameObject[10];
    public int indexOP; //indice de quantos objetos persistentes irão ter
    void Awake()
    {
        if (objetosPersistentes[indexOP] == null)
        {
            objetosPersistentes[indexOP] = gameObject;
            DontDestroyOnLoad(gameObject);     
        } else if (objetosPersistentes != null) //no caso de ocorrer duplicação de gameobjects ao trocar cenas
        {
            Destroy (gameObject);
        }
        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //16/06/2026 - Inserindo Condição de Vitória 
        if (SceneManager.GetActiveScene().name == "Vitoria")
        {
             //16/06/2026 - Destruindo objetos persistentes para garantir restart sem erros
            Destroy(gameObject);
        }
    }

}
