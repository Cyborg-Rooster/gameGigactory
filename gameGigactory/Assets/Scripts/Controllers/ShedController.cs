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

    public void InstantiateObjects(int index, ButtonsController buttonsController)
    {
        Shed = GameData.Sheds.Where(x => x.ID == index).First();
        var tmp = GameData.Belts.Where(x => x.ShedID == Shed.ID).ToArray();

        Rooms.ChangeSpriteLevel(Shed.RoomsCount);
        Floor.ChangeSpriteLevel(Shed.FloorType);

        PlusButton = buttonsController.BeltButtons;

        var max = Shed.BeltsCount;
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

    public void Addbelt()
    {
        Belt belt = new Belt()
        {
            ID = GameData.Belts.Count() + 1,
            ShedID = Shed.ID,
            Quality = 0,
            WorkbenchCount = 1,
            ProductBoxQuality = 0,
            ResourcesBoxQuality = 0
        };

        BeltControllers[Shed.BeltsCount].gameObject.SetActive(true);
        BeltControllers[Shed.BeltsCount].InstantiateObjects(belt);

        PlusButton[Shed.BeltsCount].SetActive(false);
        if (Shed.BeltsCount < 2) PlusButton[Shed.BeltsCount + 1].SetActive(true);

        Shed.BeltsCount++;

        GameData.SaveBelt(belt);
        GameData.UpdateShed(Shed);

        Shed = GameData.Sheds.Where(x => x.ID == Shed.ID).First();

    }
}
