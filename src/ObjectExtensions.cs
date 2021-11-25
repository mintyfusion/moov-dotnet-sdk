namespace Tutkoo.mintyfusion.Moov.Sdk
{
    #region Namespace
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json.Serialization;
    #endregion Namespace

    #region Class
    public static class ObjectExtensions
    {
        #region Public Static Methods
        public static IDictionary<string, object> AsDictionary(this object source,
            BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr)
                .ToDictionary
                (
                propInfo => propInfo.IsDefined(typeof(JsonPropertyNameAttribute), true) ? propInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name : propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
                );
        }

        public static T ToObject<T>(this IDictionary<string, object> source) where T : class, new()
        {
            T someObject = new T();

            Type someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                PropertyInfo property = someObjectType
                    .GetProperty(item.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (property != null)
                    property.SetValue(someObject, item.Value, null);
            }

            return someObject;
        }
        #endregion Public Static Methods
    }
    #endregion Class
}