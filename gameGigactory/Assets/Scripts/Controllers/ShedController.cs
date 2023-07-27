using System;
using System.Collections.Generic;
using System.Linq;
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

    public void InstantiateObjects(int index)
    {
        Shed shed = GameData.Sheds[index];
        var tmp = GameData.Belts.Where(x => x.ShedID == index).ToArray();

        Rooms.ChangeSpriteLevel(shed.RoomsCount);
        Floor.ChangeSpriteLevel(shed.FloorType);

        Debug.Log(shed.BeltsCounts);

        for(int i = 0; i < 3; i++)
        {
            if (i <= shed.BeltsCounts)
            {
                BeltControllers[i].InstantiateObjects(tmp[i]);
                if (i + 1 != 3 && i + 2 > shed.BeltsCounts) BeltControllers[i].ChangeSpriteLevel(2);
            }
            else BeltControllers[i].ChangeSpriteLevel(0);
        }
    }
}
