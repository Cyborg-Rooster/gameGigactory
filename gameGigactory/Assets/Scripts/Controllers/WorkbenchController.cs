using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class WorkbenchController : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] GameObject Resource;

    [Header("Transforms")]
    [SerializeField] Transform ResourcesBox;
    [SerializeField] Transform ProductBox;

    ProductResourceController ProductResourceController;
    GameController GameController;

    public void StartComponent(GameController gameController)
    {
        GameController = gameController;
        StartCoroutine(SpawnProduct());
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && ProductResourceController != null) ProductResourceController.DecreaseHP();
    }

    private IEnumerator SpawnProduct()
    {
        var tmp = CreateProduct();

        yield return tmp.WaitForComeToWorkbench(transform.localPosition);
        ProductResourceController = tmp;

        yield return ProductResourceController.WaitForHPEqualsZero();
        ProductResourceController = null;

        yield return tmp.WaitForComeToProductBox(ProductBox.localPosition);
        GameController.IncreaseMoney(50);

        StartCoroutine(SpawnProduct());
    }

    private ProductResourceController CreateProduct()
    {
        GameObject obj = Instantiate(Resource, ResourcesBox);
        obj.transform.SetParent(ResourcesBox.parent);
        return obj.GetComponent<ProductResourceController>();
    }
}
