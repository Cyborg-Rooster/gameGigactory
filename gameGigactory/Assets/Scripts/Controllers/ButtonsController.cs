using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ButtonsController : MonoBehaviour
{
    public List<GameObject> BeltButtons;
    public List<GameObject> WorbenchButtons;

    public void SetVoid(GameController controller, ShedController shedController)
    {
        foreach (var button in BeltButtons) 
        {
            UIManager.SetButtonAction(button, controller, shedController);
        }
    }

}
