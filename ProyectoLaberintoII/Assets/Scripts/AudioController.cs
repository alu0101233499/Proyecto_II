using UnityEngine;

public class AudioController : MonoBehaviour
{
    public SystemCommands system;
    public PlayerController player;
    private AudioSource source;
    public AudioClip TheLabyrinth;
    public AudioClip Crystal;
    public AudioClip ExitTheLabyrinth;

    private bool TheLabyrinthState,
        CrystalState,
        ExitTheLabyrinthState;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        system.StartSong += StartTheLabyrinth;
        player.MidSong += StartCrystal;
        player.EndSong += StartExitTheLabyrinth;
        TheLabyrinthState = false;
        CrystalState = false;
        ExitTheLabyrinthState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TheLabyrinthState && !source.isPlaying)
        {
            source.clip = TheLabyrinth;
            source.Play();
            source.loop = true;
        }

        if (CrystalState && !source.isPlaying)
        {
            source.clip = Crystal;
            source.Play();
            source.loop = true;
        }

        if (ExitTheLabyrinthState && !source.isPlaying)
        {
            source.clip = ExitTheLabyrinth;
            source.Play();
            source.loop = true;
        }
    }

    void StartTheLabyrinth()
    {
        TheLabyrinthState = true;
    }

    void StartCrystal()
    {
        source.loop = false;
        TheLabyrinthState = false;
        CrystalState = true;
    }

    void StartExitTheLabyrinth()
    {
        source.loop = false;
        CrystalState = false;
        ExitTheLabyrinthState = true;
    }
}
