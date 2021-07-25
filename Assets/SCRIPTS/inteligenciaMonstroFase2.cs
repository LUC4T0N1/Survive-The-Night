using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class inteligenciaMonstroFase2 : MonoBehaviour
{
	private Scene cena;
	private NavMeshAgent navComponent;
	public int distanciaAtrairMonstro = 20;
	public bool vivo = true;
	public Transform jogador;
	public Transform monstro;
	private Animator anim;
	public float distanciaParaAtacar = 0.2f;
	public AudioSource somMonmstro;
	public bool correndo;
	public Text morreu;
	public GameObject monstroCenaMorte;
	public GameObject cameraJogador;
	public GameObject cameraDaMorte;
	public GameObject jogadorObjeto;
	private vidaJogador vidaScript;
	public int dano;
	public bool podeDarDano;
	public Text municao;
	public Text vida;

	void Start()
    {
	morreu.enabled=false;
		vidaScript = jogadorObjeto.GetComponent<vidaJogador>();
	cena=SceneManager.GetActiveScene();
	Tocar();
	anim = GetComponent<Animator>();
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update(){
	if(vivo){
		
		if(Vector3.Distance(jogador.position, this.transform.position) < distanciaAtrairMonstro){
			Vector3 direction = jogador.position - this.transform.position;
			direction.y=0;
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 5.0f*Time.deltaTime);
			
			anim.SetBool("parado",false);
			if(direction.magnitude>distanciaParaAtacar){
				navComponent.SetDestination(jogador.position);
				anim.SetBool("andando",true);
				anim.SetBool("atacando",false);
				correndo=true;
					podeDarDano = false;
			}
			else{
					anim.SetBool("atacando", true);
					anim.SetBool("andando", false);
					anim.SetBool("parado", false);
					podeDarDano = true;
					dandoDano();
			}
		}
		else{
			podeDarDano = false;
			anim.SetBool("parado",true);
			anim.SetBool("andando",false);
			anim.SetBool("atacando",false);
			correndo=false;
		}
        
    	}
	else{
		somMonmstro.Stop();
		navComponent.SetDestination(monstro.position);
	}
    }
    void Tocar(){
	somMonmstro.Play();
    }
    void Rein(){
	Application.LoadLevel(cena.name);
    }
	
	public void morte()
	{
		morreu.enabled = true;
		cameraJogador.SetActive(false);
		cameraDaMorte.SetActive(true);
		monstroCenaMorte.SetActive(true);
		municao.enabled = false;
		vida.enabled = false;
		Invoke("Rein", 3);
	}
	void dandoDano()
	{
		if (podeDarDano)
		{
			vidaScript.PerdePonto(dano);
		}

	}
}
