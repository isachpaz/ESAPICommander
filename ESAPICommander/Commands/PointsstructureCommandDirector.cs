using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using ESAPICommander.ArgumentConfig;
using ESAPIProxy;
using ESAPICommander.Logger;
using VMS.TPS.Common.Model.Types;


namespace ESAPICommander.Commands
{
    public class PointsstructureCommandDirector : BaseCommandDirector
    {
        private PointsstructureArgOptions _options;
        private List<VoxelData> _results = new List<VoxelData>();

        public PointsstructureCommandDirector(PointsstructureArgOptions options, ESAPIManager esapi, ILog log) :
            base(esapi, log, options.PIZ)
        {
            _options = options;
        }

        public override void ProcessRequest()
        {
            try
            {
                var patient = _esapi.GetPatient();
                _results = _esapi.ExtractStructurePoints(_options.Course, _options.Plan, _options.Structures.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        public override void PostProcess()
        {
            Action<List<VoxelData>> writeOutput = null;

            if (String.IsNullOrEmpty(_options.File))
            {
                writeOutput = results => results.ForEach(Console.WriteLine);
            }
            else
            {
                writeOutput = results =>
                {
                    Func<VVector, int, string> getDirection = (vv,pos) =>
                    {
                        //pos must be 0,1,2 for x,y,z
                        return vv[pos].ToString();
                    };

                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(_options.File.Trim('\n','\r')))
                    {
                        file.AutoFlush = true;
                        file.WriteLine(
                            "PatientId,CourseId,PlanId,StructureId,I,J,K,PosX,PosY,PosY,DosePoint_InGy,OriginX,OriginY,OriginZ,XRes_mm,YRes_mm,ZRes_mm,XDirection,YDirection,ZDirection");
                        foreach (var vd in results)
                        {
                            file.WriteLine(
                                $"{vd.PatientId},{vd.CourseId},{vd.PlanId},{vd.StructureId},{vd.I},{vd.J},{vd.K},{vd.Position.x:F6},{vd.Position.y:F6},{vd.Position.z:F6},{vd.DoseToPoint.Dose:F6},{vd.OriginX},{vd.OriginY},{vd.OriginZ},{vd.XRes},{vd.YRes},{vd.ZRes},{getDirection(vd.XDirection,0)},{getDirection(vd.YDirection,1)},{getDirection(vd.ZDirection,2)}");
                        }
                    }
                };
            }

            writeOutput(_results);
        }
    }
}