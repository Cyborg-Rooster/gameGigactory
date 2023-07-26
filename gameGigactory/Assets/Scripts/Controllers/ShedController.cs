using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ShedController : MonoBehaviour
{
    [Header("Assets")]
    [SerializeField] List<Sprite> FloorTypes = new List<Sprite>();
    [SerializeField] List<Sprite> RoomsType = new List<Sprite>();

    [Header("Controllers")]
    [SerializeField] SpriteRenderer Rooms;
    [SerializeField] SpriteRenderer Floor;

    public void InstantiateObjects(int index)
    {
        Shed shed = GameData.Sheds[index];
        if(shed.RoomsCount > 0) Rooms.sprite = RoomsType[shed.RoomsCount];
        Floor.sprite = FloorTypes[shed.FloorType];
    }
}
