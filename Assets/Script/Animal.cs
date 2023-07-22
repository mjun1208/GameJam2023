using UnityEngine;

public class Animal : MonoBehaviour
{
    public int Hp { get; set; }
    public float Speed { get; set; } = 0.5f;
    
    public bool IsDead { get; set; }

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        var dir = Vector3.zero - this.transform.position;
        dir = dir.normalized;

        this.transform.position += dir * Speed * Time.deltaTime; 
    }
}
