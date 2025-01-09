using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool isGameFrozen = false;

    private void Awake()
    {
        // Ensure a single instance of GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerTimeFreeze(float duration)
    {
        if (!isGameFrozen)
        {
            StartCoroutine(TimeFreezeRoutine(duration));
        }
    }

    private IEnumerator TimeFreezeRoutine(float duration)
    {
        isGameFrozen = true;
        Time.timeScale = 0; // Freeze time
        Debug.Log("Game frozen!");

        yield return new WaitForSecondsRealtime(duration); // Wait in real-time

        Time.timeScale = 1; // Unfreeze time
        Debug.Log("Game unfrozen!");
        isGameFrozen = false;
    }
}
