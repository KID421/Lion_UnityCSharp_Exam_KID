using UnityEngine;

public class Runner : MonoBehaviour
{
    [Header("終點")]
    public Transform end;
    [Header("速度"), Range(0, 50)]
    public float speed = 5;

    public delegate void delegateEvent();       // 委派
    public delegateEvent onEnd;                 // 事件

    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
    }

    /// <summary>
    /// 跑步
    /// </summary>
    private void Run()
    {
        if (Vector3.Distance(transform.position, end.position) > 0.1f) transform.Translate(transform.forward * Time.deltaTime * speed);
    }

    /// <summary>
    /// 觸發終點與執行事件
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "終點")
        {
            ani.SetTrigger("揮手");
            onEnd();
        }
    }
}
