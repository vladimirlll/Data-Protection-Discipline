using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Lab1.Code.Models
{

    public class TaskData
    {
        /// <summary>
        /// План охраняемого объекта (забор, здание, окна, инф. сист.)
        /// </summary>
        public ObjectPlan Plan { get; }

        /// <summary>
        /// Вероятность проникновения через первое окно
        /// </summary>
        public double FWPenetrationProb { get; }

        /// <summary>
        /// Вероятность проникновения через второе окно
        /// </summary>
        public double SWPenetrationProb { get; }

        public TaskData(ObjectPlan plan, double firstWindowPenetrationProbability, double secondWindowPenetrationProbability)
        {
            Plan = plan;
            FWPenetrationProb = firstWindowPenetrationProbability;
            SWPenetrationProb = secondWindowPenetrationProbability;
        }

    }
}
