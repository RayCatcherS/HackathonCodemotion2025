using UnityEngine;

public class TerminalHub : ActivatableItem
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
                foreach (var item in itemToactivate)
                {
                    item.EnableItem(true);
                }
            }
        }
        else
        {
            currentCount--;
            feedBackMeshRenderer.material = disabledMaterial;
            foreach (var item in itemToactivate)
            {
                item.EnableItem(false);
            }
        }

    }
}
