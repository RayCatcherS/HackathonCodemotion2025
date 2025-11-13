using UnityEngine;

public class Terminal : ActivatableItem
{
    [SerializeField] private ActivatableItem[] itemToactivate;
    [SerializeField] private int countToReachToActivate;
    [SerializeField] private int currentCount;
    override public void EnableItem(bool enabled)
    {
        if (enabled)
        {
            currentCount++;

            if (currentCount == countToReachToActivate)
            {
                feedBackMeshRenderer.material = enabledMaterial;
                pointLight.color = enabledLight;

                foreach (var item in itemToactivate)
                {
                    item.EnableItem(true);
                }
            }
        }
        else
        {
            currentCount --;
            feedBackMeshRenderer.material = disabledMaterial;
            pointLight.color = disabledLight;

            foreach (var item in itemToactivate)
            {
                item.EnableItem(false);
            }
        }

    }

    public bool IsReadyToInteract()
    {
        if (currentCount == countToReachToActivate)
        {
            return true;
        }
        else { 
            return false;
        }
    }

    public void StartInteraction()
    {

    }
}
