using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager musicManagerInstance;

    // Runs before start
    void Awake()
    {
        DontDestroyOnLoad(this);

        // Makes sure MusicManager isn't instantiated twice
        // from let's say switching scenes
        if(musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
