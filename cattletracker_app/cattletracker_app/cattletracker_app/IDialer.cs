using System;

namespace cattletracker_app
{
    public interface IDialer
    {
        bool Dial(string number);
    }
}