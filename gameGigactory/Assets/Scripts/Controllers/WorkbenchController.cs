using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class WorkbenchController : MonoBehaviour
{
    //[Header("Sprites")]
    //[SerializeField] Sprite WorkbenchSprite;
    //[SerializeField] Sprite BuyMore;

    SpriteLevelController SpriteLevelController;

    public void ChangeSpriteLevel(int level)
    {
        SpriteLevelController = GetComponent<SpriteLevelController>();
        SpriteLevelController.ChangeSpriteLevel(level);
    }
}
