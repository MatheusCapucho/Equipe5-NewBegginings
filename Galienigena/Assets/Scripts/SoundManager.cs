using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource tema;
    public AudioSource morte;
    public AudioSource planar;
    public AudioSource piar;
    public AudioSource pulo;
    public AudioSource queimar;

    public void Playtema()
    {
        tema.Play();
    }
    public void Playmorte()
    {
        morte.Play();
    }
    public void Playplanar()
    {
        planar.Play();
    }
    public void Playpiar()
    {
        piar.Play();
    }
    public void Playpulo()
    {
        pulo.Play();
    }
    public void Playqueimar()
    {
        queimar.Play();
    }


}
