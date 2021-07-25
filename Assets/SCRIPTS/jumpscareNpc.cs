using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class jumpscareNpc : MonoBehaviour
{
    public Transform destino;
    private NavMeshAgent navComponent;
    public GameObject objetoJumpScare;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();

        anim.SetBool("parado", false);
        anim.SetBool("andando", true);
        navComponent.speed = 15f;

        navComponent.SetDestination(destino.position);
        Invoke("Sumir", 3);
    }
    void Sumir()
    {
        objetoJumpScare.SetActive(false);
    }
}
