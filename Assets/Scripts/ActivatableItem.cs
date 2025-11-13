using UnityEngine;

public abstract class ActivatableItem : MonoBehaviour
{
    [Header("Material References")]
    [SerializeField] protected MeshRenderer feedBackMeshRenderer;
    [SerializeField] protected Material enabledMaterial;
    [SerializeField] protected Material disabledMaterial;
    [Header("Light References")]
    [SerializeField] protected Light pointLight;
    [SerializeField] protected Color enabledLight;
    [SerializeField] protected Color disabledLight;

    public abstract void EnableItem(bool enabled);

}
