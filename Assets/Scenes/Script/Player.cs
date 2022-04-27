using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public bool player1;
    public KeyCode boton,flechaUp,flechaD,flechaAb,flechaIz;
    public SpriteRenderer [] flechas;

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
        numeroFlecha = Random.Range(0, 4);
    }

    public void DetectarBoton()
    {
        if (Input.GetKeyDown(flechaUp))
        {
            numeroApretado = 0;
            CompararNumero();
        }

        if (Input.GetKeyDown(flechaD))
        {
            numeroApretado = 1;
            CompararNumero();
        }

        if (Input.GetKeyDown(flechaAb))
        {
            numeroApretado = 2;
            CompararNumero();
        }

        if (Input.GetKeyDown(flechaIz))
        {
            numeroApretado = 3;
            CompararNumero();
        }

    }

    void CompararNumero()
    {
        if(numeroApretado == numeroFlecha)
        {
            print("Correcto");
        }
        else
        {
            print("Malo");
        }
    }

    public void MostrarFlecha()
    {
        GenerarNumero();

        for(int i = 0; i < flechas.Length; i++)
        {
            flechas[i].enabled = numeroFlecha == i? true : false;
        }
    }
}
