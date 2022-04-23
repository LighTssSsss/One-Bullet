using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public bool player1;
    public KeyCode boton;
    private void Update()
    {
        if (Input.GetKeyDown(boton))
        {
            ReproducirAnimacion("Disparo");
           
            if (player1 == true)
            {
                gameManager.p1Disparo = true;
                gameManager.tiempoP1 = Time.time;        
            }
            else
            {
                gameManager.p2Disparo = true;
                gameManager.tiempoP2 = Time.time;
            }
            gameManager.Comparar();
        }
    }

    public void ReproducirAnimacion(string nombreAnimacion)
    {
        animator.Play(nombreAnimacion);
    }
}
