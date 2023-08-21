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

    ProductResourceController productResourceController;

    private void Start()
    {
        StartCoroutine(SpawnProduct());
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && productResourceController != null) productResourceController.DecreaseHP();
    }

    private IEnumerator SpawnProduct()
    {
        var tmp = CreateProduct();

        yield return tmp.WaitForComeToWorkbench(transform.localPosition);
        productResourceController = tmp;

        yield return productResourceController.WaitForHPEqualsZero();

        yield return productResourceController.WaitForComeToProductBox(ProductBox.localPosition);
        productResourceController = null;

        StartCoroutine(SpawnProduct());
    }

    private ProductResourceController CreateProduct()
    {
        GameObject obj = Instantiate(Resource, ResourcesBox);
        obj.transform.SetParent(ResourcesBox.parent);
        return obj.GetComponent<ProductResourceController>();
    }
}
