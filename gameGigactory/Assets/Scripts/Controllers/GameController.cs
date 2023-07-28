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
    [SerializeField] List<ShedController> Sheds = new List<ShedController>();

    [Header("Prefabs")]
    [SerializeField] GameObject Shed;
    private void Start()
    {
        StartCoroutine(EsperarOGalpaoTerminarARotina());
    }

    System.Collections.IEnumerator EsperarOGalpaoTerminarARotina()
    {
        float YPosToSpawn = 0f;
        foreach (var s in GameData.Sheds)
        {
            var controller = Instantiate(Shed, ShedParent).GetComponent<ShedController>();
            Sheds.Add(controller);
            controller.transform.position = new Vector3(controller.transform.position.x, YPosToSpawn, 0);
            controller.InstantiateObjects(s.ID - 1);
            YPosToSpawn += 9.92f;
            yield return new WaitUntil(() => controller.Loaded);
        }
    }

    private void OnApplicationQuit()
    {
        DatabaseManager.SetDatabaseActive(false);
    }
}
