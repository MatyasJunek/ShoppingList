using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Item> MyList;
        public class Item
        {
            public TextBox text;
            public Button delete;
            public CheckBox box;
            public int n;
            public Item(int left, int top, int n)
            {
                this.n = n;
                text = new TextBox();
                delete = new Button();
                box = new CheckBox();


                text.Left = left + 30;
                text.Top = top;
                text.Width = 400;
                
                box.Left = text.Width + 100;
                box.Top = top;
                delete.Left = box.Left + box.Width;
                delete.Top = top;
                delete.Text = "Smazat";
                delete.Tag = this;
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.MyList = new List<Item>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item item = new Item(this.button1.Left, this.button1.Top, this.MyList.Count);
            MyList.Add(item);
            Controls.Add(item.text);
            Controls.Add(item.box);
            Controls.Add(item.delete);
            item.delete.Click += new EventHandler(delete_Click);
            button1.Top += 40;
        }
        private void delete_Click(object sender, EventArgs e)
        {
            int current = (((Control)sender).Tag as Item).n;
            for (int i = current + 1; i < MyList.Count; i++)
            {
                MyList[i].text.Top -= 40;
                MyList[i].box.Top -= 40;
                MyList[i].delete.Top -= 40;
                --(MyList[i].delete.Tag as Item).n;
            }
            Controls.Remove(MyList[current].text);
            Controls.Remove(MyList[current].box);
            Controls.Remove(MyList[current].delete);
            MyList.Remove(MyList[current]);
            button1.Top -= 40;      
        }
    }
}
