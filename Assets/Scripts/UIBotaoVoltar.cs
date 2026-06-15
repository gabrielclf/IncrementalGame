using UnityEngine;
using UnityEngine.UI;

public class UIBotaoVoltar : MonoBehaviour
{
    [SerializeField]
    private Button MyButton = null; // assign in the editor

    ClickerManager ck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ck = GameObject.FindGameObjectWithTag("Manager").GetComponent<ClickerManager>();
        MyButton.onClick.AddListener(Voltar);
    }

    public void Voltar()
    {
        ck.ApertarBotaoVoltarJogo();
    }
}
