using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativarLanterna : MonoBehaviour
{
    interacaoObjetos interacaoObjetos;
    public GameObject jogador;
    public GameObject lanterna;
    void Start()
    {
        interacaoObjetos = jogador.GetComponent<interacaoObjetos>();
    }

    
    void Update()
    {
        if(interacaoObjetos.temLanterna && (Input.GetButtonDown("1"))){
            lanterna.SetActive(true);
        }
        else if (interacaoObjetos.temLanterna && (Input.GetButtonDown("2"))){
            lanterna.SetActive(false);
        }
    }
}
