using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class funcionalidadesArma : MonoBehaviour
{
	public float espalharBalas = 0.06f;
	public Text textoMunicao;
	public Image crosshair1;
	public Image crosshair2;
	public Image crosshair3;
	public Image crosshair4;
	private bool podeAtirar = true;
	private Animator anim;
	public int PenteCapacidade = 30;
	public int PenteResto;
	public int TodoResto = 90;
	public float FireRate = 0.1f;
	public float range = 100.0f;
	public Transform pontoDePartida;
	private AudioSource audios;
	public AudioClip somSemMunicao;
	public AudioClip tiro;
	public AudioClip reload;
	public ParticleSystem muzzleflash;
	public GameObject hitParticles;
	public GameObject sangue;
	public GameObject bulletImpact;
	float fireTimer;
	morteMonstro scriptMorteMonstro;
	public enum modoDeTiroEnum { Auto, Semi }
	public modoDeTiroEnum modoDeTiro;
	private bool saidaDoTiro;
	public float dano = 15.0f;
	private Vector3 posicaoOriginal;
	public Vector3 posicaoMira;
	public float velocidadeMira = 8f;

	void OnEnable()
	{
		UpdateAmmoText();
	}
	void Start()
	{
		UpdateAmmoText();
		posicaoOriginal = transform.localPosition;
		PenteResto = PenteCapacidade;
		anim = GetComponent<Animator>();
		anim.SetBool("tiro", false);
		audios = GetComponent<AudioSource>();

	}


	void Update()
	{
		switch (modoDeTiro)
		{
			case modoDeTiroEnum.Auto:
				saidaDoTiro = Input.GetButton("Fire1");
				break;
			case modoDeTiroEnum.Semi:
				saidaDoTiro = Input.GetButtonDown("Fire1");
				break;
		}
		if (saidaDoTiro)
		{
			if (Input.GetButton("Fire1") && podeAtirar == true)
			{
				Fire();
			}
		}
		if (Input.GetButtonDown("Fire1") && podeAtirar == false)
		{

			audios.clip = somSemMunicao;
			audios.Play();

		}
		if (Input.GetButtonUp("Fire1"))
		{
			anim.SetBool("tiro", false);
		}
		if (fireTimer < FireRate)
		{
			fireTimer += Time.deltaTime;
		}
		if (Input.GetButtonDown("Reload") && TodoResto > 1 && PenteResto < PenteCapacidade)
		{
			DoReload();
			audios.clip = reload;
			audios.Play();
			Invoke("Reloade", 2);
			if (PenteResto < PenteCapacidade)
			{

				podeAtirar = false;
			}
			else
			{

				podeAtirar = true;
			}
		}
		if (Input.GetButton("Fire2"))
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, posicaoMira, Time.deltaTime * velocidadeMira);
			crosshair1.enabled = false;
			crosshair2.enabled = false;
			crosshair3.enabled = false;
			crosshair4.enabled = false;
		}
		else
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, posicaoOriginal, Time.deltaTime * velocidadeMira);
			crosshair1.enabled = true;
			crosshair2.enabled = true;
			crosshair3.enabled = true;
			crosshair4.enabled = true;
		}



	}
	void Fire()
	{
		if (fireTimer < FireRate) return;
		RaycastHit hit;
		Vector3 shootDirection = pontoDePartida.transform.forward;
		shootDirection.x += Random.Range(-espalharBalas, espalharBalas);
		shootDirection.y += Random.Range(-espalharBalas, espalharBalas);
		if (Physics.Raycast(pontoDePartida.position, shootDirection, out hit, range))
		{

	
		 if (scriptMorteMonstro = hit.transform.GetComponent<morteMonstro>())
			{
				GameObject hitParticleEffect = Instantiate(sangue, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

				Destroy(hitParticleEffect, 1.0f);
				if (scriptMorteMonstro != null)
				{
					scriptMorteMonstro.Takedamage(dano);
				}

			}
			else
			{
				GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

				Destroy(hitParticleEffect, 1.0f);
				GameObject bulletImpactEffect = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
				Destroy(bulletImpactEffect, 10.0f);
			}

		}
		anim.SetBool("tiro", true);
		muzzleflash.Play();
		PenteResto--;
		audios.clip = tiro;
		audios.Play();
		fireTimer = 0.0f;
		if (PenteResto == 0)
		{
			podeAtirar = false;
		}
		UpdateAmmoText();
	}
	public void Reloade()
	{

		if (PenteResto + TodoResto >= 30)
		{

			TodoResto = TodoResto - (PenteCapacidade - PenteResto);
			PenteResto = PenteCapacidade;
			podeAtirar = true;
			UpdateAmmoText();

		}
		else
		{

			PenteResto = PenteResto + TodoResto;
			TodoResto = 0;
			podeAtirar = true;
			UpdateAmmoText();
		}

	}

	void DoReload()
	{
		anim.CrossFadeInFixedTime("Reload", 0.01f);
	}
	private void UpdateAmmoText()
	{
		textoMunicao.text = PenteResto + "/" + TodoResto;
	}


}
