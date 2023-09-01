using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ButtonsController : MonoBehaviour
{
    public List<GameObject> Buttons;

    public void SetVoid(ShedController shedController)
    {
        foreach (var button in Buttons) 
        {
            UIManager.SetBeltButtonAction(button, shedController);
        }
    }

}
