using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MainManager creates a singleton pattern. Ensures that only a single instance of the MainManager can ever exist
public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    // called when the script instance is being loaded
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
