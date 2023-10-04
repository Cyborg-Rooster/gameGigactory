using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    class WorkbenchButtonController : MonoBehaviour
    {
        [SerializeField] SpriteLevelController ImageButton;

        public void ChangeButtonImage(int level)
        {
            ImageButton.ChangeSpriteLevel(level);
        }
    }
}
