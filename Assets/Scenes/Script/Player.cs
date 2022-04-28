using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public bool player1;
    public bool enTiempo;
    public KeyCode boton,flechaUp,flechaD,flechaAb,flechaIz;
    public SpriteRenderer [] flechas;

    public int numeroFlecha;
    public int numeroApretado;

    private void Update()
    {
        /*if (Input.GetKeyDown(boton))
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
       }*/
        DispararFueraDeTiempo();
        DetectarBoton();

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
        if (!enTiempo)
        {
            return;
        }

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

    public void DispararFueraDeTiempo()
    {
        if (!enTiempo)
        {
            if (Input.GetKeyDown(flechaUp))
            {
                SeEquivoco();
            }

            if (Input.GetKeyDown(flechaD))
            {
                SeEquivoco();
            }

            if (Input.GetKeyDown(flechaAb))
            {
                SeEquivoco();
            }

            if (Input.GetKeyDown(flechaIz))
            {
                SeEquivoco();
            }
        }
    }

    void SeEquivoco()
    {
        print("Error");
    }

    void CompararNumero()
    {
        if (numeroApretado == numeroFlecha)
        {
            print("Correcto");
                ReproducirAnimacion("Disparo");
                CambiarColor("green");
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
        else
        {
            SeEquivoco();
        }
    }

    public void MostrarFlecha()
    {
        GenerarNumero();

        for(int i = 0; i < flechas.Length; i++)
        {
            flechas[i].enabled = numeroFlecha == i? true : false;
        }

        enTiempo = true;
    }

    void CambiarColor(string color)
    {
        for (int i = 0; i < flechas.Length; i++)
        {
            flechas[i].color = color == "green" ? Color.green : Color.white;
        }
    }

}
