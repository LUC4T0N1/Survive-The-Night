using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
public class inteligenciaMonstro2Fase1 : MonoBehaviour
{
	public bool jogadorEscondido;
	private Scene cena;
	private NavMeshAgent navComponent;
	public int distanciaAtrairMonstro;
	public bool vivo = true;
	public Transform jogador;
	public Transform localDeVolta;
	public Transform localDeVolta2;
    public Transform monstro;
	private Animator anim;
	public float distanciaParaAtacar = 0.2f;
	public AudioSource somMonmstro;
	public bool correndo;
	public Text morreu;
	public int aleatorio;
	public GameObject monstroCenaMorte;
	public GameObject cameraJogador;
	public GameObject cameraDaMorte;
	
    void Start()
    {
        morreu.enabled=false;
	cena=SceneManager.GetActiveScene();
	Tocar();
	anim = GetComponent<Animator>();
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update(){
	if(vivo==true){

            if (Vector3.Distance(jogador.position, this.transform.position) < distanciaAtrairMonstro && !jogadorEscondido)
            {
                
                Vector3 direction = jogador.position - this.transform.position;
                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 5.0f * Time.deltaTime);

                anim.SetBool("parado", false);
                if (direction.magnitude > distanciaParaAtacar)
                {
                    navComponent.SetDestination(jogador.position);
                    anim.SetBool("andando", true);
                    anim.SetBool("atacando", false);
                    correndo = true;
                }
                else
                {
                    morreu.enabled = true;
                    cameraJogador.SetActive(false);
                    cameraDaMorte.SetActive(true);
                    monstroCenaMorte.SetActive(true);
                    Invoke("Rein", 3);
                }
            }

            else if (jogadorEscondido)
            {
                if (Vector3.Distance(jogador.position, this.transform.position) > 9)
                {
                    anim.SetBool("parado", false);
                    anim.SetBool("andando", true);
                    anim.SetBool("atacando", false);

                    if (aleatorio == 1)
                    {
                        navComponent.SetDestination(localDeVolta.position);
                    }
                    else if (aleatorio == 2)
                    {
                        navComponent.SetDestination(localDeVolta2.position);
                    }
                }
                else
                {
                    jogadorEscondido = false;
                }

            }
            else
            {
                somMonmstro.Play();
                navComponent.SetDestination(monstro.position);
                anim.SetBool("parado", true);
                anim.SetBool("andando", false);
                anim.SetBool("atacando", false);
                correndo = false;
            }
        
    	}
    }
    void Tocar(){
	somMonmstro.Play();
    }
    void Rein(){
	SceneManager.LoadScene(cena.name);
    }
	
}
