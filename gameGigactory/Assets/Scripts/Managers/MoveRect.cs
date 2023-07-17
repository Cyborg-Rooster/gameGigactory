using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class MoveRect : MoveObject
{
    public RectTransform Rect;

    public void MoveObj()
    {
        KeepCoordinade();
        Move(Rect);

        if(ValidatePosition(Rect.localPosition) && IsParallax)
        {
            Rect.localPosition = InitialPos;
            Move(Rect);
        }
    }


}
