using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class vidaJogador : MonoBehaviour
{
    public int PontosVida;
    public Text vidaTexto;
    public GameObject monstro1;
    public GameObject monstro2;
    private inteligenciaMonstroFase2 script;

    void Start(){
        script = monstro1.GetComponent<inteligenciaMonstroFase2>();
    }

 
    void Update(){
        
    }

    void OnEnable()
    {
        UpdateVidaText();
    }
    public void PerdePonto(int pontos)
    {
        PontosVida = PontosVida - pontos;
        UpdateVidaText();
        if (PontosVida <= 0) {
            script.morte();
        }
    }

    public void UpdateVidaText()
    {
        vidaTexto.text = "Vida: " + PontosVida;
    }
}
