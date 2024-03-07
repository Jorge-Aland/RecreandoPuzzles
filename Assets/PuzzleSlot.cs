using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : Selectable, IClickeable
{   
    [SerializeField] private int searcherValue;
    [SerializeField] private int currentValue = 0;

    public ElementOption asignedElementOption;

    public void AsignValue(int value)
    {
        currentValue = value;
    }


    public void OnClick()
    {
        if (PuzzleHuecosController.sharedInstance.SelectedElementOption != null)
        {
            asignedElementOption = PuzzleHuecosController.sharedInstance.SelectedElementOption;
            currentValue = asignedElementOption.GetValue();
            PuzzleHuecosController.sharedInstance.MoveElementOptionToPosition(this);
        }
    }

    public bool IsTheValueCorrect()
    {
        if (searcherValue == currentValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
