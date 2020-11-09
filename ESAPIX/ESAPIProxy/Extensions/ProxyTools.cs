using EC = ESAPIX.Common;
using E = ESAPIX.Facade.API;
using V = VMS.TPS.Common.Model.API;

namespace ESAPIProxy.Extensions
{
    public static class ProxyTools
    {
        public static E.Course toEXCourse(this V.Course vcourse)
        {
            var ps = new E.Course()
            {
                Id = vcourse.Id,
                Patient = new E.Patient()
                {
                    Id = vcourse.Patient.Id,
                    FirstName = vcourse.Patient.FirstName,
                    LastName = vcourse.Patient.LastName
                },
            };
            return ps;
        }

        public static E.Patient AddPatient(this V.Patient vpatient)
        {
            var patient = new E.Patient()
            {
                Id = vpatient.Id,
                FirstName = vpatient.FirstName,
                LastName = vpatient.LastName
            };

            return patient;
        }
    }
}