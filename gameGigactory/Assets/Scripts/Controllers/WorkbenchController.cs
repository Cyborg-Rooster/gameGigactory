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
    GameObject Slider;

    public void StartComponent(GameController gameController, GameObject slider)
    {
        GameController = gameController;
        Slider = slider;
        StartCoroutine(SpawnProduct());
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ProductResourceController != null) 
        { 
            ProductResourceController.DecreaseHP();
            UIManager.SetSliderValue(Slider, ProductResourceController.HP);
        }
    }

    private IEnumerator SpawnProduct()
    {
        var tmp = CreateProduct();

        yield return tmp.WaitForComeToWorkbench(transform.localPosition);
        UIManager.SetSliderValue(Slider, tmp.HP);
        Slider.SetActive(true);

        ProductResourceController = tmp;

        yield return ProductResourceController.WaitForHPEqualsZero();
        Slider.SetActive(false);
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
