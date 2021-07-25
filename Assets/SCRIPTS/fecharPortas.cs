using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fecharPortas : MonoBehaviour{
    public bool aberta = false;
    public float anguloAbertura=90f;
    public float anguloFechadura=0f;
    public float suavidade = 2f;
    public AudioSource audioPortas;
    public Text precisaDeChave;
    void Start()
    {
        precisaDeChave.enabled=false;
    }

    public void ChangeDoorState(){
	aberta = !aberta;
	audioPortas.Play();
	
    }
    void Update(){
	if(aberta){
        	Quaternion targetRotation = Quaternion.Euler(0, anguloAbertura, 0);
		transform.localRotation=Quaternion.Slerp(transform.localRotation, targetRotation, suavidade * Time.deltaTime);
	
	}
	else{
		
		Quaternion targetRotation2 = Quaternion.Euler(0, anguloFechadura, 0);
		transform.localRotation=Quaternion.Slerp(transform.localRotation, targetRotation2, suavidade * Time.deltaTime);
		
	}
    }
    void Sum(){
	precisaDeChave.enabled=false;
    }
    public void MostrAe(){
	Invoke("Sum",3);
	precisaDeChave.enabled=true;
    }
}
