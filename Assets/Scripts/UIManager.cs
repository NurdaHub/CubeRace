using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Spawner spawner;
    
    [SerializeField] private TMP_InputField delayInput;
    [SerializeField] private TMP_InputField speedInput;
    [SerializeField] private TMP_InputField distanceInput;

    public void OnApplyButtonClick()
    {
        float delay = float.Parse(delayInput.text);
        float speed = float.Parse(speedInput.text);
        float distance = float.Parse(distanceInput.text);
        
        spawner.SpawnNewCube(delay, distance, speed);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
