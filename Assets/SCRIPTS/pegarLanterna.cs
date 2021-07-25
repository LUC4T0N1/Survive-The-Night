using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pegarLanterna : MonoBehaviour {
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
            pega.podePegarLanterna = true;
        }

    }

    void OnTriggerExit(Collider jogador)
    {
        if (jogador.gameObject.tag == "Player")
        {
            pegarText.enabled = false;
            pega.podePegarLanterna = false;
        }

    }
}
