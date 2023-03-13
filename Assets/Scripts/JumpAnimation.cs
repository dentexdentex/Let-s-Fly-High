using System;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class JumpAnimation : MonoBehaviour
{
    [SerializeField] private float _cycleLength = 2;
    private Animator _animator;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("a");
            _animator.SetBool("Run", true);
            _animator.SetBool("Fly", false); // Eğer önceki animasyon "Fly" ise durdurulur
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space");
            _animator.SetBool("Fly", true);
            _animator.SetBool("Run", false); // Eğer önceki animasyon "Run" ise durdurulur
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X");
            Flap();
        }
        
    }
    public float jumpForce = 99999f;
    Vector3 A = new Vector3(0, 0, 0);
    Vector3 B=new Vector3(0, 2, 0);
    private void Flap()
    {
        A += B;
        Debug.Log("Flap");
        transform.DOMove(A, _cycleLength);
        // rb.velocity = Vector2.up * jumpForce*100f;
        //rb.AddForce(transform.up * jumpForce*100F);
    }
}
