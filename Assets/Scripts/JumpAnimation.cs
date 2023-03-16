using System;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class JumpAnimation : MonoBehaviour
{
    [SerializeField] private float _cycleLength = 2;
    private Animator _animator;
    private Rigidbody rb;
    

   private int clickCount;

   public float maxTime = 3f; // maksimum süre
   public int clicksNeeded = 5; // tıklama sayısı
   public float gravityForce = 10f; 

   float timer = 0f; // sayaç

   private bool _canClick = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {    {
             rb.AddForce(-Vector3.up * gravityForce, ForceMode.Impulse); 
     
             if (Input.GetKey(KeyCode.A))
             {
                 Debug.Log("a");
                 _animator.SetBool("Run", true);
                 _animator.SetBool("Fly", false); 
             }
             if (Input.GetKey(KeyCode.Space))
             {
                 Debug.Log("space");
                 _animator.SetBool("Fly", true);
                 _animator.SetBool("Run", false); 
             }
     
             if ( _canClick &&Input.GetKeyDown(KeyCode.X))
             {
                 clickCount++;
                 Debug.Log("clickount :" + clickCount);
                 Debug.Log("X");
                 Flap();
             }
             
             if (clickCount >= clicksNeeded) 
             {
                 timer += Time.deltaTime; 
                 Debug.Log("timer " + timer);
                 if (timer <= maxTime) 
                 {
                     _canClick = false;
                     _animator.SetBool("Fly", false);
                     _animator.SetBool("Run", false); 
                     _animator.SetBool("Fall",true);
                 }
                 else
                 {
                     timer = 0f;  
                 }
             }
         }

        rb.AddForce(-Vector3.up * gravityForce, ForceMode.Impulse); 

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("a");
            _animator.SetBool("Run", true);
            _animator.SetBool("Fly", false); 
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space");
            _animator.SetBool("Fly", true);
            _animator.SetBool("Run", false); 
        }

        if ( _canClick &&Input.GetKeyDown(KeyCode.X))
        {
            clickCount++;
            Debug.Log("clickount :" + clickCount);
            Debug.Log("X");
            Flap();
        }
        
        if (clickCount >= clicksNeeded) 
        {
            timer += Time.deltaTime; 
            Debug.Log("timer " + timer);
            if (timer <= maxTime) 
            {
                _canClick = false;
                _animator.SetBool("Fly", false);
                _animator.SetBool("Run", false); 
                _animator.SetBool("Fall",true);
            }
            else
            {
                timer = 0f; 
                clickCount = 0; // 
            }
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
