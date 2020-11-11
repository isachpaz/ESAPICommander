using System;
using System.Collections.Generic;

namespace ESAPIProxy
{
    public class PatientTree
    {
        private Node _rootNode;
        private Node _currentNode;

        private PatientTree(string patientId)
        {
            _rootNode = new Node() { TagInfo = new PatientTagInfo(patientId) };
            _currentNode = _rootNode;
        }

        public static PatientTree Initialize(string patientId)
        {
            return new PatientTree(patientId);
        }

        public void AddNodeFromTagInfo(TagInfo tagInfo)
        {
            _currentNode.AddChildren(Node.FromTagInfo(tagInfo));
        }
    }
}