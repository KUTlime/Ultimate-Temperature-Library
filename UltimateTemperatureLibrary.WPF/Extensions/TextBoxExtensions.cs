using System;
using System.Reflection;
using System.Windows.Controls;

namespace UltimateTemperatureLibrary.WPF.Extensions
{
    public static class TextBoxExt
    {
        private static readonly FieldInfo Field;
        private static readonly PropertyInfo Prop;

        static TextBoxExt()
        {
            Type type = typeof(Control);
            Field = type.GetField("text", BindingFlags.Instance | BindingFlags.NonPublic);
            Prop = type.GetProperty("WindowText", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static void SetText(this TextBox box, string text)
        {
            Field.SetValue(box, text);
            Prop.SetValue(box, text, null);
        }
    }
}