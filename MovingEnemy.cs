using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Transform position3, position4;
    public float _speed = 3f;
    private bool _switch = false;

    private void FixedUpdate()
    {
        if (_switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, position3.position, _speed * Time.deltaTime);
        }
        else if (_switch == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, position4.position, _speed * Time.deltaTime);
        }

        if (transform.position == position3.position)
        {
            _switch = true;
        }
        else if (transform.position == position4.position)
        {
            _switch = false;
        }
    }
}
