//元ネタ
//http://tenera-it.be/blog/2011/06/add-attriutes-to-a-property-at-runtime/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DynamicAttribute
{
    //注意) さらっと調べただけなので正しい情報は各自調べてください！！

    //Attribute（属性）はコンパイル時に付けられるもので、実行時にどうにかできるものではありません。
    //が、PropertyGridはTypeDescriptor経由で属性を取得するので、そこでどうにかすることが可能です。
    //本来はCustomTypeDescriptorやTypeDescriptionProvider等を使うのが本筋のようです。
    //しかし面倒なので元ネタを参考に直接リフレクションで書き換える力技です。
    //動作確認はできましたが、この先も動く保証はありません。

    public static class PropertyHelper
    {
        /// <summary>プロパティに属性を設定します（同じ属性があった場合は上書き）</summary>
        /// <param name="type">型</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="attribute">設定する属性</param>
        public static void AddAttribute(Type type, string propertyName, Attribute attribute)
        {
            if(type == null) throw new ArgumentNullException(nameof(type));
            if(propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            if(attribute == null) throw new ArgumentNullException(nameof(attribute));

            var prop = TypeDescriptor.GetProperties(type).AsEnumerable<PropertyDescriptor>()
                                                         .Where(x => x.Name == propertyName)
                                                         .FirstOrDefault();
            if(prop == null) throw new ArgumentException($"{type} 型に {propertyName} プロパティはありません。");

            Add(prop, attribute);
        }

        /// <summary>複数のプロパティに属性を一括設定します（同じ属性があった場合は上書き）</summary>
        /// <param name="type">型</param>
        /// <param name="propertyNames">プロパティ名の列挙</param>
        /// <param name="attribute">設定する属性</param>
        public static void AddAttribute(Type type, IEnumerable<string> propertyNames, Attribute attribute)
        {
            if(type == null) throw new ArgumentNullException(nameof(type));
            if(propertyNames == null) throw new ArgumentNullException(nameof(propertyNames));
            if(attribute == null) throw new ArgumentNullException(nameof(attribute));

            var props = TypeDescriptor.GetProperties(type).AsEnumerable<PropertyDescriptor>();
            var except = propertyNames.Except(props.Select(x => x.Name));
            if(except.Any()) throw new ArgumentException($"{type} 型に {string.Join(", ", except)} プロパティはありません。");

            foreach(var prop in props)
            {
                if(propertyNames.Contains(prop.Name))
                    Add(prop, attribute);
            }
        }

        /// <summary>プロパティの属性を削除します</summary>
        /// <param name="type">型</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="attributeType">>削除する属性型</param>
        public static void RemoveAttribute(Type type, string propertyName, Type attributeType)
        {
            if(type == null) throw new ArgumentNullException(nameof(type));
            if(propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            if(attributeType == null) throw new ArgumentNullException(nameof(attributeType));

            var prop = TypeDescriptor.GetProperties(type).AsEnumerable<PropertyDescriptor>()
                                                         .Where(x => x.Name == propertyName)
                                                         .FirstOrDefault();
            if(prop == null) throw new ArgumentException($"{type} 型に {propertyName} プロパティはありません。");

            Remove(prop, attributeType);
        }

        /// <summary>複数のプロパティに属性を一括削除します</summary>
        /// <param name="type">型</param>
        /// <param name="propertyNames">プロパティ名の列挙</param>
        /// <param name="attributeType">>削除する属性型</param>
        public static void RemoveAttribute(Type type, IEnumerable<string> propertyNames, Type attributeType)
        {
            if(type == null) throw new ArgumentNullException(nameof(type));
            if(propertyNames == null) throw new ArgumentNullException(nameof(propertyNames));
            if(attributeType == null) throw new ArgumentNullException(nameof(attributeType));

            var props = TypeDescriptor.GetProperties(type).AsEnumerable<PropertyDescriptor>();
            var except = propertyNames.Except(props.Select(x => x.Name));
            if(except.Any()) throw new ArgumentException($"{type} 型に {string.Join(", ", except)} プロパティはありません。");

            foreach(var prop in props)
            {
                if(propertyNames.Contains(prop.Name))
                    Remove(prop, attributeType);
            }
        }




        private static void Add(PropertyDescriptor prop, Attribute attribute)
        {
            var pi = GetPropertyInfo(prop, "AttributeArray");
            var attributes = pi.GetValue(prop, null) as Attribute[];
            var newAttributes = attributes.Where(x => x.GetType() != attribute.GetType()).ToList();
            newAttributes.Add(attribute);
            pi.SetValue(prop, newAttributes.ToArray(), null);
        }
        private static void Remove(PropertyDescriptor prop, Type attributeType)
        {
            var pi = GetPropertyInfo(prop, "AttributeArray");
            var attributes = pi.GetValue(prop, null) as Attribute[];
            var newAttributes = attributes.Where(x => x.GetType() != attributeType);
            pi.SetValue(prop, newAttributes.ToArray(), null);
        }

        private static PropertyInfo GetPropertyInfo(PropertyDescriptor prop, string name)
            => prop.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic);
    }
}
