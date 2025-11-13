using UnityEngine;

public class Link : ActivatableItem
{
    [SerializeField] ActivatableItem[] itemToactivate;


    [Header("Material References")]
    [SerializeField] MeshRenderer feedBackMeshRenderer;
    [SerializeField] private Material enabledMaterial;
    [SerializeField] private Material disabledMaterial;

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
