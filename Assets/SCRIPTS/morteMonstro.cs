using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morteMonstro : MonoBehaviour{
    inteligenciaMonstroFase2 Ai;
    public bool tomaMaisTiro = true;
    private Animator anim;
    private Collider collider;
    public float tempom = 5.0f;
    [SerializeField]private float health = 100f;
    void Start(){
        collider = GetComponent<Collider>();
	anim = GetComponent<Animator>();
    }
    public void Takedamage(float damage){
	if(tomaMaisTiro == true){
		health -= damage;
		if(health<=0f){
                collider.enabled = false;
			Ai=GetComponent<inteligenciaMonstroFase2>();
                Ai.vivo = false;
            Morrendo();
			Die();
			tomaMaisTiro=false;
		}
	}
    }
    void Morrendo(){
	anim.CrossFadeInFixedTime("caindo", 0.01f);
	
    }
    
    void Die(){
	Destroy(gameObject, tempom);
    }
}
