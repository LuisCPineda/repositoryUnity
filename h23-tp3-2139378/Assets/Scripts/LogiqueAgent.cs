using Assets.Scripts;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public delegate void AgentEstAssome(LogiqueAgent ch);

public class LogiqueAgent : MonoBehaviour, IActionsAgent
{
    [SerializeField] private Sprite _imageJoueur;

    
    public event AgentEstAssome AgentEstAssomeHandler;

    private Animator _animator;
    private NavMeshAgent _agent;
    private EtatPersonnage _etatCourant;
    private float _actionPoints;


    // Les diff�rents �tats
    public CharacterIdle Idle
    {
        private set;
        get;
    }

    public CharacterMoving Moving
    {
        private set;
        get;
    }

    public CharacterAssome Assome
    {
        private set;
        get;
    }

    public bool EstActif
    {
        get
        {
            return _etatCourant != Assome;
        }
    }

    public float ActionPoints
    {
        get { return _actionPoints; }
        set
        {
            _actionPoints = value;
            if (_actionPoints < 0)
            {
                _actionPoints = 0;
            }
        }
    }

    public float ActionPointsMax
    {
        set;
        get;
    }

    // Start is called before the first frame update

    void Awake()
    {
        Idle = new CharacterIdle(gameObject);
        Moving = new CharacterMoving(gameObject);
        Assome = new CharacterAssome(gameObject);

        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _etatCourant = Idle;
        _etatCourant.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        _etatCourant.Handle(Time.deltaTime);
    }

    public void SetDestination(Vector3 destination)
    {
        if (PathExists(destination))
        { 
            ChangerEtat(Moving); 
            _agent.destination = destination;
        }
    }

    private bool PathExists(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();
        _agent.CalculatePath(destination, path);
        return path.status == NavMeshPathStatus.PathComplete;
    }

    public void ChangerEtat(EtatPersonnage nouvelEtat)
    {
        Debug.Log("On quitte: " + _etatCourant.GetType().Name);
        _etatCourant.Leave();
        _etatCourant = nouvelEtat;
        Debug.Log("On entre: " + _etatCourant.GetType().Name);
        _etatCourant.Enter();
    }

    public void Teleporter(Vector3 destination)
    {
        _agent.enabled = false;
        transform.position = destination;
        _agent.enabled = true;
    }

    public void AssommerJoueur()
    {
        // Le personnage ne sera plus actif
        ChangerEtat(Assome);
        if (AgentEstAssomeHandler != null)
        {
            //AgentEstAssomeHandler(this);
            ActionPoints = 0;
        }
    }
    public void NouveauTour()
    {
        ActionPoints = ActionPointsMax;
    }

    [CanBeNull]
    public OuvrirPortes Porte
    {
        set;
        get;
    }
    public Sprite ImageJoueur
    {
        get { return _imageJoueur; }
    }

    public string Nom
    {
        set;
        get;
    }

    public void RetirerPointsAction(float points)
    {
        ActionPoints -= points;
    }
    public void ReanimerAgent()
    {
        ChangerEtat(Idle);
        ActionPoints = ActionPointsMax / 2;
    }

    public void OuvrirPorte()
    {
        Porte.Ouvrir();
    }

    public void DesactiverRobot()
    {
        throw new System.NotImplementedException();
    }

    public bool IsOuvrirPorteAvailable()
    {
        bool ouvert=false;
        if(Porte != null && !Porte.EstOuverte && ActionPoints >= 2.0f){
            ouvert= true;
        }
        return ouvert;
    }

    public bool IsDesactiverRobotAvailable()
    {
        bool desactiver=false;
        if(ActionPoints >= 4.0f)
        {
            desactiver= true;
        }
        return desactiver; 
    }
    public bool IsReanimerAgentAvailable()
    {
        bool reanimer;
        if (!EstActif && ActionPoints >= 2.0f)
        {
            reanimer = false;
        }
        else
        {
            reanimer = true;
        }
        return reanimer;
    }

    void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == $"Porte")
        {
            OuvrirPortes scriptPorte = collision.gameObject.GetComponent<OuvrirPortes>();
            if(scriptPorte != null)
            {
                Debug.Log(scriptPorte.EstOuverte);
                if (scriptPorte.IsClosing)
                {
                    Debug.Log("Collision");
                    AssommerJoueur();
                }
            }
            
        }
    }
}
