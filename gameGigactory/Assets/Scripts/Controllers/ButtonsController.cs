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

    public void SetVoid(GameController controller, ShedController shedController)
    {
        foreach (var button in Buttons) 
        {
            UIManager.SetBeltButtonAction(button, controller, shedController);
        }
    }

    public void SetVoid(GameController controller, BeltController beltController)
    {
        foreach (var button in Buttons)
        {
            UIManager.SetWorkbenchButtonAction(button, controller, beltController);
        }
    }

}
