using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventoAnimacion : MonoBehaviour
{
    public UnityEvent eventos,muertes,bloqueo,error;

    public void InvocarEvento()
    {
        eventos.Invoke();
    }

    public void InvocarMuerte()
    {
        muertes.Invoke();
    }

    public void InvocarBloqueo()
    {
        bloqueo.Invoke();
    }

    public void InvocarError()
    {
        error.Invoke();
    }
}
