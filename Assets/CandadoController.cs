using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandadoController : MonoBehaviour
{
    [SerializeField] private PosicionCandado positionPrefab; //Prefab que va instanciar
    [SerializeField] private List<PosicionCandado> positionsAvailable; //Lista para todas las posibles posiciones del pujzzle
    [SerializeField] private int numberOfPositions = 0; //Variable para indicar cuantas posiciones tiene este puzzle y luego instansciarlas
    [SerializeField] private string puzzleAnswer; //Respuesta del puzzle
    private string answerControll; //Un string que va llevando control de la respuesta, es la que se comparará con puzzleAnswer para ver si es correcto

    private void Start()
    {
        for (int i = 0; i < numberOfPositions; i++) //por cada posible posicion
        {
            PosicionCandado posicion = Instantiate(positionPrefab); //Instanciamos el prefab
            posicion.transform.SetParent(this.transform, false); //Lo ponemos como hijo del gameobject que tiene este script
            positionsAvailable.Add(posicion); //Lo añadimos a la lista
            posicion.OnNumberChanged += CheckResult; //suscribimos el método CheckResult al Action de cada uno de los PoisionCandado
        }
    }

    /// <summary>
    /// Método que es llamado por evento cuando se cambia el número
    /// </summary>
    public void CheckResult()
    {
        answerControll = ""; //Reinicimaos el string de controll
        
        foreach (PosicionCandado position in positionsAvailable) //Por cada PosicionCandado en la lista positionsAvailabe
        {
            answerControll += position.GetNumberSelected(); //Añadimos al string el string que devuelve .GetNumberSelected()
        }
        Debug.Log(answerControll); 

        if (answerControll == puzzleAnswer) //Si es la respuesta correcta
        {
            Debug.Log("Has superado el puzzle"); //Hemos superado el puzzle
        }
    }
}
