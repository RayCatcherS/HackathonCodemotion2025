using UnityEngine;

public class Obelisk : ActivatableItem
{
    override public void EnableItem(bool enabled)
    {

        if (enabled) {
            feedBackMeshRenderer.material = enabledMaterial;
            pointLight.color = enabledLight;

            StartEndGame();
        }
    }

    private void StartEndGame()
    {
        
    }
}
