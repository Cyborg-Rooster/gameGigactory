using Assets.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltDialogBoxController : MonoBehaviour
{
    [Header("Workbench Buttons")]
    [SerializeField] List<WorkbenchButtonController> WorkbenchButtonControllers;

    BeltController BeltController;

    public void Init(BeltController beltController)
    {
        BeltController = beltController;

        WorkbenchButtonControllers[0].gameObject.SetActive(true);
        WorkbenchButtonControllers[0].ChangeButtonImage(0);

        for (int i = 1; i < 4; i++)
        {
            if (BeltController.Belt.WorkbenchCount >= i)
            {
                WorkbenchButtonControllers[i].gameObject.SetActive(true);

                int index = BeltController.Belt.WorkbenchCount == i ? 1 : 0;

                WorkbenchButtonControllers[i].ChangeButtonImage(index);
            }
            else WorkbenchButtonControllers[i].gameObject.SetActive(false);
        }
    }
    
    public void AddWorkbench(int index)
    {
        if(index < BeltController.Belt.WorkbenchCount) 
        {

        }
        else if (GameData.Complexes[0].Money >= 500)
        {
            BeltController.AddWorkbench();

            WorkbenchButtonControllers[index].ChangeButtonImage(0);

            if (index < 3)
            {
                WorkbenchButtonControllers[index + 1].gameObject.SetActive(true);
                WorkbenchButtonControllers[index + 1].ChangeButtonImage(1);
            }
        }
    }
}
