using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using QuestionBankLibrary;


namespace GUI
{
    public partial class Form_QuestionManagement : Form
    {
        List<Question> questionList = new List<Question>();
        List<Answer> answerList = new List<Answer>();
        List<Topic> topicList = new List<Topic>();
        ArrayList codeList = new ArrayList();
        Image image;

        //Start
        public Form_QuestionManagement()
        {
            InitializeComponent();
            loadData();
            cbbTopic.DataSource = topicList;
            //assign event with listbox
            lbQuestion.SelectedIndexChanged += new System.EventHandler(lbQuestion_Click);
            bt_Add.Enabled = btUpdate.Enabled = btDelete.Enabled = btSearch.Enabled = btClear.Enabled = false;
            errmes.Text = "";
        }

//==================================Event definition========================================
//==========================================================================================
        //List Box Click Event
        private void lbQuestion_Click(object sender, EventArgs e)
        {
            if (lbQuestion.SelectedIndex != -1)
            {
                string s = lbQuestion.GetItemText(lbQuestion.SelectedItem);
                string[] words = s.Split('[', ']');
                for (int i = 0; i < questionList.Count; i++)
                    if (questionList[i].Code == Convert.ToInt32(words[1]))
                        showInfo(i);
            }
        }
//==========================================================================================


//==================================Additional functions====================================
//==========================================================================================

        //Show all question 
        public void showAll()
        {
            cbbTopic.Text = null;
             lbQuestion.Items.Clear();
                for (int i = 0; i < questionList.Count; i++)
                    lbQuestion.Items.Add(questionList[i]);
        }

        //Show info of a question when it is selected in listbox
        public void showInfo(int index)
        {
            clearInfo();
            if (index != -1)
            {
                TextBox[] txtAnswers = { txtAnswerA, txtAnswerB, txtAnswerC, txtAnswerD, txtAnswerE, txtAnswerF };
                CheckBox[] ckbAnswers = { ckbAnswerA, ckbAnswerB, ckbAnswerC, ckbAnswerD,ckbAnswerE, ckbAnswerF };
               
                txtCode.Text = "" + questionList[index].Code;
                txtMark.Text = "" + (questionList[index]).Mark;
                cbbTopic.Text = questionList[index].Topic;
                txtQuestion.Text = questionList[index].Text;
                for (int i = 0; i < questionList[index].Answers.Count; i++)
                {
                    txtAnswers[i].Text = questionList[index].Answers[i].Text;
                    ckbAnswers[i].Checked = questionList[index].Answers[i].IsCorrect;
                }
                if (questionList[index].Image != null)
                {
                    image = ByteToImage(questionList[index].Image);
                    pictureBox.Image = image;
                }                
            }
        }
        
        //Clear all fields in form
        public void clearInfo()
        {
            TextBox[] txtAnswers = { txtAnswerA, txtAnswerB, txtAnswerC, txtAnswerD, txtAnswerE, txtAnswerF };
            CheckBox[] ckbAnswers = { ckbAnswerA, ckbAnswerB, ckbAnswerC, ckbAnswerD, ckbAnswerE, ckbAnswerF };
                
            txtCode.Clear();
            txtMark.Clear();
            cbbTopic.Text = null;
            txtQuestion.Clear();
            for (int i = 0; i < 6; i++)
            {
                txtAnswers[i].Clear();
                ckbAnswers[i].Checked = false;
            }
            pictureBox.Image = null;
        }
        
        //checkInput
        public bool checkInput()
        {
          try{
              if (txtCode.Text.Equals("")
                             && txtAnswerA.Text.Equals("")
                             && txtAnswerB.Text.Equals("")
                             && txtAnswerC.Text.Equals("")
                             && txtAnswerD.Text.Equals("")
                             && txtAnswerE.Text.Equals("")
                             && txtAnswerF.Text.Equals("")
                             && txtQuestion.Text.Equals("")
                             && txtMark.Text.Equals("")

                             && (ckbAnswerA.Checked == false && ckbAnswerB.Checked == false &&
                     ckbAnswerC.Checked == false && ckbAnswerD.Checked == false &&
                     ckbAnswerE.Checked == false && ckbAnswerF.Checked == false))
              { errmes.Text = ""; return false; }
            else if (txtCode.Text.Equals(""))
            {
                //MessageBox.Show("Question code must not be empty!!!");

                errmes.Text = "Question code must not be empty!!!";
                return false;
            }
            else if (!isDigitsOnly(txtCode.Text))
            {
                errmes.Text = "Question code must be a number!!!";
                return false;
            }
            else if (txtQuestion.Text.Equals(""))
            {
                errmes.Text = "Question must not be empty!!!";
                return false;
            }
            else if (txtMark.Text.Equals("") || Convert.ToDouble(txtMark.Text) <= 0)
            {
                errmes.Text = "The mark must be a number greater than 0!!!";
                return false;
            }
            else if (answerList.Count < 2)
            {
                errmes.Text = "The answers must be greater or equal 2!!!";
                return false;
            }
            else if (ckbAnswerA.Checked == false && ckbAnswerB.Checked == false &&
                    ckbAnswerC.Checked == false && ckbAnswerD.Checked == false &&
                    ckbAnswerE.Checked == false && ckbAnswerF.Checked == false)
            {
                errmes.Text = "At least 1 answer is correct!!!";
                return false;
            }
            else if ((txtAnswerA.Text.Equals("") && ckbAnswerA.Checked == true) ||
                    (txtAnswerB.Text.Equals("") && ckbAnswerB.Checked == true) ||
                    (txtAnswerC.Text.Equals("") && ckbAnswerC.Checked == true) ||
                    (txtAnswerD.Text.Equals("") && ckbAnswerD.Checked == true) ||
                    (txtAnswerE.Text.Equals("") && ckbAnswerE.Checked == true) ||
                    (txtAnswerF.Text.Equals("") && ckbAnswerF.Checked == true))
            {
                errmes.Text = "An empty answer is checked!!!";
                return false;
            }
            else
            {
                errmes.Text = "";
                return true;
            }
                
          }
          catch (FormatException)
          {
              errmes.Text = "The mark must be a real number!!!";
              return false;
              
          }
        }
        
        //Check if a string contains disgits only
        public bool isDigitsOnly(string s)
        {
            for(int i=0;i<s.Length;i++)
                if(s[i]<'0'||s[i]>'9')
                    return false;
            return true;
        }

        //Make a question from input information
        public Question input()
        {
            TextBox[] txtAnswers = { txtAnswerA, txtAnswerB, txtAnswerC, txtAnswerD, txtAnswerE, txtAnswerF };
            CheckBox[] ckbAnswers = { ckbAnswerA, ckbAnswerB, ckbAnswerC, ckbAnswerD, ckbAnswerE, ckbAnswerF };

            answerList = new List<Answer>();
            Question q = new Question();
            Answer a;

            try
            {
                for (int i = 0; i < 6; i++)
                {
                    a = new Answer();
                    if (txtAnswers[i].Text.Equals("") == false)
                    {
                        a.Code = Convert.ToInt32(txtCode.Text)*10+i;
                        a.QCode = Convert.ToInt32(txtCode.Text);
                        a.Text = txtAnswers[i].Text;
                        a.IsCorrect = ckbAnswers[i].Checked;
                        answerList.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //check input
            if (checkInput() != false)
            {
                q.Code = Convert.ToInt32(txtCode.Text);
                q.Text = (txtQuestion).Text;
                q.Mark = Convert.ToDouble(txtMark.Text);
                q.Topic = cbbTopic.Text;
                q.Answers = answerList;
                if (image != null)
                {
                    q.Image = ImageToByte(image);
                }
                else
                    q.Image = null;

                return q;
            }
            return null;
        }

        //Save data to the sql database
        public void saveData(Question q)
        {
            BOQuestion boq = new BOQuestion();
            BOAnswer boa = new BOAnswer();
            boq.Add(q);
        }
        
        //Load data from sql database
        public void loadData()
        {
            //Load topic
            BOTopic bot = new BOTopic();
            topicList = bot.ListAll();
            cbbTopic.DataSource = topicList;

            //Load questions and answers
            BOQuestion boq = new BOQuestion();
            BOAnswer boa = new BOAnswer();
            answerList = boa.ListAll();
            questionList = boq.ListAll();
            for (int i = 0; i < questionList.Count; i++)
            {
                questionList[i].Answers = new List<Answer>();
                for (int j = 0; j < answerList.Count; j++)
                    if (answerList[j].QCode == questionList[i].Code)
                    {
                        questionList[i].Answers.Add(answerList[j]);
                    }
                codeList.Add(questionList[i].Code);
            }
            showAll();
        }

        //Convert an image to byte array
        public byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            try
            {
                return (byte[])converter.ConvertTo(img, typeof(byte[]));
            }catch(Exception e){
                Console.WriteLine(e.Message);
                //MessageBox.Show("Error in saving image");
                return null;
            };
        }

        //Convert a byte array to an image
        public Bitmap ByteToImage(byte[] bytes)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = bytes;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;

        }
//==========================================================================================


//==================================Button functions========================================
//==========================================================================================
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (input() != null)
            {
                Question q = input();
                if (txtCode.Text.Equals("") || codeList.Contains(Convert.ToInt32(txtCode.Text)))
                {
                    MessageBox.Show("The question code has been existed!!!");
                    return;
                }
                saveData(q);
                loadData();
                clearInfo();
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            clearInfo();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            showAll();
            int code = 0;

            try
            {
                code = Convert.ToInt32(txtSearch.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Type the question code to find");
                return;
            }
            for (int i = 0; i < questionList.Count; i++)
            {
                if (questionList[i].Code == code)
                {
                    lbQuestion.SelectedIndex = i;
                    return;
                }
            }
            MessageBox.Show("Not founded");
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int index = lbQuestion.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Select a question to delete");
                return;
            }
            else
            {
                BOQuestion boq = new BOQuestion();
                boq.Delete(questionList[index]);
                loadData();
                clearInfo();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            int i = lbQuestion.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Select a question to change");
                return;
            }else if(txtCode.Text.Equals(""))
            {
                MessageBox.Show("Question code must not be empty!!!");
                return;
            }
            else 
            {
                int n = questionList[lbQuestion.SelectedIndex].Code;
                if ( n==Convert.ToInt32(txtCode.Text)||codeList.Contains(Convert.ToInt32(txtCode.Text))==false)
                {
                    if (input() != null)
                    {
                        BOQuestion boq = new BOQuestion();
                        boq.Update(input(),n);
                        clearInfo();
                    }
                }
                else
                {
                    MessageBox.Show("The question code has been existed!!!");
                    return;
                }
            }
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Image files|*.jpg;*.jpeg;*.bmp;*.png;*.gif|All files|*.*";
            opd.Title = "Select Image";
            opd.ShowDialog();
            try
            {
                image = Image.FromFile(opd.FileName);
                pictureBox.Image = image;
            }
            catch (Exception ex)
            {
                image = null;
                Console.WriteLine(ex.Message);
                MessageBox.Show("The file is not an image");
            }
        }

        private void btClearImage_Click(object sender, EventArgs e)
        {
            image = null;
            pictureBox.Image = null;
        }

        private void btShowTopic_Click(object sender, EventArgs e)
        {
            if (cbbTopic.Text != "")
            {
                lbQuestion.Items.Clear();
                for (int i = 0; i < questionList.Count; i++)
                    if (questionList[i].Topic.Equals(cbbTopic.Text))
                        lbQuestion.Items.Add(questionList[i]);
            }
            else
            {
                showAll();
            }
        }

        private void btShowAll_Click(object sender, EventArgs e)
        {
            showAll();
        }
//==========================================================================================


        private void clearChanged()
        {
            btClear.Enabled = !(txtCode.Text.Equals("")
                            && txtAnswerA.Text.Equals("")
                            && txtAnswerB.Text.Equals("")
                            && txtAnswerC.Text.Equals("")
                            && txtAnswerD.Text.Equals("")
                            && txtAnswerE.Text.Equals("")
                            && txtAnswerF.Text.Equals("")
                            && txtQuestion.Text.Equals("")
                            && txtMark.Text.Equals("")

                            && (ckbAnswerA.Checked == false && ckbAnswerB.Checked == false &&
                    ckbAnswerC.Checked == false && ckbAnswerD.Checked == false &&
                    ckbAnswerE.Checked == false && ckbAnswerF.Checked == false)
                            );
        }

        private void TextChanged(object sender, EventArgs e)
        {
            bt_Add.Enabled = (!txtCode.Text.Equals("") && answerList.Count > 1 && isDigitsOnly(txtCode.Text) && !(
                    (txtAnswerA.Text.Equals("") && ckbAnswerA.Checked == true) ||
                    (txtAnswerB.Text.Equals("") && ckbAnswerB.Checked == true) ||
                    (txtAnswerC.Text.Equals("") && ckbAnswerC.Checked == true) ||
                    (txtAnswerD.Text.Equals("") && ckbAnswerD.Checked == true) ||
                    (txtAnswerE.Text.Equals("") && ckbAnswerE.Checked == true) ||
                    (txtAnswerF.Text.Equals("") && ckbAnswerF.Checked == true))
                    &&
                    !(ckbAnswerA.Checked == false && ckbAnswerB.Checked == false &&
                    ckbAnswerC.Checked == false && ckbAnswerD.Checked == false &&
                    ckbAnswerE.Checked == false && ckbAnswerF.Checked == false)
                    
                    );
            checkInput();
            clearChanged();
            
        }

        private void IndexChanged(object sender, EventArgs e)
        {
            btUpdate.Enabled = btDelete.Enabled = !(lbQuestion.SelectedIndex == -1);

        }

        private void SearchChanged(object sender, EventArgs e)
        {
            btSearch.Enabled = !txtSearch.Text.Equals("");
        }



       


    }
}
