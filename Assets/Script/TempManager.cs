/*
 * Used for debugging. Like cheat code or reset the level. 
 */


#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.SceneManagement;

public class TempManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

#endif