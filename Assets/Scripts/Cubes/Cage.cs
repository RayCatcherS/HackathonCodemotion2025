using UnityEngine;

public class Cage : ActivatableItem
{
    [SerializeField] private GameObject[] cageShield;
    [SerializeField] private Rigidbody catchedBlock;


    private void Start()
    {
        if (catchedBlock != null)
        {
            catchedBlock.isKinematic = true;
        }
    }
    override public void EnableItem(bool enabled)
    {
        if(enabled)
        {
            feedBackMeshRenderer.material = enabledMaterial;
            if(catchedBlock != null)
            {
                catchedBlock.isKinematic = false;
                catchedBlock = null;
            }
            foreach (GameObject shield in cageShield)
            {
                shield.SetActive(false);
            }
        }
        else
        {
            feedBackMeshRenderer.material = disabledMaterial;
            
        }
    }



}
