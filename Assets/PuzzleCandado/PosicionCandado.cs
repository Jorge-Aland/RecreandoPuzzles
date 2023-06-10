using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PosicionCandado : MonoBehaviour
{
    [SerializeField] private Image image; //Para tener acceso a la imagen
    [SerializeField] private List<Sprite> numberImages; //Cuando pulsamos cambia el sprite, por eso tenemos una lista de sprites
    private int numberSelected = 0; //Todos empiezan en la posición 0

    public Action OnNumberChanged; //Evento que se llama cuando se pulsa a un botón, lo hacemos así porque desde el prefab
    // no se puede configurar un Evento, para ello creamos un Action al que luego el Controller se suscribirá
    
    /// <summary>
    /// Método para cuando se pulsa el botón de un número hacia arriba
    /// </summary>
    public void ChangeNumberUp()
    {
        if (numberSelected < numberImages.Count-1) //Si el número seleccionado es menor que el número de imágenes menos 1
        {
            numberSelected++; //Entonces podemos sumar 1
        }
        else //Si no
        {
            numberSelected = 0; //Significa que se han acabado las imágenes, volvemos a 0
        }
        image.sprite = numberImages[numberSelected]; //Cambiamos la imagen
        OnNumberChanged?.Invoke(); //Invokamos el evento
    }    
    /// <summary>
    /// Método para cuando se pulsa el botón de un número para abajo
    /// </summary>
    public void ChangeNumberDown()
    {
        if (numberSelected > 0) //Si el número es mayor que 0
        {
            numberSelected--; //Entonces podemos bajar 1
        }
        else //En caso de que no lo sea, es decir que es 0
        {
            numberSelected = numberImages.Count - 1; //El valor se lo ponemos igual a número de imagenes menos 1, ya que 
            // que hemos hecho es ir del primero al último
        }
        image.sprite = numberImages[numberSelected]; //Cambiamos la imagen
        OnNumberChanged?.Invoke();

    }

    /// <summary>
    /// Método que devuelve el número seleccionado
    /// </summary>
    /// <returns>devuelve el número seleccionado</returns>
    public int GetNumberSelected()
    {
        return numberSelected; 
    }
}
