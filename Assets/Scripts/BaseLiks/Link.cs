using UnityEngine;

public class Link : ActivatableItem
{
    [SerializeField] ActivatableItem[] itemToactivate;



    override public void EnableItem(bool enabled)
    {
        foreach (ActivatableItem item in itemToactivate)
        {
            item.EnableItem(enabled);
        }

        if (enabled)
        {

            feedBackMeshRenderer.material = enabledMaterial;
        }
        else
        {
            feedBackMeshRenderer.material = disabledMaterial;
        }
    }
}
