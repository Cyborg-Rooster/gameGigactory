using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

class BeltController : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] List<WorkbenchController> WorkbenchControllers;

    [Header("Prefabs")]
    [SerializeField] GameObject WorkbenchButtonsController;

    Belt Belt;
    ButtonsController WorkbenchButtons;
    GameController GameController;

    public void InstantiateObjects(Belt belt, Transform ShedUI, GameController gameController)
    {
        GameController = gameController;

        var max = belt.WorkbenchCount;
        Belt = belt;

        WorkbenchButtons = Instantiate(WorkbenchButtonsController, ShedUI).GetComponent<ButtonsController>();
        var tmpPos = WorkbenchButtons.transform.position;
        tmpPos.y = transform.position.y;
        WorkbenchButtons.transform.position = tmpPos;
        WorkbenchControllers[0].gameObject.SetActive(true);
        WorkbenchControllers[0].StartComponent(GameController);

        for (int i = 1; i < 4; i++)
        {
            if (max > i) 
            { 
                WorkbenchControllers[i].gameObject.SetActive(true);
                WorkbenchControllers[i].StartComponent(GameController);
            }
            else if (max == i)
            {
                WorkbenchButtons.Buttons[i - 1].SetActive(true);
                WorkbenchButtons.SetVoid(this);
            }
        }
        ChangeSpriteLevel(belt.Quality);
    }

    public void ChangeSpriteLevel(int level)
    {
        GetComponent<SpriteLevelController>().ChangeSpriteLevel(level);
    }

    public void AddWorkbench()
    {
        if (GameData.Complexes[0].Money >= 500)
        {
            Workbench workbench = new Workbench()
            {
                ID = GameData.Workbenches.Count() + 1,
                BeltID = Belt.ID,
                WorkerType = 0
            };

            WorkbenchControllers[Belt.WorkbenchCount].gameObject.SetActive(true);
            WorkbenchControllers[Belt.WorkbenchCount].StartComponent(GameController);

            WorkbenchButtons.Buttons[Belt.WorkbenchCount - 1].SetActive(false);
            if (Belt.WorkbenchCount < 3) WorkbenchButtons.Buttons[Belt.WorkbenchCount].SetActive(true);

            Belt.WorkbenchCount++;

            GameController.DecreaseMoney(500);

            GameData.SaveWorkbench(workbench);
            GameData.UpdateBelt(Belt);
        }
    }
}

