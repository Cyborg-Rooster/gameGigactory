using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductResourceController : MonoBehaviour
{
    [SerializeField] Sprite ProductSprite;
    [SerializeField] float BeltYPosition;

    public int HP;

    SpriteRenderer SpriteRenderer;
    MovementController MovementController;

    public void DecreaseHP()
    {
        HP--;
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

        MovementController.ChangeFinalPositionAndMove(new Vector3(transform.localPosition.x, BeltYPosition, 0));

        yield return MovementController.WaitForObjectToStop();

        MovementController.ChangeFinalPositionAndMove(new Vector3(finalPosition.x, transform.localPosition.y, 0));

        yield return MovementController.WaitForObjectToStop();

        MovementController.ChangeFinalPositionAndMove(finalPosition);

        yield return MovementController.WaitForObjectToStop();

        MovementController.CanMove = false;
    }

    public IEnumerator WaitForComeToProductBox(Vector3 ProductBox)
    {
        PrepareProduct();
        MovementController.ChangeFinalPositionAndMove(new Vector3(transform.localPosition.x, BeltYPosition, 0));
        MovementController.CanMove = true;

        yield return MovementController.WaitForObjectToStop();

        MovementController.ChangeFinalPositionAndMove(new Vector3(ProductBox.x, transform.localPosition.y, 0));

        yield return MovementController.WaitForObjectToStop();

        MovementController.ChangeFinalPositionAndMove(ProductBox);

        yield return MovementController.WaitForObjectToStop();

        MovementController.CanMove = false;
        Destroy(gameObject);
    }

    public IEnumerator WaitForHPEqualsZero()
    {
        yield return new WaitUntil(() => HP == 0);
    }
}
