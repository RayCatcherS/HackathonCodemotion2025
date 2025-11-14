using UnityEngine;

public class Terminal : ActivatableItem
{
    [SerializeField] private ActivatableItem[] itemToactivate;
    [SerializeField] private int countToReachToActivate;
    [SerializeField] private int currentCount;
    [SerializeField] private Animation tActivated;
    private bool isActivated = false;
    override public void EnableItem(bool enabled)
    {
        if (enabled)
        {
            currentCount++;

            if (currentCount == countToReachToActivate)
            {
                feedBackMeshRenderer.material = enabledMaterial;
                pointLight.color = enabledLight;
            }
        }
        else
        {

            
            currentCount --;
            feedBackMeshRenderer.material = disabledMaterial;
            pointLight.color = disabledLight;

            if(isActivated)
            {
                tActivated.Play("terminalDisactivated");
                isActivated = false;
                foreach (var item in itemToactivate)
                {
                    item.EnableItem(false);
                }
            }
            
        }

    }

    public bool IsReadyToInteract()
    {
        bool returnValue = false;
        if (!isActivated)
        {
            if (currentCount == countToReachToActivate)
            {
                returnValue = true;
            }
            else
            {
                returnValue = false;
            }
        }
        return returnValue;
    }

    public void StartInteraction()
    {
        Debug.Log("Terminal Activated");
        tActivated.Play("terminalActivated");
        foreach (var item in itemToactivate)
        {
            item.EnableItem(true);
        }
        isActivated = true;
    }
}
