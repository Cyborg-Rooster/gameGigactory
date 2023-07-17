using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class MoveObject
{
    public Vector3 InitialPos, FinalPos;
    public float Speed;
    public bool IsParallax, KeepX, KeepY, KeepZ;

    protected void KeepCoordinade()
    {
        if (KeepX)
        {
            FinalPos.x = InitialPos.x;
        }
        if (KeepY)
        {
            FinalPos.y = InitialPos.y;
        }
        if (KeepZ)
        {
            FinalPos.z = InitialPos.z;
        }
    }

    protected void Move(RectTransform rect)
    {
        rect.localPosition = Vector3.MoveTowards(rect.localPosition, FinalPos, Speed * Time.deltaTime);
    }

    protected void Move(Transform transform)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, FinalPos, Speed * Time.deltaTime);
    }

    public bool ValidatePosition(Vector3 RefPos)
    {
        return RefPos == FinalPos;
    }
}
