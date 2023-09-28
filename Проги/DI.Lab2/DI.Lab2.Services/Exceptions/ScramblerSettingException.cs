using System;

namespace DI.Lab2.Services.Exceptions
{
    public abstract class ScramblerSettingException : Exception
    {
        public ScramblerSettingException(string msg) : base(msg) { }
    }
}
