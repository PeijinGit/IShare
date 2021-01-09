using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerTest
{
    public interface IFakeServiceCollection
    {
        void AddTransient(Type serviceType, Type implementtationType);

        T GetService<T>();
    }
}
