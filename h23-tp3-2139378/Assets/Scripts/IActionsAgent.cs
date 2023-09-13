using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IActionsAgent
    {

        public void OuvrirPorte();//
        public void DesactiverRobot();//
        public void ReanimerAgent();//

        bool IsOuvrirPorteAvailable();
        bool IsDesactiverRobotAvailable();
        bool IsReanimerAgentAvailable();
    }
}
