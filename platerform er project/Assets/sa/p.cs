using UnityEngine;

// 접근 지정자 public private protected
public class p : MonoBehaviour
{
    // Staett, updaate 유니티 이벤트 함수의 같은 이름이 있는지 조사 
    // 같은 이름 있으면? 유니티에서 정해놓은 실행 시간에 그 함수를 실행

    // Start is called before the first frame update
    // 첫 프레임이 불러지기전에 (한번) 시작한다.

    //속도, 방향
    [Header("이동")]
    public float movespead = 5f;
    public float JumpForce = 10f;
    private float moveInput; // 플레이어의 방향 

    public Transform startTransfrom; // 캐릭터의 시작할 위치
    public Rigidbody2D rigidbody2D; // 물리(강체) 기능을 제어하는 컴포넌트

    [Header("점프")]
    public bool isGrounded;      // true : 캐릭터가 점프 할 수 있는 상태, false : 점프 못함 
    public float groundDistance = 2f;
    public LayerMask groundLayer;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("hello unity");
        transform.position = new Vector2(transform.position.x, 10);
        // guswo so dnlcl <= 새로운 x,y 저장하는 데이터 타입 
        //transform.
    }

    // Update is called once per frame
    // 1프레임 마다 한번 호출된다. - 반복적으로 실행
    void Update() 
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down,groundDistance, groundLayer);
        // 플레이어의 입력 값을 받아와야 합니다.

         moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(movespead * moveInput, rigidbody2D.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // 점프 : Y
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }
}

  