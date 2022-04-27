using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public bool player1;
    public KeyCode boton,flechaUp,flechaD,flechaAb,flechaIz;
    public SpriteRenderer arriba;
    public SpriteRenderer abajo;
    public SpriteRenderer derecha;
    public SpriteRenderer izquierda;

    private int numeroFlecha;
    private int numeroApretado;

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

    public void GenerarNumero()
    {
        numeroFlecha = Random.Range(1, 5);
    }

    public void DetectarBoton()
    {
        if (Input.GetKeyDown(flechaUp))
        {
            numeroApretado = 1;
        }

        if (Input.GetKeyDown(flechaD))
        {
            numeroApretado = 2;
        }

        if (Input.GetKeyDown(flechaAb))
        {
            numeroApretado = 3;
        }

        if (Input.GetKeyDown(flechaIz))
        {
            numeroApretado = 4;
        }
    }
}
