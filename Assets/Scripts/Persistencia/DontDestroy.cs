using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Não destruir objetos ao passar de cena para cena
    private static GameObject[] objetosPersistentes = new GameObject[3];
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

}
