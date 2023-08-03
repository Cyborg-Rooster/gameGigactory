using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class UIManager
{
    public static void SetBeltButtonAction(GameObject button, GameController instance, ShedController controller)
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { instance.BuyBelt(controller); });
    }

    public static void SetWorkbenchButtonAction(GameObject button, GameController instance, BeltController controller)
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { instance.BuyWorkbench(controller); });
    }
}
