using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionBankLibrary
{
    [Serializable]
    public class Answer : IComparable
    {
        public int Code { get; set; }
        public int QCode { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer() { }

        public Answer(int xQCode, string xText, bool xCorrect)
        {
            this.Code = 0;
            this.QCode = xQCode;
            this.Text = xText;
            this.IsCorrect = xCorrect;
        }

        public override string ToString()
        {
            return Text;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) throw new Exception("Object is null");

            Answer other = obj as Answer;
            if (other != null)
                return other.Text.CompareTo(this.Text);
            else
                throw new ArgumentException("Object is not a Answer");
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Answer other = obj as Answer;
            if (other != null)
                return (this.Code.Equals(other.Code) && this.QCode.Equals(other.QCode));
            else
                throw new ArgumentException("Object is not a Question");
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }
    }
}
