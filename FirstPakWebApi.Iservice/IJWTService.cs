using FirstPakWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.IService
{
    public interface IJWTService
    {
        string GetToken(ViewAuth auth);
    }
}
