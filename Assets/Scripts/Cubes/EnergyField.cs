using UnityEngine;

public class EnergyField : ActivatableItem
{

    [Header("Energy field settings")]
    [SerializeField] private float energyFieldRadius = 5f;
    [SerializeField] private Transform energyFieldTransform;

    [Header("Material References")]
    [SerializeField] MeshRenderer[] feedBackMeshRenderer;
    [SerializeField] private Material enabledMaterial;
    [SerializeField] private Material disabledMaterial;

    private void Start()
    {
        energyFieldTransform.transform.localScale = new Vector3(energyFieldRadius, energyFieldRadius, energyFieldRadius);

        EnableForceField(false);
    }

    public void SetEnergyFieldRadius(float radius)
    {
        energyFieldRadius = radius;
    }

    public override void EnableItem(bool enabled)
    {
        EnableForceField(enabled);
    }

    public void EnableForceField(bool enabled)
    {   
        if(enabled)
        {
            foreach (MeshRenderer renderer in feedBackMeshRenderer)
            {
                renderer.material = enabledMaterial;
            }
            energyFieldTransform.gameObject.SetActive(true);
        } else
        {
            foreach (MeshRenderer renderer in feedBackMeshRenderer)
            {
                renderer.material = disabledMaterial;
            }
            energyFieldTransform.gameObject.SetActive(false);
        }
        
    }



    private void OnTriggerEnter(Collider other)
    {

        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();


        if (windCube != null)
        {

            windCube.EnableWind(true);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();

        if (windCube != null)
        {
            windCube.EnableWind(false);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();


        if (windCube != null)
        {
            windCube.EnableWind(true);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(true);
        }
    }




    // enable debug by editor
    [ContextMenu("enable field")]
    public void DebugEneableWind() { EnableForceField(true); }
    [ContextMenu("disable field")]
    public void DebugDisableWind() { EnableForceField(false); }
}
