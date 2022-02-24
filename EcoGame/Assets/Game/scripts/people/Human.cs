using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Human : MonoBehaviour
{
    
    private Rigidbody2D _rb;

    private bool _can_drop_trash;
    private bool trash_dropped;
    [SerializeField] private List<Transform> _trash = new List<Transform>();
                     private Vector2 _drop_trash_vector;
    [SerializeField] private float _drop_trash_chance = 0.5f;
    [SerializeField] private float _try_drop_trash_time = 2f;
    [SerializeField] private float _drop_trash_force = 1.2f;
    [HideInInspector]public Transform drop_trash_parent;

    [HideInInspector] public Transform move_target;
    [HideInInspector] public bool freeze_x_pos;

    [SerializeField] private float _min_speed_m_per_sec;
    [SerializeField] private float _max_speed_m_per_sec;
    [SerializeField] private float _speed;

    [SerializeField] private AudioSource _as;
    [SerializeField] private List<AudioClip> _sounds = new List<AudioClip>();
    [SerializeField] private float max_time_befeore_sound = 5;

    [SerializeField] private dialog_cloud _dialog_cloud;
    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();

        _rb.constraints = (freeze_x_pos) ? RigidbodyConstraints2D.FreezePositionX : RigidbodyConstraints2D.FreezePositionY;

        _speed = Random.Range(_min_speed_m_per_sec, _max_speed_m_per_sec);

        transform.localScale = (move_target.position.x - transform.position.x > 0) ? transform.localScale : new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _dialog_cloud.transform.localScale = (transform.localScale.x > 0) ? _dialog_cloud.transform.localScale : new Vector3(-_dialog_cloud.transform.localScale.x, _dialog_cloud.transform.localScale.y, _dialog_cloud.transform.localScale.z);
        StartCoroutine(Try_drop_trash());
        StartCoroutine(PlayRandomSound());
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 _movement_vector = (move_target.position - transform.position).normalized;
        _rb.AddForce(_movement_vector * _speed * _rb.drag);

        float _distance = Vector2.Distance(move_target.position, transform.position);

        if (_distance <= 5)
        {
            Destroy(gameObject);
        }
    }

    private void Drop_trash()
    {
        float _chance = Random.Range(0, 1f);

        if (_chance < _drop_trash_chance)
        {

            Transform choosed_droping_trash = _trash[Random.Range(0, _trash.Count)];
            Transform dropting_trash_go = Instantiate(choosed_droping_trash, drop_trash_parent);
            dropting_trash_go.transform.position = transform.position;

            _drop_trash_vector = new Vector2(Random.Range(0, 1f), Random.Range(0, 1f));
            dropting_trash_go.GetComponent<Rigidbody2D>().AddForce(_drop_trash_vector * _drop_trash_force, ForceMode2D.Impulse);

            trash_dropped = true;

        }
    }

    private IEnumerator Try_drop_trash()
    {
        while (!trash_dropped && _can_drop_trash) {

            yield return new WaitForSeconds(_try_drop_trash_time);
            Drop_trash();
        }
    }

    private IEnumerator PlayRandomSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, max_time_befeore_sound));
            _as.PlayOneShot(_sounds[Random.Range(0, _sounds.Count)]);
            _dialog_cloud.is_show = true;
            _dialog_cloud.tmpro.text = "ΐουθ..  ";

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("game_zone"))
        {
            _can_drop_trash = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("game_zone"))
        {
            _can_drop_trash = false;
        }
    }
}
