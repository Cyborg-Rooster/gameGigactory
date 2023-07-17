using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class FloorController : MonoBehaviour
{
    public float PercentBonus = 0f; 
    public int Level;

    SpriteLevelController SpriteLevelController;

    public void Initiate(int level)
    {
        Level = level;
        SpriteLevelController = GetComponent<SpriteLevelController>();
        SpriteLevelController.ChangeSpriteLevel(Level);
    }
}
