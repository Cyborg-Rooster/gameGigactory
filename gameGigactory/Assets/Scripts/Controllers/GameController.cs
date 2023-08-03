using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

class GameController : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] Transform ShedParent;
    [SerializeField] Transform UI;
    [SerializeField] List<ShedController> Sheds = new List<ShedController>();

    [Header("Prefabs")]
    [SerializeField] GameObject Shed;
    [SerializeField] GameObject BeltCanvas;
    [SerializeField] GameObject WorkbenchCanvas;
    private void Start()
    {
        StartCoroutine(LoadSheds());
    }

    System.Collections.IEnumerator LoadSheds()
    {
        float YPosToSpawn = 0f;
        foreach (var s in GameData.Sheds)
        {
            ShedController controller = Instantiate(Shed, ShedParent).GetComponent<ShedController>();
            controller.transform.position = new Vector3(controller.transform.position.x, YPosToSpawn, 0);
            Sheds.Add(controller);

            Transform shedUITransform = Instantiate(new GameObject(), UI).transform;
            shedUITransform.gameObject.name = $"ShedUI{s.ID}";
            shedUITransform.position = Vector3.zero;

            ButtonsController beltButtonsController = Instantiate(BeltCanvas, shedUITransform).GetComponent<ButtonsController>();
            beltButtonsController.transform.position = new Vector3(controller.transform.position.x, YPosToSpawn, 0);
            beltButtonsController.SetVoid(this, controller);

            controller.InstantiateObjects(s.ID, beltButtonsController, shedUITransform, WorkbenchCanvas);
            YPosToSpawn += 9.92f;
            yield return new WaitUntil(() => controller.Loaded);
        }
    }

    public void BuyBelt(ShedController shedController)
    {
        shedController.Addbelt();
    }

    public void BuyWorkbench(BeltController beltController)
    {
        beltController.AddWorkbench();
    }

    private void OnApplicationQuit()
    {
        DatabaseManager.SetDatabaseActive(false);
    }
}
