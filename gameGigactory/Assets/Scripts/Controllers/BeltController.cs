using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class BeltController : MonoBehaviour
{
    [SerializeField] List<WorkbenchController> WorkbenchControllers;
    [SerializeField] List<GameObject> PlusButton;

    Belt Belt;

    public void InstantiateObjects(Belt belt, ButtonsController buttonsController)
    {
        var max = belt.WorkbenchCount;
        PlusButton = buttonsController.Buttons;

        Belt = belt;

        for (int i = 0; i < 4; i++)
        {
            if (max > i) WorkbenchControllers[i].gameObject.SetActive(true);
            else if (max == i) PlusButton[i].SetActive(true);
        }
        ChangeSpriteLevel(belt.Quality);
    }

    public void ChangeSpriteLevel(int level)
    {
        GetComponent<SpriteLevelController>().ChangeSpriteLevel(level);
    }

    public void AddWorkbench()
    {
        Workbench workbench = new Workbench()
        {
            ID = GameData.Workbenches.Count() + 1,
            BeltID = Belt.ID,
            WorkerType = 0
        };

        WorkbenchControllers[Belt.WorkbenchCount].gameObject.SetActive(true);
        //WorkbenchControllers[Belt.WorkbenchCount].gameObject.Se

        PlusButton[Belt.WorkbenchCount].SetActive(false);
        if (Belt.WorkbenchCount < 2) PlusButton[Belt.WorkbenchCount + 1].SetActive(true);

        Belt.WorkbenchCount++;

        GameData.SaveWorkbench(workbench);
        //GameData.UpdateShed(Shed);

        Belt = GameData.Belts.Where(x => x.ID == Belt.ID).First();
    }
}
