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
    [SerializeField] GameObject WorkbenchSliderController;

    Belt Belt;
    ButtonsController WorkbenchSlider;
    GameController GameController;

    public void InstantiateObjects(Belt belt, Transform ShedUI, GameController gameController)
    {
        GameController = gameController;

        var max = belt.WorkbenchCount;
        Belt = belt;

        WorkbenchSlider = Instantiate(WorkbenchSliderController, ShedUI).GetComponent<ButtonsController>();
        var tmpPos = WorkbenchSlider.transform.position;
        tmpPos.y = transform.position.y;
        WorkbenchSlider.transform.position = tmpPos;

        WorkbenchControllers[0].gameObject.SetActive(true);
        WorkbenchControllers[0].StartComponent(GameController, WorkbenchSlider.Buttons[0]);

        for (int i = 1; i < 4; i++)
        {
            if (max > i) 
            { 
                WorkbenchControllers[i].gameObject.SetActive(true);
                WorkbenchControllers[i].StartComponent(GameController, WorkbenchSlider.Buttons[i]);
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
            WorkbenchControllers[Belt.WorkbenchCount].StartComponent(GameController, WorkbenchSlider.Buttons[Belt.WorkbenchCount]);

            Belt.WorkbenchCount++;

            GameController.DecreaseMoney(500);

            GameData.SaveWorkbench(workbench);
            GameData.UpdateBelt(Belt);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) GameController.StartBeltDialogBoxAnimation(true).Start();
    }
}

