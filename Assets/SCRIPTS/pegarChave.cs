using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pegarChave : MonoBehaviour
{
    interacaoObjetos pega;
    public Text pegarText;
    public GameObject jogador;
    void Start()
    {
        pega = jogador.GetComponent<interacaoObjetos>();
    }
    void OnTriggerEnter(Collider jogador)
    {
        if (jogador.gameObject.tag == "Player")
        {
            pegarText.enabled = true;
            pega.podePegarChave = true;
        }

    }

    void OnTriggerExit(Collider eu)
    {
        if (eu.gameObject.tag == "Player")
        {
            pegarText.enabled = false;
            pega.podePegarChave = false;
        }

    }
}