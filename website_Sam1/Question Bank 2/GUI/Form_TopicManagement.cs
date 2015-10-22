using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QuestionBankLibrary;

namespace GUI
{
    public partial class Form_TopicManagement : Form
    {
        List<Topic> topicList = new List<Topic>();
        List<string> topicIDList = new List<string>();

        public Form_TopicManagement()
        {
            InitializeComponent();
            loadTopicList();
            lbTopic.SelectedIndexChanged += new EventHandler(lbTopic_SelectedIndexChanged);
            btAdd.Enabled = false;
            btUpdate.Enabled = false; btDelete.Enabled = false;
        }

//==================================Event definition========================================
//==========================================================================================
        //Listbox Click Event
        public void lbTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTopic.SelectedIndex != -1)
            {
                txtTopicName.Text = topicList[lbTopic.SelectedIndex].TopicName;
                txtTopicID.Text = topicList[lbTopic.SelectedIndex].TopicID;
            }   
        }
//==========================================================================================


//==================================Additional functions====================================
//==========================================================================================
        //Load all topic from sql server
        public void loadTopicList()
        {
            topicList.Clear();
            lbTopic.Items.Clear();
            topicIDList.Clear();
            BOTopic bot = new BOTopic();
            topicList = bot.ListAll();
            for (int i = 0; i < topicList.Count; i++)
            {
                lbTopic.Items.Add(topicList[i]);
                topicIDList.Add(topicList[i].TopicID);
            }
            lbTopic.Sorted = true;
        }
//==========================================================================================


//==================================Button functions========================================
//==========================================================================================

        private void btAdd_Click(object sender, EventArgs e)
        {
            //validate inputs
            if (topicIDList.Contains(txtTopicID.Text)==false)
            {
                //create Topic object
                Topic t = new Topic();
                t.TopicID = this.txtTopicID.Text;
                t.TopicName = this.txtTopicName.Text;
                //insert topic object into Topic table
                BOTopic bot = new BOTopic();
                bool success = bot.Add(t);
                if (success)
                {
                    MessageBox.Show("Add topic success!");
                    loadTopicList();
                }
                else MessageBox.Show("Failed to add a topic!");
                txtTopicID.Clear();
                txtTopicName.Clear();
            }
            else
                MessageBox.Show("The topic code is exist");
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            int i = lbTopic.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Select a topic to change");
                return;
            }
            else
            {
                string oldTopicID = topicList[i].TopicID;
                BOTopic bot = new BOTopic();
                Topic t = new Topic(txtTopicID.Text, txtTopicName.Text);
                bool success =bot.Update(t, oldTopicID);
                if (success)
                {
                    MessageBox.Show("Update topic success!");
                    loadTopicList();
                }
                else MessageBox.Show("Failed to update a topic!");
                txtTopicID.Clear();
                txtTopicName.Clear();
                btUpdate.Enabled = false; btDelete.Enabled = false;
                loadTopicList();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            //parent.refreshCBBox();
            this.Dispose();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int i = lbTopic.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Select a topic to change");
                return;
            }
            else
            {
                string topicID = topicList[lbTopic.SelectedIndex].TopicID;
                BOTopic bot = new BOTopic();
                bool success = bot.Delete(topicID);
                if (success)
                {
                    MessageBox.Show("Delete topic success!");
                    loadTopicList();
                }
                else MessageBox.Show("Failed to delete a topic!");
                txtTopicID.Clear();
                txtTopicName.Clear();
                btUpdate.Enabled = false; btDelete.Enabled = false;
                loadTopicList();
            }
        }
//==========================================================================================

        private void TextChanged(object sender, EventArgs e)
        {
            btAdd.Enabled = !(txtTopicID.Text.Equals("") || txtTopicName.Text.Equals(""));
            
        }


        private void IndexChanged(object sender, EventArgs e)
        {
            btUpdate.Enabled = btDelete.Enabled = !(lbTopic.SelectedIndex == -1);

        }
    }


}
