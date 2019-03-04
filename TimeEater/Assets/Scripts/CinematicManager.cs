using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CinematicManager : MonoBehaviour
{
    private bool start = true;
    [SerializeField] private PlayableDirector startCinematic;
    [SerializeField] private PlayableDirector doorCinematic;
    [SerializeField] private PlayableDirector bossCinematic;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire") && start)
        {
            startCinematic.Play();
            start = false;
        }

    }

    public void DoorCinematic()
    {
        doorCinematic.Play();
    }

    public void EndCinematic()
    {
        bossCinematic.Play();
    }

    public void End()
    {
        GameManager.Instance.Win();
    }
}
