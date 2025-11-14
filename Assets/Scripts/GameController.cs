using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Animation skyAnimationIsland;
    [SerializeField] private GameObject startPoint;

    [SerializeField] private GameObject playerScene1;
    [SerializeField] private GameObject playerScene2;
    [SerializeField] private GameObject cameraSequence1;
    [SerializeField] private GameObject cameraSequence2;

    public void PlaySkyAnimation()
    {
        _ = PlaySkyAnimationAsync();
    }

    public async Task PlaySkyAnimationAsync()
    {
        Rigidbody[] rigidbodies = startPoint.GetComponentsInChildren<Rigidbody>();


        playerScene1.SetActive(false);
        cameraSequence1.SetActive(true);
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb.isKinematic == false)
            {
                Destroy(rb);
            }

        }
        await AnimationWaiter.PlayAndWaitAsync(skyAnimationIsland.gameObject, "islandUp");
        cameraSequence1.SetActive(false);
        playerScene2.SetActive(true);

    }

    [ContextMenu("end game")]
    public async Task EndGameAnimation()
    {
               _ = EndGameAnimationAsync();
    }
    public async Task EndGameAnimationAsync()
    {
        playerScene1.SetActive(false);
        playerScene2.SetActive(false);
        cameraSequence2.SetActive(true);
        cameraSequence2.GetComponent<Animation>().Play("EndGameAnimation");
    }
}
