using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField]
    internal ManagerScript managerScript;

    [SerializeField]
    internal bool grounded;

    internal Vector3 contactPoint;
    internal Vector3 impulseVector;
    internal Vector3 relativeSpeedVector;

    private void Awake()
    {
        grounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Otra de las habilidades principales de Preah es la de ANULAR o TRANSFERIR fuerza.
        //Si haces parry rebotas contra la superficie (cancelas el choque) sino te comes todo el bife entero de una
        //Si caes a mucha velocidad...
        //Si te chocas a mucha velocidad...
        //Si caes con mucha velocidad contra un angulo no 90%... Preah podria a) bancarsela b) resbalarse y rodar hasta el fundo c) estamparse contra el piso. Una cosa es sabida: el angulo no varia con la fuerza. Siempre es el mismo. Por ende, Preah tiene un ANGULO de tolerancia. Es bastante simple: tiene que ser mayor a 45% desde el angulo de impulso hacia el piso.
        //Entonces, que pasa cuando Preah usa AntiGrav? Al usar AntiGrav Preah incrementa su peso, por ende su balance tambien, no?
        //El tema es que, si usar AntiGrav incrementa el peso de Preah, y esto incrementa su fueza y velocidad vertical, esto no implicaria tambien que se estampa contra el piso con mucha mas facilidad?
        //La idea es que usar AntiGrav para bajar rapido sea una apuesta, que incremente tu velocidad a cambio de riesgo. El tema es que si fuera una cuestion de velocidad Preah se haria concha cada vez que salta.
        //La solucion: AntiGrav incrementa la tolerancia de Preah acordemente. El tema es que todo valor afuera del espectro de tolerancia se mantiene crudo.
        //La tolerancia de modo normal es constante porque la gravedad se mantiene constante tambien.
        //Esto implica, entonces, que la tolerancia horizontal del AntiGrav es igual? O solo la vertical? Como funciona eso? Respuesta: Solo la vertical. Se aplican los mismos calculos, simplemente a mayor velocidad.
        //Despues se va a implementar ragdoll, pero por ahora Preah simplemente rebota una distancia relativa a la velocidad a la que iba y queda stuneada.


        //if Impulse Angle = 90% o esta entre los valores aceptados...

        /*if (collision.collider.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.collider.tag == "Wall")
        {
            managerScript.wallClimbScript.wallHanging = true;
        }*/
        managerScript.wallClimbScript.wallJumping = false;
        managerScript.jumpScript.rising = false;

        contactPoint = collision.GetContact(0).point;
        impulseVector = collision.impulse.normalized;
        relativeSpeedVector = collision.relativeVelocity;
        managerScript.jumpScript.fullJump = false;

        //Crashing
        if (((Mathf.Abs(relativeSpeedVector.x) > managerScript.balanceScript.crashThreshold) || (Mathf.Abs(relativeSpeedVector.y) > managerScript.balanceScript.crashThreshold)) && impulseVector.y!=1)
        {
            managerScript.rb.velocity = Vector3.zero;
            managerScript.rb.angularVelocity = Vector3.zero;
            managerScript.rb.velocity = new Vector3(relativeSpeedVector.x, relativeSpeedVector.y+ managerScript.balanceScript.crashVerticalForceAddition, 0f) / managerScript.balanceScript.crashForceReduction;
            managerScript.balanceScript.crashstunTimer = managerScript.balanceScript.crashstunTime;
        }

        //Todo choque te hace verga. Como determinar cuando Preah cae parada, o en que posicion?

        //Debug
        managerScript.debugScript.timerOn = false;
        managerScript.debugScript.secondDist = managerScript.rb.transform.position.x;
        managerScript.debugScript.lastDistBetween = Mathf.Abs(managerScript.debugScript.firstDist - managerScript.debugScript.secondDist);


        if (managerScript.parryScript.parryTimer>0f)
        {
            managerScript.parryScript.parryStart = true;
        }
        else
        {
            managerScript.parryScript.parrying = false;
            managerScript.parryScript.parrySpeedMag = managerScript.parryScript.parrySpeedMagBase;

            if (managerScript.balanceScript.overBoard)
            {
                managerScript.balanceScript.crashstunTimer = relativeSpeedVector.magnitude/managerScript.balanceScript.crashStunVFactor;
            }
        }

        if(managerScript.parryScript.parryDownTimer>0f)
        {
            managerScript.balanceScript.crashed = true;
        }

        if (managerScript.collisionScript.grounded == true && managerScript.balanceScript.riding == true)
        {
            managerScript.balanceScript.riding = false;
            if (managerScript.inertia > managerScript.balanceScript.noControlThreshold)
            {
                managerScript.balanceScript.noControl = true;
            }
            else if (managerScript.inertia > managerScript.horizontalScript.maxMoveSpeed)
            {
                managerScript.balanceScript.imbalanced = true;
            }
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        /*
        if (collision.collider.tag == "Ground")
        {
            grounded = true;
        }
        */

        if (managerScript.collisionScript.grounded == true && managerScript.balanceScript.riding == true)
        {
            managerScript.balanceScript.riding = false;
            if (managerScript.inertia > managerScript.balanceScript.noControlThreshold)
            {
                managerScript.balanceScript.noControl = true;
            }
            else if (managerScript.inertia > managerScript.horizontalScript.maxMoveSpeed)
            {
                managerScript.balanceScript.imbalanced = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        managerScript.movementAnimationScript.animator.SetFloat("CrashForce", 0f);

        //Debug
        managerScript.debugScript.testTimer = 0f;
        managerScript.debugScript.timerOn = true;
        managerScript.debugScript.topY = 0f;
        managerScript.debugScript.firstDist = managerScript.rb.transform.position.x;
    }
}
