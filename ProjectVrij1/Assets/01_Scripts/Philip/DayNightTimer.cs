using UnityEngine;

public class DayNightTimer : MonoBehaviour
{
    [SerializeField] private float dayDuration = 10f;
    [SerializeField] private float nightDuration = 5f;
    [SerializeField] private DayNightCycle dayNightCycle;
    [SerializeField] private AudioManager audioManager;

    private bool isDay = true;
    private float timer = 0f;

    private void Awake()
    {
        dayNightCycle.SetDayOrNight(isDay);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isDay && timer >= dayDuration)
        {
            isDay = false;
            timer = 0f;
            dayNightCycle.SetDayOrNight(isDay);
            audioManager.PlayAudio(2);
        }
        else if (!isDay && timer >= nightDuration)
        {
            isDay = true;
            timer = 0f;
            dayNightCycle.SetDayOrNight(isDay);
            audioManager.PlayAudio(Random.Range(0, 2));
        }
    }
}
