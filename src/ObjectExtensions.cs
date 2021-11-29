namespace Tutkoo.mintyfusion.Moov.Sdk
{
    #region Namespace
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
        #endregion Public Static Methods
    }
    #endregion Class
}