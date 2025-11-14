using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public static class AnimationWaiter
{
    public static async Task PlayAndWaitAsync(GameObject objectToAnimate, string name)
    {


        Animation anim = objectToAnimate.GetComponent<Animation>();
        anim.Play(name);

        while (anim.isPlaying)
        {
            await Task.Yield(); // Aspetta un frame
        }
    }
}
