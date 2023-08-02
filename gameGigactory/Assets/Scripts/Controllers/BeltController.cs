using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class BeltController : MonoBehaviour
{
    [SerializeField] List<WorkbenchController> WorkbenchControllers;

    public void InstantiateObjects(Belt belt)
    {
        var max = belt.WorkbenchCount;
        //List<Workbench> workbenches = GameData.Workbenches.Where(x => x.BeltID == belt.ID).ToList();
        //for(int i = 1; i < 5; i++)
        //{
        //    if (i <= workbenches.Count) 
        //    { 
        //        WorkbenchControllers[i - 1].ChangeSpriteLevel(1); 
        //        if(i != 4 && i + 1 > workbenches.Count) WorkbenchControllers[i - 1].ChangeSpriteLevel(2);
        //    }
        //    else WorkbenchControllers[i - 1].ChangeSpriteLevel(0);
        //}
        for (int i = 0; i < 4; i++)
        {
            if(max > i) WorkbenchControllers[i].ChangeSpriteLevel(1);
            else if(max == i) WorkbenchControllers[i].ChangeSpriteLevel(2);
            else WorkbenchControllers[i].ChangeSpriteLevel(0);
        }
        ChangeSpriteLevel(belt.Quality);
    }

    public void ChangeSpriteLevel(int level)
    {
        GetComponent<SpriteLevelController>().ChangeSpriteLevel(level);
    }
}
