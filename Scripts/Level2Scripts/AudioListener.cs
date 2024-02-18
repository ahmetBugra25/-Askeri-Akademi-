using UnityEngine;

public class AudioListenerManager : MonoBehaviour
{
    void Start()
    {
        // Sahneye bir ses dinleyicisi ekleyin
        gameObject.AddComponent<AudioListener>();
    }
}
