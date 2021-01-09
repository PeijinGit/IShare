using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ControllerTest
{
    public class FakeServiceCollection : IFakeServiceCollection
    {
        private Dictionary<string, Type> serviceDictionary = new Dictionary<string, Type>();


        /// <summary>
        /// Register service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementtationType"></param>
        public void AddTransient(Type serviceType, Type implementtationType)
        {
            serviceDictionary.Add(serviceType.FullName, implementtationType);
        }

        /// <summary>
        /// Get service instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            var type = serviceDictionary[typeof(T).FullName];
            return (T)this.GetService(type);
        }

        private object GetService(Type type) 
        {
            var constructorArray = type.GetConstructors();

            ConstructorInfo constructorInfo = constructorArray.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
            List<object> paramList = new List<object>();
            foreach (ParameterInfo para in constructorInfo.GetParameters()) 
            {
                Type paraType = para.ParameterType;
                Type paraTargetType = serviceDictionary[paraType.FullName];
                var target = this.GetService(paraTargetType);
                paramList.Add(target);
            }
            return Activator.CreateInstance(type, paramList.ToArray());
        }
    }
}
