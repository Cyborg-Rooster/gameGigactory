using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

class BeltController : MonoBehaviour
{
    [SerializeField] List<WorkbenchController> WorkbenchControllers;
    [SerializeField] GameObject WorkbenchButtonsController;

    Belt Belt;
    ButtonsController WorkbenchButtons;

    public void InstantiateObjects(Belt belt, Transform ShedUI)
    {
        var max = belt.WorkbenchCount;
        Belt = belt;

        WorkbenchButtons = Instantiate(WorkbenchButtonsController, ShedUI).GetComponent<ButtonsController>();
        var tmpPos = WorkbenchButtons.transform.position;
        tmpPos.y = transform.position.y;
        WorkbenchButtons.transform.position = tmpPos;
        WorkbenchControllers[0].gameObject.SetActive(true);

        for (int i = 1; i < 4; i++)
        {
            if (max > i) WorkbenchControllers[i].gameObject.SetActive(true);
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
        Debug.Log("Teste");
        Workbench workbench = new Workbench()
        {
            ID = GameData.Workbenches.Count() + 1,
            BeltID = Belt.ID,
            WorkerType = 0
        };

        WorkbenchControllers[Belt.WorkbenchCount].gameObject.SetActive(true);
        //WorkbenchControllers[Belt.WorkbenchCount].gameObject.Se

        WorkbenchButtons.Buttons[Belt.WorkbenchCount - 1].SetActive(false);
        if (Belt.WorkbenchCount < 3) WorkbenchButtons.Buttons[Belt.WorkbenchCount].SetActive(true);

        Belt.WorkbenchCount++;

        GameData.SaveWorkbench(workbench);
        GameData.UpdateBelt(Belt);
    }
}
