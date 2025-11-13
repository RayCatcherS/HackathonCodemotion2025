using UnityEngine;

public class EnergyCube : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();
        Base baseItem = other.gameObject.GetComponent<Base>();


        if (windCube != null )
        {

            windCube.EnableWind(true);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(true);
        }
        if (baseItem != null)
        {
            baseItem.EnableItem(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger) return;

        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();
        Base baseItem = other.gameObject.GetComponent<Base>();

        if (windCube != null)
        {
            windCube.EnableWind(false);
        }
        if (energyField != null) { 
            energyField.EnableForceField(false);
        }
        if(baseItem != null)
        {
            baseItem.EnableItem(false);
        }
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger) return;

        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();
        Base baseItem = other.gameObject.GetComponent<Base>();


        if (windCube != null)
        {
            windCube.EnableWind(true);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(true);
        }
        if (baseItem != null)
        {
            baseItem.EnableItem(true);
        }
    }*/
}
