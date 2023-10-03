using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

class GameController : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] Transform ShedParent;
    [SerializeField] Transform UI;
    [SerializeField] PlayableDirector PlayableDirector;
    [SerializeField] List<ShedController> Sheds = new List<ShedController>();

    [Header("Prefabs")]
    [SerializeField] GameObject Shed;
    [SerializeField] GameObject BeltCanvas;

    [Header("UI")]
    [SerializeField] GameObject Money;

    [Header("UI Timelines")]
    [SerializeField] PlayableAsset BeltUp;
    [SerializeField] PlayableAsset BeltDown;

    private void Start()
    {
        UIManager.SetText(Money, "$" + GameData.Complexes[0].Money);
        StartCoroutine("LoadSheds");
    }

    System.Collections.IEnumerator LoadSheds()
    {
        float YPosToSpawn = 0f;
        foreach (var s in GameData.Sheds.Where(x => x.ComplexID == 1))
        {
            ShedController controller = Instantiate(Shed, ShedParent).GetComponent<ShedController>();
            controller.transform.position = new Vector3(controller.transform.position.x, YPosToSpawn, 0);
            Sheds.Add(controller);

            Transform shedUITransform = Instantiate(new GameObject(), UI).transform;
            shedUITransform.gameObject.name = $"ShedUI{s.ID}";
            shedUITransform.position = Vector3.zero;

            ButtonsController beltButtonsController = Instantiate(BeltCanvas, shedUITransform).GetComponent<ButtonsController>();
            beltButtonsController.transform.position = new Vector3(controller.transform.position.x, YPosToSpawn, 0);
            beltButtonsController.SetVoid(controller);

            controller.InstantiateObjects(s.ID, beltButtonsController, shedUITransform, this);
            YPosToSpawn += 9.92f;
            yield return new WaitUntil(() => controller.Loaded);
        }
    }

    public void IncreaseMoney(int money)
    {
        GameData.Complexes[0].Money += money;
        UIManager.SetText(Money, "$" + GameData.Complexes[0].Money);
    }

    public void DecreaseMoney(int money)
    {
        GameData.Complexes[0].Money -= money;
        UIManager.SetText(Money, "$" + GameData.Complexes[0].Money);
    }

    public void StartBeltDialogBoxAnimation(bool up)
    {
        var playable = up ? BeltUp : BeltDown;
        PlayableDirector.playableAsset = playable;
        PlayableDirector.Play();
        BeltController.BeltIsInteractable = !up;
    }

    private void OnApplicationFocus(bool onFocus)
    {
        if (!onFocus) GameData.UpdateComplex(GameData.Complexes[0]);
        DatabaseManager.SetDatabaseActive(onFocus);
    }
}
