﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;

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
    Transform ShedUI;
    GameController GameController;

    public void InstantiateObjects(int index, ButtonsController beltButtonsUIController, Transform shedUI, GameController gameController)
    {
        GameController = gameController;

        Shed = GameData.Sheds.Where(x => x.ID == index).First();
        ShedUI = shedUI;
        var tmp = GameData.Belts.Where(x => x.ShedID == Shed.ID).ToArray();

        Rooms.ChangeSpriteLevel(Shed.RoomsCount);
        Floor.ChangeSpriteLevel(Shed.FloorType);

        PlusButton = beltButtonsUIController.Buttons;

        var max = Shed.BeltsCount;
        for (int i = 0; i < 3; i++)
        {
            if (max > i)
            {
                BeltControllers[i].gameObject.SetActive(true);
                BeltControllers[i].InstantiateObjects(tmp[i], ShedUI, GameController);
            }
            else if (max == i) PlusButton[i].SetActive(true);
        }
        Loaded = true;
    }

    public void Addbelt()
    {
        if (GameData.Complexes[0].Money >= 10000)
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
            BeltControllers[Shed.BeltsCount].InstantiateObjects(belt, ShedUI, GameController);

            PlusButton[Shed.BeltsCount].SetActive(false);
            if (Shed.BeltsCount < 2) PlusButton[Shed.BeltsCount + 1].SetActive(true);

            Shed.BeltsCount++;

            GameController.DecreaseMoney(10000);

            GameData.SaveBelt(belt);
            GameData.UpdateShed(Shed);

            Shed = GameData.Sheds.Where(x => x.ID == Shed.ID).First();
        }
    }
}
