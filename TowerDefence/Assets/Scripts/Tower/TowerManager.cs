using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    private Coroutine berfReEnableCR;
    private Coroutine billitaryReEnableCR;
    private Coroutine buploReEnableCR;
    
    
    private List<Tower> berfTowers = new();
    private List<Tower> billitaryTowers = new();
    private List<Tower> buploTowers = new();

    public float secondsForEnablingTowers;

    public void AddTower(Tower _tower)
    {
        switch (_tower.damageType)
        {
            case eVulType.Berf:
                berfTowers.Add(_tower);
                foreach (Tower tower in berfTowers)
                {
                    tower.SetShooting(false);
                }
                berfReEnableCR = StartCoroutine(EnableBerfTowers_CR());

                foreach (Tower tower in berfTowers)
                {
                    tower.shootCR = StartCoroutine(tower.Shoot_CR());
                }
                break;

             case eVulType.Billitary:
                billitaryTowers.Add(_tower);
                foreach (Tower tower in billitaryTowers)
                {
                    tower.SetShooting(false);
                }
                billitaryReEnableCR = StartCoroutine(EnableBillitaryTowers_CR());

                foreach (Tower tower in billitaryTowers)
                {
                    tower.shootCR = StartCoroutine(tower.Shoot_CR());
                }
                break;

              case eVulType.Buplo:
                buploTowers.Add(_tower);
                foreach (Tower tower in buploTowers)
                {
                    tower.SetShooting(false);
                }
                buploReEnableCR = StartCoroutine(EnableBuploTowers_CR());
                foreach (Tower tower in buploTowers)
                {
                    tower.shootCR = StartCoroutine(tower.Shoot_CR());
                }

                break;
        
        }
    }

    public IEnumerator EnableBerfTowers_CR()
    {
        yield return new WaitForSeconds(secondsForEnablingTowers);
        foreach (Tower tower in berfTowers)
        {
            tower.SetShooting(true);
        }
    }

     public IEnumerator EnableBuploTowers_CR()
    {
        yield return new WaitForSeconds(secondsForEnablingTowers);
        foreach (Tower tower in buploTowers)
        {
            tower.SetShooting(true);
        }
    }

    public IEnumerator EnableBillitaryTowers_CR()
    {
        yield return new WaitForSeconds(secondsForEnablingTowers);
        foreach (Tower tower in billitaryTowers)
        {
            tower.SetShooting(true);
        }
    }
}
