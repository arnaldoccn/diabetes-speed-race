using UnityEngine;
using System.Collections;

public class FirstScreen : MonoBehaviour {

    [SerializeField]
    private GUIStyle styleOfTextBox;
    [SerializeField]
    private float nameX;
    [SerializeField]
    private float nameY;
    [SerializeField]
    private float nameSizeX;
    [SerializeField]
    private float nameSizeY;
    [SerializeField]
    private float crmX;
    [SerializeField]
    private float crmY;
    [SerializeField]
    private float crmSizeX;
    [SerializeField]
    private float crmSizeY;
    [SerializeField]
    private int nameTextLimit;
    [SerializeField]
    private int crmTextLimit;

    public string name  = "Seu Nome";
    public string crm   = "Seu CRM";
    
    private static FirstScreen instance;

    private FirstScreen( ) { }

    public static FirstScreen Instance
    {
        get
        {
            return instance;
        }
    }

    void Start()
    {
        instance = this;
    }

    void OnGUI( )
    {
        name    = GUI.TextField( new Rect( nameX, nameY, nameSizeX, nameSizeY ), name, nameTextLimit, styleOfTextBox );
        crm     = GUI.TextField( new Rect( crmX, crmY, crmSizeX, crmSizeY ), crm, crmTextLimit, styleOfTextBox );
    }
}
