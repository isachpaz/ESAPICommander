using System;
using System.Collections.Generic;

namespace ESAPIProxy
{
    public class PatientTree
    {
        private Node _rootNode;

        private PatientTree(string patientId)
        {
            _rootNode = new Node() { TagInfo = new PatientTagInfo(patientId) };
        }

        public static PatientTree Initialize(string patientId)
        {
            return new PatientTree(patientId);
        }
    }
}