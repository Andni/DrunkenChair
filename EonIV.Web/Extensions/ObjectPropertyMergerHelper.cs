using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niklasson.DrunkenChair.Extensions
{
    public static class ObjectPropertyMergerHelper
    {
        public static object AppendProperties(this object target, object source)
        {
            foreach(var p in source.GetType().GetProperties().Where(prop => prop.CanRead))
            {
                var val = p.GetValue(source);                
                p.SetValue(target, val);
            }

            return target;
        }

        public static T MergeWith<T>(this T primary, T secondary)
        {
            foreach (var pi in typeof(T).GetProperties())
            {
                var priValue = pi.GetGetMethod().Invoke(primary, null);
                var secValue = pi.GetGetMethod().Invoke(secondary, null);
                if (priValue == null || (pi.PropertyType.IsValueType && priValue.Equals(Activator.CreateInstance(pi.PropertyType))))
                {
                    pi.GetSetMethod().Invoke(primary, new object[] { secValue });
                }
            }
            return primary;
        }

        public static void herp()
        {
            var o = new {t= 2};
            var b = new {k= 3};

            o.MergeWith<object>(b);
        }
    }
}