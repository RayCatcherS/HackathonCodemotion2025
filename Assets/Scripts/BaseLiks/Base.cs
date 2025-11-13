using UnityEngine;

public class Base : ActivatableItem
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
            pointLight.color = enabledLight;

        }
        else
        {
            feedBackMeshRenderer.material = disabledMaterial;
            pointLight.color = disabledLight;

        }
    }
}
