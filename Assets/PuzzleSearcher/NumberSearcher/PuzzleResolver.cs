
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleResolver : MonoBehaviour
{

    //Lista de los grupos de botones
    [SerializeField] private List<ButtonGroup> ButtonGroups; 
    //Variable controlar el resultado
    private int assistNumber;
    //Variable para recoger el resultado
    private int result;
    
    //Variable para indicar que número es el que buscamos
    [SerializeField] private int searchNumber;
    //Para acceder a el texto que indica la pregunta
    [SerializeField] private TextMeshProUGUI question;
    //Texto para mostrar el resultado
    [SerializeField] private TextMeshProUGUI showResult;
    //Variable par acontrolar el número de botoenes seleccionados
    int numberOfButtonActivated = 0;
    
    //Para controlar que se haya pulsado todos los botones necesarios para ganar, que son uno por grupo de botones
    private bool everyNeededButtonPresed = false;

    public UnityEvent OnPuzzleResolved;
    
    private void Start()
    {
        question.text = "Encuenta el número:" + searchNumber; 
    }

    /// <summary>
    /// Este método es llamado cada vez que se pulsa un botón y se encarga de controlar si se ha resuelto el puzzle
    /// </summary>
    public void CheckPuzzleResult()
    {
        foreach (var buttonGroup in ButtonGroups) //Por cada grupo de botones en la lista ButtonGroups
        {
            var numberAndOperation = buttonGroup.GetNumber();
            
            if (numberAndOperation.numberToReturn != null) //Si el número devuelto no es nulo
            {

                if (numberAndOperation.operationPast == OperationType.sum)
                {
                    assistNumber += numberAndOperation.numberToReturn; //Guardamos en assisteNumber la suma de los obtenidos en el grupo
                }               
                if (numberAndOperation.operationPast == OperationType.rest)
                {
                    assistNumber -= numberAndOperation.numberToReturn; //Guardamos en assisteNumber la resta de los obtenidos en el grupo
                }               
                if (numberAndOperation.operationPast == OperationType.multiply)
                {
                    assistNumber *= numberAndOperation.numberToReturn; //Guardamos en assisteNumber la multiplicacion de los obtenidos en el grupo
                }               
                if (numberAndOperation.operationPast == OperationType.divide)
                {
                    assistNumber /= numberAndOperation.numberToReturn; //Guardamos en assisteNumber la divison de los obtenidos en el grupo
                }
                
                //Como lo hace con un foreach la operación siempre irá de izquierda a derecha, por ejemplo si tenemos + + * -, hara suma de los 2
                // primeros, el resultado se multiplica por el 3 y el resultado de este se resta el 4
                
               
            }

            result = assistNumber; //Guardamos en resultado el número obtenido antes
            showResult.text = result.ToString(); //Mostramos la suma

            if (buttonGroup.GetIsActivated()) // vemos por cada grupo si está activado almenos un botón
            {
                numberOfButtonActivated++;//para ello tenemos un contador para ver cuantos están activados 
                if (numberOfButtonActivated == ButtonGroups.Count)//si hay tantos activamos como elementos de la lista
                {
                    everyNeededButtonPresed = true; //se puede ganar, se tiene seleccionado al menos un botón en cada lista
                }
            }
            else //en caso contrario
            {
                everyNeededButtonPresed = false; //no se puede ganar
            }
        }

        numberOfButtonActivated = 0; //Reiniciamos el número de botones activo, ya que si no lo hiciesemos cada vez
        // que pulsasemos un botón iría sumando y sumando
        assistNumber = 0; //volvemos a 0 el assistNumber en caso de que tengamos que hacer otro sumatorio

        if (result == searchNumber && everyNeededButtonPresed) //si se tiene el número buscado y se tienen todos los botones pulsados
        {
            OnPuzzleResolved?.Invoke();
        }


    }
}