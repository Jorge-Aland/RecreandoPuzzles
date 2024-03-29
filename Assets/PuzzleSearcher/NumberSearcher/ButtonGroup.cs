using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum OperationType //enumerado para el tipo de operación
{
    sum,
    rest,
    multiply,
    divide
}

public struct NumberAndOperation //Necesitamos pasar un struct ya que tiene que recibir el número que está usando y el tipo de operación
{
    public int numberToReturn;
    public OperationType operationPast;
}

public class ButtonGroup : MonoBehaviour
{

    private NumberAndOperation numberAndOperation = new NumberAndOperation(); //instanciamos el struct para número y operación
    
    [SerializeField] private OperationType operationType; //Para almacenar el tipo de operación que va a tener esa grupo de botones
    
    //Creamos una lista para almacenar los botones
    [SerializeField] private List<Button> buttons;

    //Para guardar el número seleccionado
    private int numberSelected;
    
    //Para indicar si el botón se ha activado
    private bool isActivated = false;

    /// <summary>
    /// Método que recibe un botón y realiza la lógica de seleccionarlo
    /// </summary>
    /// <param name="selectedButton"></param>
    public void SelectButton(Button selectedButton)
    {
        foreach (var button in buttons) //Por cada botón en la lista
        {
            button.image.color = Color.white; //Los ponemos en blanco
        }

        isActivated = true; //Se ha activado por tanto ponemos isActivated en true
        
        selectedButton.image.color = Color.red; //El seleccionado lo ponemos en rojo

        numberSelected = Int32.Parse(selectedButton.GetComponentInChildren<TextMeshProUGUI>().text);
        //Accedemos a el componente de TextMeshPro del hijo del botón y recogemos su texto, este lo pasamos a entero
        // para que esto funcione el texto de los botones SOLO puede ser un número
        
        Debug.Log(numberSelected);
    }

    /// <summary>
    /// Método para devolver el número seleccionado, se llamara mediante evento para ver si se ha resuelto el puzzle
    /// </summary>
    /// <returns></returns>
    public NumberAndOperation GetNumber()
    {
        if (operationType == OperationType.sum) //Si es suma
        {
            numberAndOperation.numberToReturn = numberSelected;
            numberAndOperation.operationPast = OperationType.sum;
        }
        else if (operationType == OperationType.rest) //Si es suma
        {
            numberAndOperation.numberToReturn = numberSelected;
            numberAndOperation.operationPast = OperationType.rest;
        }
        else if (operationType == OperationType.multiply) //Si es suma
        {
            numberAndOperation.numberToReturn = numberSelected;
            numberAndOperation.operationPast = OperationType.multiply;
        }
        else if (operationType == OperationType.divide) //Si es suma
        {
            numberAndOperation.numberToReturn = numberSelected;
            numberAndOperation.operationPast = OperationType.divide;
        }

        return numberAndOperation;
    }

    /// <summary>
    /// Método para indicar si en esta lista se ha activado un botón
    /// </summary>
    /// <returns>variable booleana que lo indica</returns>
    public bool GetIsActivated()
    {
        return isActivated;
    }
}
