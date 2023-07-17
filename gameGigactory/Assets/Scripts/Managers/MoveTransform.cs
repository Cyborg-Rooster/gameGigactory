using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class MoveTransform : MoveObject
{
    public Transform Transform;

    public void MoveObj()
    {
        KeepCoordinade();
        Move(Transform);

        if (ValidatePosition(Transform.localPosition) && IsParallax)
        {
            Transform.localPosition = InitialPos;
            Move(Transform);
        }
    }
}
