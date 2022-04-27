using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventoAnimacion : MonoBehaviour
{
    public UnityEvent eventos;

    public void InvocarEvento()
    {
        eventos.Invoke();
    }
}
