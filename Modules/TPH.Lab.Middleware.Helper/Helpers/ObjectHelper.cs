namespace TPH.Lab.Middleware.Helpers
{
    using Spring.Context.Support;
    using Spring.Objects.Factory.Support;
    using System.Collections.Generic;
    using System.Linq;
    public class ObjectHelper<T>
    {
        public static T GetObjectFacroty()
        {
            var listItem = ContextRegistry.GetContext().GetObjectsOfType(typeof(T)).Values;
            return listItem.Cast<T>().FirstOrDefault();
        }
        public static List<T> GetObjectFacrotys()
        {
            List<T> result = new List<T>();
            var listItem = ContextRegistry.GetContext().GetObjectsOfType(typeof(T)).Values;

            foreach (var itemAdd in listItem)
            {
                result.Add((T)itemAdd);
            }
            return result;
        }

        public static T GetObjectFacroty(string objectName)
        {
            var temp = ContextRegistry.GetContext().GetObject(objectName);
            if (temp != null)
            {
                return (T)temp;
            }
            else
            {
                return default(T);
            }
        }
    }
    public class SpringDynamicObjectHttpWebRequestHelper<T> : AbstractObjectDefinition// IObjectDefinition
    {
        public SpringDynamicObjectHttpWebRequestHelper()
        {
            this.ObjectType = typeof(T);
            this.ObjectTypeName = typeof(T).Namespace + "." + typeof(T).Name;
        }

        public override string ParentName
        {
            get { return null; }
            set { }
        }
    }
}
