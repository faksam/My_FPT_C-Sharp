using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lap1
{
    class DoctorList
    {
        private ArrayList aList;

        public DoctorList()
        {
            aList = new ArrayList();
        }

        // Add the doctor
        public void add(Doctor b)
        {
            aList.Add(b);
        }

        //search by code
        public Doctor SearchByCode(string code)
        {
            Doctor b = null;
            foreach (Doctor iDoctor in aList)
            {
                if (iDoctor.Code.Contains(code))
                    return (b = iDoctor);
            }
            return b;
        }

        // Print All
        public void PrintAll()
        {
         //   aList.Sort(new BookComparebale());

            foreach (Doctor b in aList)
            {
                Console.WriteLine("{0:-5}  {1:-20}  {2:-20}", b.Code, b.Name,b.Special);
            }
        }
    }
}
