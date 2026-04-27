using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayPontos : MonoBehaviour
{
   public void atualizarTextoPontos (double contagemPontos, TextMeshProUGUI texto_a_mudar, string optionalEndText = null)
    { //Numeros, ao ficar muito grandes serão abreviados com uma letra no final
        /*
            * sufixos:
            * k = mil
            * M = milhão
            * B = bilhão
            * T = trilhão
            * Q = quadri... e eu sei la
        */
        string[] sufixos = {"","k","M","B","T","Q"};
        int index = 0;
        while (contagemPontos >= 1000 && index < sufixos.Length - 1)
        {
            contagemPontos /= 1000;
            index++;
            if (index >= sufixos.Length - 1 && contagemPontos >= 1000)
            {
                break;
            }
        }
        string textoFormatado;
        if (index == 0)
        {
            textoFormatado = contagemPontos.ToString();
        } else
        {
            textoFormatado = contagemPontos.ToString("F1"); //f1 apenas uma casa decial
        }
        texto_a_mudar.text = textoFormatado + optionalEndText;
    }
}
