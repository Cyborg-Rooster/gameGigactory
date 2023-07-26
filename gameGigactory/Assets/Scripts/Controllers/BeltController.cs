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
        //List<Workbench> workbenches = GameData.Workbenches.Where(x => GameData.Workbenches.Contains(x.BeltID))
    }
}
