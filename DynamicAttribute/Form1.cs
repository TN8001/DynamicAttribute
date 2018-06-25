using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace DynamicAttribute
{
    public partial class Form1 : Form
    {
        ///<summary>Attributeを変更するクラスを保持する</summary>
        public class ControlHolder
        {
            ///<summary>Attributeを変更したプロパティ</summary>
            public BindingList<string> HidePropertys = new BindingList<string>();
            ///<summary>Attributeを変更するクラスの実体</summary>
            public Control Control;
            /// <summary>Attributeを変更するクラスを保持する</summary>
            /// <param name="control">Attributeを変更するクラスの実体</param>
            public ControlHolder(Control control) => Control = control;

            public override string ToString() => Control.GetType().Name;
        }


        private static readonly Attribute BrowsableTrue = new BrowsableAttribute(true);
        private static readonly Attribute BrowsableFalse = new BrowsableAttribute(false);

        private List<ControlHolder> controlHolders = new List<ControlHolder>();

        public Form1()
        {
            InitializeComponent();


            var textBox = new ControlHolder(new TextBox());

            //個別設定
            PropertyHelper.AddAttribute(typeof(TextBox), "BackColor", BrowsableFalse);
            textBox.HidePropertys.Add("BackColor");

            //一括設定
            PropertyHelper.AddAttribute(typeof(TextBox), new string[] { "Font", "Lines" }, BrowsableFalse);
            textBox.HidePropertys.AddRange(new string[] { "Font", "Lines" });


            controlHolders.Add(textBox);
            controlHolders.Add(new ControlHolder(new Button()));

            controlListBox.DataSource = controlHolders;
            controlListBox.SelectedIndex = 0;
        }

        private void ControlListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var holder = controlListBox.SelectedItem as ControlHolder;
            propertyGrid1.SelectedObject = holder.Control;

            hidePropertyListBox.DataSource = holder.HidePropertys;
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            var item = propertyGrid1.SelectedGridItem;
            if(item.GridItemType != GridItemType.Property) return; // プロパティ以外を選択中

            var selectedObj = propertyGrid1.SelectedObject;
            var instance = item.GetType().GetProperty("Instance").GetValue(item);

            if(selectedObj != instance) return; // 孫プロパティを選択中

            var holder = controlListBox.SelectedItem as ControlHolder;
            var propertyName = item.GetType().GetProperty("PropertyName").GetValue(item) as string;


            PropertyHelper.AddAttribute(holder.Control.GetType(), propertyName, BrowsableFalse);
            holder.HidePropertys.Add(propertyName);
            propertyGrid1.Refresh();
        }


        private void ShowButton_Click(object sender, EventArgs e)
        {
            var holder = controlListBox.SelectedItem as ControlHolder;
            var propertyName = hidePropertyListBox.SelectedItem as string;
            if(holder == null || propertyName == null) return;


            PropertyHelper.AddAttribute(holder.Control.GetType(), propertyName, BrowsableTrue);
            // BrowsableAttributeを削除しても表示される
            //PropertyHelper.RemoveAttribute(Holder.Ctrl.GetType(), propName, typeof(BrowsableAttribute));
            holder.HidePropertys.Remove(propertyName);
            propertyGrid1.Refresh();
        }
    }
}
