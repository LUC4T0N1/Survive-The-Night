using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPortas : MonoBehaviour{
    public bool aberta = false;
    public float anguloAbertura=90f;
    public float anguloFechadura=0f;
    public float suavidade = 2f;
    public int aleatorio;

    void Start(){
        aleatorio=Random.Range(1,3);
	if(aleatorio==1){
		aberta=true;
	}
	else{
		aberta=false;
	}
    }

    public void ChangeDoorState(){
	aberta = !aberta;
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
}
