

namespace WebAPI
{
    using System.Linq;
    public static class Extensions
    {
        public static void Populate<T>(this T obj, object data) where T : class
        {
            foreach (var prop in data.GetType().GetProperties())
                obj.GetType().GetProperties().FirstOrDefault(el => el.Name == prop.Name)
                    .SetValue(obj, prop.GetValue(data, null));

        }

        public static T Populating<T>(this T obj, object data) where T : class
        {
            obj.Populate(data);
            return obj;
        }
    }
}