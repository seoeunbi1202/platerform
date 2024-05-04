using UnityEngine;

// ���� ������ public private protected
public class p : MonoBehaviour
{
    // Staett, updaate ����Ƽ �̺�Ʈ �Լ��� ���� �̸��� �ִ��� ���� 
    // ���� �̸� ������? ����Ƽ���� ���س��� ���� �ð��� �� �Լ��� ����

    // Start is called before the first frame update
    // ù �������� �ҷ��������� (�ѹ�) �����Ѵ�.

    //�ӵ�, ����
    [Header("�̵�")]
    public float movespead = 5f;
    public float JumpForce = 10f;
    private float moveInput; // �÷��̾��� ���� 

    public Transform startTransfrom; // ĳ������ ������ ��ġ
    public Rigidbody2D rigidbody2D; // ����(��ü) ����� �����ϴ� ������Ʈ

    [Header("����")]
    public bool isGrounded;      // true : ĳ���Ͱ� ���� �� �� �ִ� ����, false : ���� ���� 
    public float groundDistance = 2f;
    public LayerMask groundLayer;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("hello unity");
        transform.position = new Vector2(transform.position.x, 10);
        // guswo so dnlcl <= ���ο� x,y �����ϴ� ������ Ÿ�� 
        //transform.
    }

    // Update is called once per frame
    // 1������ ���� �ѹ� ȣ��ȴ�. - �ݺ������� ����
    void Update() 
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down,groundDistance, groundLayer);
        // �÷��̾��� �Է� ���� �޾ƿ;� �մϴ�.

         moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(movespead * moveInput, rigidbody2D.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // ���� : Y
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }
}

  