using DI.Lab1.Code.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DI.Lab1.Code.Models
{
    public class ObjectPlan
    {
        public double Xfence { get; set; }

        public double Yfence { get; set; }

        public double XfirstWindow {get; set; }
        public double XsecondWindow { get; set; }
        public double Ywindow { get; set; }

        public double XInfSys { get; set; }

        public double YInfSys { get; set; }

        private ObjectPlan() { }

        /*public ObjectPlan(double xfence, double yfence, double xfirstWindow, double xsecondWindow, double ywindow, double xInfSys, double yInfSys)
        {
            Xfence = xfence;
            Yfence = yfence;
            XfirstWindow = xfirstWindow;
            XsecondWindow = xsecondWindow;
            Ywindow = ywindow;
            XInfSys = xInfSys;
            YInfSys = yInfSys;
        }
        */

        public class Builder
        {
            private ObjectPlan _plan;
            private bool _isXFenceSet = false;
            private bool _isYfenceSet = false;

            public Builder() => _plan = new();

            public Builder SetXFence(double x) { _plan.Xfence = x; _isXFenceSet = true; return this; }
            public Builder SetYFence(double y) {  _plan.Yfence = y; _isYfenceSet = true; return this; }
            public Builder SetYWindow(double y) 
            { 
                if(!_isXFenceSet || !_isYfenceSet) throw new FenceCoordinateNotSetException();
                if(y >=  _plan.Yfence) throw new IncorrectCoordinateException();
                _plan.Ywindow = y;
                return this;
            }

            public Builder SetXFirstWindow(double x)
            {
                if (!_isXFenceSet || !_isYfenceSet) throw new FenceCoordinateNotSetException();
                if (x >= _plan.Xfence) throw new IncorrectCoordinateException();
                _plan.XfirstWindow = x;
                return this;
            }

            public Builder SetXSecondWindow(double x)
            {
                if (!_isXFenceSet || !_isYfenceSet) throw new FenceCoordinateNotSetException();
                if (x >= _plan.Xfence) throw new IncorrectCoordinateException();
                _plan.XsecondWindow = x;
                return this;
            }

            public Builder SetXInfSys(double x)
            {
                if (!_isXFenceSet || !_isYfenceSet) throw new FenceCoordinateNotSetException();
                if (x >= _plan.Xfence) throw new IncorrectCoordinateException();
                _plan.XInfSys = x;
                return this;
            }

            public Builder SetYInfSys(double y)
            {
                if (!_isXFenceSet || !_isYfenceSet) throw new FenceCoordinateNotSetException();
                if (y >= _plan.Yfence) throw new IncorrectCoordinateException();
                _plan.YInfSys = y;
                return this;
            }

            public ObjectPlan Build()
            {
                ObjectPlan result = _plan;
                _plan = new ObjectPlan();
                _isXFenceSet = false;
                _isYfenceSet = false;
                return result;
            }
        }

    }
}
