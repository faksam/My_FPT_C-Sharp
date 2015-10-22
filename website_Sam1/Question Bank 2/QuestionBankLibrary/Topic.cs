using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionBankLibrary
{
    [Serializable]
    public class Topic//:IComparable
    {
        public string TopicID { get; set; }
        public string TopicName { get; set; }
        public Topic() { }
        public Topic(string topicID, string topic)
        {
            this.TopicID = topicID;
            this.TopicName = topic;
        }
        //override Equals, GetHashCode
        public int CompareTo(object obj)
        {
            if (obj == null) throw new Exception("Object is null");

            Topic other = obj as Topic;
            if (other != null)
            {
                return this.TopicName.CompareTo(other.TopicName);
            }
            else
                throw new ArgumentException("Object is not a Topic");
        }

        public override string ToString()
        {
            return this.TopicName;
        }

    }
}
