using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Player must be first object in the parent
public class player_beh : MonoBehaviour
{
    [HideInInspector] public trash_beh _trash_beh;
    [HideInInspector] public money Money;

    [HideInInspector] public SpringJoint2D _SpringJoint2D;

    public AudioSource source;
    public AudioClip[] put_trash_audio;

    [Header("propereties")]
    public float _speed = 5;
    public float _get_trash_distnce = 1.5f;
    public float show_hint_distance = 1.5f;
    public float catched_trash = 0;
    void Start()
    {
        //set scripts
        Money = GetComponent<money>();

        _SpringJoint2D = GetComponent<SpringJoint2D>();
        _SpringJoint2D.enabled = false;

        source = GetComponent<AudioSource>();
    }
}
