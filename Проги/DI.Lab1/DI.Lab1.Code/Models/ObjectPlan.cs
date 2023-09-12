using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Lab1.Code.Models
{
    public class ObjectPlan
    {
        public double Xfence { get; }

        public ObjectPlan(double xfence, double yfence, double xfirstWindow, double xsecondWindow, double ywindow, double xInfSys, double yInfSys)
        {
            Xfence = xfence;
            Yfence = yfence;
            XfirstWindow = xfirstWindow;
            XsecondWindow = xsecondWindow;
            Ywindow = ywindow;
            XInfSys = xInfSys;
            YInfSys = yInfSys;
        }

        public double Yfence { get; }

        public double XfirstWindow { get; }
        public double XsecondWindow { get; }
        public double Ywindow { get; }

        public double XInfSys { get; }
        public double YInfSys { get; }


    }
}
