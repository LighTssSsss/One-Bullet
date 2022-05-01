using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public bool player1;
    public bool enTiempo;
    public bool puedoPresionarTecla;
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

         puedoPresionarTecla = true;

        if (puedoPresionarTecla == true && Input.GetKeyDown(flechaUp))
        {
            numeroApretado = 0;
            CompararNumero();
        }

        if (puedoPresionarTecla == true && Input.GetKeyDown(flechaD))
        {
            numeroApretado = 1;
            CompararNumero();
        }

        if (puedoPresionarTecla == true && Input.GetKeyDown(flechaAb))
        {
            numeroApretado = 2;
            CompararNumero();
        }

        if (puedoPresionarTecla == true && Input.GetKeyDown(flechaIz))
        {
            numeroApretado = 3;
            CompararNumero();
        }
    }

    public void DispararFueraDeTiempo()
    {
        if (!enTiempo && !puedoPresionarTecla)
        {
            if (Input.GetKeyDown(flechaUp)) //animator.SetTrigger("PresionoAntes"); Agregue en animator los make transition en idle y Presiono antes
                                                                                  //a los 2 player y un trigger llamado PresionoAntes.
            {
                print("Error Presiono antes");
                SeEquivoco();
            }

            if (Input.GetKeyDown(flechaD)) //animator.SetTrigger("PresionoAntes");
            {
                print("Error Presiono antes");
                SeEquivoco();
            }

            if (Input.GetKeyDown(flechaAb)) //animator.SetTrigger("PresionoAntes");
            {
                print("Error Presiono antes");
                SeEquivoco();
            }

            if (Input.GetKeyDown(flechaIz)) //animator.SetTrigger("PresionoAntes");
            {
                print("Error Presiono antes");
                SeEquivoco();
            }
        }

        //SeEquivoco();
    }

    void SeEquivoco()
    {
        //print("Error Presiono antes");
        ReproducirAnimacion("PresionoAntes");
    }

    void FlechaEquivocada()
    {
        print("Flecha Equivocada"); 
        CambiarColor2("red");

    }

    void CompararNumero()
    {
        if (numeroApretado == numeroFlecha)
        {
            print("Correcto"); //Borrar despues
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
            FlechaEquivocada();
            ReproducirAnimacion("TeclaEquivocada");
            if (player1 == true)
            {
                gameManager.p1Disparo = false;
                //gameManager.tiempoP1 = Time.time;
            }
            else
            {
                gameManager.p2Disparo = false;
                //gameManager.tiempoP2 = Time.time;
            }
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

    void CambiarColor2(string color)
    {
        for (int i = 0; i < flechas.Length; i++)
        {
            flechas[i].color = color == "red" ? Color.red : Color.white;
        }
    }

}
