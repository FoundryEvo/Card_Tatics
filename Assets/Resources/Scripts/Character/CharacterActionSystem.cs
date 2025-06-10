using UnityEngine;

public class CharacterActionSystem : MonoBehaviour
{
    public static CharacterActionSystem Instance { get; private set; }

    [SerializeField] private Player selectedPlayer;
    [SerializeField] private LayerMask CharacterLayerMask;
    private void Start()
    {
        InputMgr.Instance().EnableCheck(true);

        //����¼�����
        EventCenter.Instance().AddEventListener<int>("MouseDown", CheckInputDown);
    }

    private void Awake()
    {
        if (Instance != null) 
        {
            Debug.LogError("There's more than one CharacterActionSystem" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Update()
    {
    }
    private void CheckInputDown(int mouse)
    {
        switch (mouse)
        {
            case 0:
                if (TryHandleCharacterSelection()) return;
                selectedPlayer.Move(MouseWorld.GetPosition());
                Debug.Log("���" + MouseWorld.GetPosition());
                break;
            case 1:
                Debug.Log("�Ҽ�");
                break;
        }
    }

    private bool TryHandleCharacterSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, CharacterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Player>(out Player character))
            {
                selectedPlayer = character;
                return true;
            }

        }
        return false;
    }


}
