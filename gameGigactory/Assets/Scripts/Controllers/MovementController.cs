using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class MovementController : MonoBehaviour
{
    public Vector3 FinalPosition;

    public float MovementSpeed;
    public bool KeepXMovement;
    public bool KeepYMovement;
    public bool KeepZMovement;
    public bool CanMove;

    MoveTransform MoveTransform;
    public void Initialize()
    {
        MoveTransform = new MoveTransform
        {
            InitialPos = transform.localPosition,
            FinalPos = FinalPosition,
            Speed = MovementSpeed,
            KeepX = KeepXMovement,
            KeepY = KeepYMovement,
            KeepZ = KeepZMovement,
            Transform = transform
        };
    }

    private void Update()
    {
        if (CanMove) MoveTransform.MoveObj();
    }

    public void ChangeFinalPositionAndMove(Vector3 position)
    {
        MoveTransform.FinalPos = position;
        CanMove = true;
    }


    public IEnumerator WaitForObjectToStop()
    {
        yield return new WaitUntil(() => MoveTransform.ValidatePosition(transform.localPosition));
    }
}
