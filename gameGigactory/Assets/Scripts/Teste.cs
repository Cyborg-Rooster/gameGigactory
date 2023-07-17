using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Teste : MonoBehaviour
{
    [SerializeField] GameObject Resource;
    [SerializeField] Transform ResourcesBox;
    [SerializeField] Transform ProductBox;
    [SerializeField] List<Transform> WorkbenchPlaces;

    bool canSpawn = true;
    int i = 0;
    private void Update()
    {
        if (canSpawn) StartCoroutine(WaitProductResource());
    }

    IEnumerator WaitProductResource()
    {
        canSpawn = false;
        GameObject obj = Instantiate(Resource, ResourcesBox);
        obj.transform.SetParent(ResourcesBox.parent);
        ProductResourceController productResourceController = obj.GetComponent<ProductResourceController>();

        yield return productResourceController.WaitForComeToWorkbench(WorkbenchPlaces[i].localPosition);

        canSpawn = true;
        i++;
        if(i > 3) i = 0;

        yield return productResourceController.WaitForComeToProductBox(ProductBox.localPosition);
    }
}
