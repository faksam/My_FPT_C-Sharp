using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QuestionBankLibrary;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Win32;

namespace GUI
{
    public partial class Form_CreateTest : Form
    {
        List<Question> questionList = new List<Question>();
        List<Question> questionToFile = new List<Question>();
        List<Answer> answerList = new List<Answer>();
        List<Topic> topicList = new List<Topic>();
        ArrayList codeList = new ArrayList();

        public Form_CreateTest()
        {
            InitializeComponent();
            loadData();
            cbbTopic.DataSource = topicList;
            btRandom.Enabled = false;
        }

//==================================Additional functions====================================
//==========================================================================================

        //Load data from sql server
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
            }
        }

        //Show all question of the selected topic
        public void showAll()
        {
            //cbbTopic.Text = null;
            lbQuestion.Items.Clear();
            for (int i = 0; i < questionList.Count; i++)
                if (questionList[i].Topic.Equals(cbbTopic.Text))
                    lbQuestion.Items.Add(questionList[i]);
        }
        
        //static void DisplayInExcel(IEnumerable<Question> questions)
        //{
        //    var excelApp = new Excel.Application();
        //    // Make the object visible.
        //    excelApp.Visible = true;

        //    // Create a new, empty workbook and add it to the collection returned  
        //    // by property Workbooks. The new workbook becomes the active workbook. 
        //    // Add has an optional parameter for specifying a praticular template.  
        //    // Because no argument is sent in this example, Add creates a new workbook. 
        //    excelApp.Workbooks.Add();

        //    // This example uses a single workSheet. 
        //    Excel._Worksheet workSheet = excelApp.ActiveSheet;

        //    // Earlier versions of C# require explicit casting. 
        //    //Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet; 

        //    // Establish column headings in cells A1 and B1.
        //    workSheet.Cells[1, "A"] = "Code";
        //    workSheet.Cells[1, "B"] = "Mark";
        //    workSheet.Cells[1, "B"] = "Mark";
        //    workSheet.Cells[1, "B"] = "Mark";
        //    workSheet.Cells[1, "B"] = "Mark";

        //    var row = 1;
        //    foreach (Question q in questions)
        //    {
        //        row++;
        //        workSheet.Cells[row, "A"] = acct.ID;
        //        workSheet.Cells[row, "B"] = acct.Balance;
        //    }

        //    workSheet.Columns[1].AutoFit();
        //    workSheet.Columns[2].AutoFit();

        //    // Call to AutoFormat in Visual C# 2010. This statement replaces the  
        //    // two calls to AutoFit.
        //    workSheet.Range["A1", "B3"].AutoFormat(
        //        Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

        //    // Put the spreadsheet contents on the clipboard. The Copy method has one 
        //    // optional parameter for specifying a destination. Because no argument   
        //    // is sent, the destination is the Clipboard.
        //    workSheet.Range["A1:B3"].Copy();
        //}

        static void DisplayInWord(IEnumerable<Question> questions)
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            // The Add method has four reference parameters, all of which are  
            // optional. Visual C# 2010 allows you to omit arguments for them if 
            // the default values are what you want.
            wordApp.Documents.Add();

            //var row = 1;
            string data = "";
            foreach (Question q in questions)
            {
                String answers = null;
                if (q.Answers != null)
                {
                    char sym = 'A';
                    for (int i = 0; i < q.Answers.Count; i++)
                    {
                        if (q.Answers[i].IsCorrect)
                            answers += "\n" + "[X] " + sym + ") " + q.Answers[i].ToString();
                        else
                            answers += "\n" + "    " + sym + ") " + q.Answers[i].ToString();
                        sym++;
                    }
                }
                data += "Code: " + q.Code + "\n" +
                                         "Topic: " + q.Topic + "\n" +
                                         "Mark: " + q.Mark + "\n" +
                                         "Question: " + q.Text + "\n" +
                                         answers +
                                         "\n=================================================\n\n";
            }
            wordApp.Selection.Text = data;
        }                
//==========================================================================================


//==================================Button functions========================================
//==========================================================================================
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            showAll();
            for (int i = 0; i < questionList.Count; i++)
                if (questionList[i].Topic.Equals(cbbTopic.Text))
                    questionToFile.Add(questionList[i]);
        }

        private void btRandom_Click(object sender, EventArgs e)
        {
            codeList.Clear();
            lbQuestion.Items.Clear();
            questionToFile.Clear();
            //try
            //{
                int no = Convert.ToInt32(txtNo.Text);
                Random random = new Random();
                List<Question> questionListTopic = new List<Question>();
                for (int i = 0; i < questionList.Count; i++)
                    if (questionList[i].Topic.Equals(cbbTopic.Text))
                        questionListTopic.Add(questionList[i]);
                while (true)
                {
                    int randomNumber = random.Next(0, questionListTopic.Count);
                    if (codeList.Contains(questionListTopic[randomNumber].Code) == false)
                    {
                        lbQuestion.Items.Add(questionListTopic[randomNumber]);
                        codeList.Add(questionListTopic[randomNumber].Code);
                        questionToFile.Add(questionListTopic[randomNumber]);
                        no--;
                    }
                    if (no == 0 || codeList.Count == questionListTopic.Count)
                        break;
                }
                questionListTopic.Clear();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Winword.exe");
            if (questionToFile.Count > 0 && key != null)
                DisplayInWord(questionToFile);
            else
                MessageBox.Show("No question to export or Microsoft Word isn't installed!");
        }
//==========================================================================================

        private void textchanged(object sender, EventArgs e)
        {
            if (txtNo.Text.Equals("")) btRandom.Enabled = false;
            else btRandom.Enabled = true;
        }
    }
}
