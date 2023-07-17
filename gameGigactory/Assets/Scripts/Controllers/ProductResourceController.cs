using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductResourceController : MonoBehaviour
{
    [SerializeField] Sprite ProductSprite;
    [SerializeField] float BeltYPosition;

    SpriteRenderer SpriteRenderer;
    MovementController MovementController;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrepareProduct()
    {
        SpriteRenderer.sprite = ProductSprite;
    }

    public IEnumerator WaitForComeToWorkbench(Vector3 finalPosition) 
    {

        SpriteRenderer = GetComponent<SpriteRenderer>();
        MovementController = GetComponent<MovementController>();
        MovementController.Initialize();
        MovementController.ChangeFinalPositionAndMove(new Vector3(transform.position.x, BeltYPosition, 0));

        yield return MovementController.WaitToComeFinalPosition();

        MovementController.ChangeFinalPositionAndMove(new Vector3(finalPosition.x, transform.position.y, 0));

        yield return MovementController.WaitToComeFinalPosition();

        MovementController.ChangeFinalPositionAndMove(finalPosition);

        yield return MovementController.WaitToComeFinalPosition();

        MovementController.CanMove = false;
    }

    public IEnumerator WaitForComeToProductBox(Vector3 ProductBox)
    {
        MovementController.ChangeFinalPositionAndMove(new Vector3(transform.position.x, BeltYPosition, 0));
        MovementController.CanMove = true;

        yield return MovementController.WaitToComeFinalPosition();

        MovementController.ChangeFinalPositionAndMove(new Vector3(ProductBox.x, transform.position.y, 0));

        yield return MovementController.WaitToComeFinalPosition();

        MovementController.ChangeFinalPositionAndMove(ProductBox);

        yield return MovementController.WaitToComeFinalPosition();

        MovementController.CanMove = false;
    }
}
