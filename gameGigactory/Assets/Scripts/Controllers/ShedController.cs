using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ShedController : MonoBehaviour
{
    //[Header("Assets")]
    //[SerializeField] List<Sprite> FloorTypes = new List<Sprite>();
    //[SerializeField] List<Sprite> RoomsType = new List<Sprite>();

    [Header("Controllers")]
    [SerializeField] SpriteLevelController Rooms;
    [SerializeField] SpriteLevelController Floor;

    [SerializeField] List<BeltController> BeltControllers;
    [SerializeField] List<GameObject> PlusButton;

    public bool Loaded;

    Shed Shed;

    public void InstantiateObjects(int index)
    {
        var tmp = GameData.Belts.Where(x => x.ShedID == Shed.ID).ToArray();

        Rooms.ChangeSpriteLevel(Shed.RoomsCount);
        Floor.ChangeSpriteLevel(Shed.FloorType);

        Debug.Log(Shed.BeltsCounts);

        //for(int i = 0; i < 3; i++)
        //{
        //    if (i <= shed.BeltsCounts)
        //    {
        //        BeltControllers[i].InstantiateObjects(tmp[i]);
        //        if (i + 1 != 3 && i + 2 > shed.BeltsCounts) BeltControllers[i].ChangeSpriteLevel(2);
        //    }
        //    else BeltControllers[i].ChangeSpriteLevel(0);
        //}
        var max = Shed.BeltsCounts - 1;
        for (int i = 0; i < 3; i++)
        {
            if (max > i)
            {
                BeltControllers[i].gameObject.SetActive(true);
                BeltControllers[i].InstantiateObjects(tmp[i]);
            }
            else if (max == i) PlusButton[i].SetActive(true);
        }
        Loaded = true;
    }
}
