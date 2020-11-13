using System.Collections;
using System.Collections.Generic;

namespace ESAPIProxy.PatientTree
{
    public class PatientTree
    {
        private Node _rootNode;


        private PatientTree(string patientId)
        {
            _rootNode = new Node() {TagInfo = new PatientTagInfo(patientId)};
        }

        public static PatientTree Initialize(string patientId)
        {
            return new PatientTree(patientId);
        }

        public void AddNodeFromTagInfo(TagInfo tagInfo)
        {
            _rootNode.AddChildren(Node.FromTagInfo(tagInfo));
        }


        public Node AddCourseTagInfoByName(string courseId)
        {
            var courseNode = Node.FromTagInfo(new CourseTagInfo(courseId));
            _rootNode.AddChildren(courseNode);
            return courseNode;
        }

        public Node GetRoot() => _rootNode;

    }
}