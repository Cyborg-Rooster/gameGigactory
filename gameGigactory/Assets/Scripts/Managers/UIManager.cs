using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class UIManager
{
    public static void SetButtonAction(GameObject button, GameController instance, ShedController controller)
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { instance.BuyBelt(controller); });
    }
}
