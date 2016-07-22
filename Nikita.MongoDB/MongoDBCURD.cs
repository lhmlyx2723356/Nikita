using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 

namespace Nikita.NoSQL.MongoDBCore
{
    public partial class MongoDBCURD : Form
    {
        public MongoDBCURD()
        {
            InitializeComponent();
        }
        MonogoDBHelper helper=new MonogoDBHelper();
        private void button1_Click(object sender, EventArgs e)
        {
            helper.InsertOne();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            helper.InsertMany();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            helper.ReplaceOne();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            helper.Delete();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            helper.UpdateOne();
        }
    }
}
