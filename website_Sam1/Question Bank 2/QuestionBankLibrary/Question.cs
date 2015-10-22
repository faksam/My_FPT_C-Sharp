using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionBankLibrary
{
    [Serializable]
    public class Question : IComparable
    {
        public int Code { get; set; }
        public string Text { get; set; }
        public double Mark { get; set; }
        public string Topic { get; set; }
        public List<Answer> Answers;
        public byte[] Image;

        public Question() { }
        public Question(int XCode, string xText, double xMark, String xTopic, List<Answer> xAnswers, byte[] xImage)
        {
            this.Code = XCode;
            this.Text = xText;
            this.Mark = xMark;
            this.Topic = xTopic;
            this.Answers = xAnswers;
            this.Image = xImage;
        }
        public override string ToString()
        {
            String answers = null;
            if (Answers != null)
            {
                char sym = 'A';
                for (int i = 0; i < Answers.Count; i++)
                {
                    Answer ans = Answers[i] as Answer;
                    if (ans.IsCorrect)
                        answers += "\n" + "[X] " + sym + ") " + Answers[i].ToString();
                    else
                        answers += "\n" + "    " + sym + ") " + Answers[i].ToString();
                    sym++;
                }
            }

            return ("["+String.Format("{0:00000}",Code)+"] "+Text);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) throw new Exception("Object is null");

            Question other = obj as Question;
            if (other != null)
            {
                //return this.Text.CompareTo(other.Text);
                if (this.Code < other.Code)
                    return -1;
                else if (this.Code > other.Code)
                    return 1;
                else  
                    return 0;
            }
            else
                throw new ArgumentException("Object is not a Question");
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;

        //    Question other = obj as Question;
        //    if (other != null)
        //        return this.Code.Equals(other.Code);
        //    else
        //        throw new ArgumentException("Object is not a Question");
        //}

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }
    }
}