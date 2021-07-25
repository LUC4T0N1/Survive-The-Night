using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class esconder : MonoBehaviour{
    public GameObject jogador;
    public GameObject esconderijo;
    public Text esconderText;
    public Text sair;
    public bool podeEsconder;
    public bool taEscondido;
    public GameObject monstro;
    public GameObject monstro2;
    public GameObject monstro3;
    public GameObject monstro4;
    private inteligenciaMonstro2Fase1 inteligencia1;
    private inteligenciaMonstro2Fase1 inteligencia2;
    private inteligenciaMonstro2Fase1 inteligencia3;
    private inteligenciaMonstro2Fase1 inteligencia4;
  
    void OnTriggerEnter(Collider eu){
        if (eu.gameObject.tag == "Player")
        {
            esconderText.enabled = true;
            podeEsconder = true;
            inteligencia1.aleatorio = Random.Range(1, 3);
            inteligencia2.aleatorio = Random.Range(1, 3);
            inteligencia3.aleatorio = Random.Range(1, 3);
            inteligencia4.aleatorio = Random.Range(1, 3);
        }
    }
    void OnTriggerExit(){
        if (jogador.gameObject.tag == "Player")
        {
            esconderText.enabled = false;
            podeEsconder = false;
        }
    }
    void Update(){
	if (Input.GetButtonDown("esconder") && podeEsconder && !taEscondido){
            jogador.SetActive(false);
		esconderijo.SetActive(true);
            esconderText.enabled=false;
		taEscondido=true;
		sair.enabled=true;
		podeEsconder=false;
		inteligencia1.jogadorEscondido=true;
		inteligencia2.jogadorEscondido=true;
		inteligencia3.jogadorEscondido=true;
		inteligencia4.jogadorEscondido=true;
        }
	else if(Input.GetButtonDown("esconder") && taEscondido){
            jogador.SetActive(true);
            esconderijo.SetActive(false);
		sair.enabled=false;
		podeEsconder=true;
		taEscondido=false;
		inteligencia1.jogadorEscondido=false;
		inteligencia2.jogadorEscondido=false;
		inteligencia3.jogadorEscondido=false;
		inteligencia4.jogadorEscondido=false;
        }
	if(taEscondido){
            esconderText.enabled=false;
	}	
    }
    void Start(){
        esconderText.enabled=false;
	sair.enabled=false;
	inteligencia1=monstro.GetComponent<inteligenciaMonstro2Fase1>();
	inteligencia2=monstro2.GetComponent<inteligenciaMonstro2Fase1>();
	inteligencia3=monstro3.GetComponent<inteligenciaMonstro2Fase1>();
	inteligencia4=monstro4.GetComponent<inteligenciaMonstro2Fase1>();

    }
}
