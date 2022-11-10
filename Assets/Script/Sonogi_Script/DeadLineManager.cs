using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineManager : MonoBehaviour
{

    // 텍스트가 떨어졋을때 감지
    private void OnTriggerEnter2D(Collider2D collider) {
        // Debug.Log(collider.gameObject.name);

        // 통과한 오브젝트가 텍스트 OutputText 인지
        if(collider.gameObject.tag.Equals("OutputText")){
            // Debug.Log("collider Pass");
            Destroy(collider.gameObject);
        }
    }
}
