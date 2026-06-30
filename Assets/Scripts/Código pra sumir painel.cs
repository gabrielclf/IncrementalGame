using UnityEngine;

public class Códigoprasumirpainel : MonoBehaviour
{
    [SerializeField] GameObject painel;
    
    public void ControlaPainel()
    {
        if (painel.activeSelf == true)
        {

            painel.SetActive(false);

        }
        else if (painel.activeSelf == false)
        {
            painel.SetActive(true);
        }
    }
}
