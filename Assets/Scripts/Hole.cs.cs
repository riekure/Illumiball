using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    private bool fallIn;

    // どのボールが吸い寄せるかをタグで指定
    public string activeTag;

    // ボールが入っているかを返す
    public bool InFallIn()
    {
        return fallIn;
    }

    // Colliderが他のトリガーイベントに侵入したとき
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == activeTag)
        {
            fallIn = true;
        }
    }

    // Collider が他のトリガーに触れるのをやめたとき
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == activeTag)
        {
            fallIn = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // コライダーに触れているオブジェクトのRigidbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // ボールがどの方向にあるのかを計算
        Vector3 direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();

        // タグに応じてボールに力を加える
        if (other.gameObject.tag == activeTag)
        {
            // 中心地点でボールを止めるため速度を減速させる
            r.velocity *= 0.9f;

            r.AddForce(direction * r.mass * 20.0f);
        } else
        {
            r.AddForce(- direction * r.mass * 80.0f);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
