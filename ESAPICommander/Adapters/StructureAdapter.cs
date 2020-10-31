using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using ESAPICommander.Interfaces;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Adapters
{
    public class StructureAdapter : IStructure
    {
        private Structure _structure;
        
        public StructureAdapter(Structure structure)
        {
            _structure = structure;
        }

        public string Id => _structure.Id;

        public Color Color => _structure.Color;
    }
}